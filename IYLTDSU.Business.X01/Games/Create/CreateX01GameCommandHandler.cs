using Amazon.DynamoDBv2.DataModel;
using IYLTDSU.Domain;
using IYLTDSU.Domain.Games;
using IYLTDSU.Domain.Games.Settings;
using MediatR;
using Microsoft.Extensions.Options;

namespace IYLTDSU.Business.X01.Games.Create;
public record CreateX01GameCommandHandler(IDynamoDBContext DbContext, IOptions<ApplicationOptions> ApplicationOptions) : IRequestHandler<CreateX01GameCommand, CreateX01GameDetail>
{
    public async Task<CreateX01GameDetail> Handle(CreateX01GameCommand request, CancellationToken cancellationToken)
    {
        var game = Game.Create(request.PlayerCount, new X01GameSettings(request.Sets, request.Leg, request.DoubleIn, request.DoubleOut, request.StartingScore));
        var players = request.PlayerIds.Select(x => GamePlayer.Create(game.GameId, x));
        var playerDarts = players.Select(x => GameDart.CreateInitial(x.GameId, x.PlayerId, request.StartingScore));

        var gameWrite = DbContext.CreateBatchWrite<Game>(ApplicationOptions.Value.ToOperationConfig()); gameWrite.AddPutItem(game);
        var gamePlayersBatch = DbContext.CreateBatchWrite<GamePlayer>(ApplicationOptions.Value.ToOperationConfig()); gamePlayersBatch.AddPutItems(players);
        var gameDartsBatch = DbContext.CreateBatchWrite<GameDart>(ApplicationOptions.Value.ToOperationConfig()); gameDartsBatch.AddPutItems(playerDarts);

        await gameWrite.Combine(gamePlayersBatch, gameDartsBatch).ExecuteAsync(cancellationToken);

        return new CreateX01GameDetail(game, players, playerDarts);
    }
}

