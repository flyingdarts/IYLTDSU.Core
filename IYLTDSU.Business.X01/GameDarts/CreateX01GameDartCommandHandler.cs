using Amazon.DynamoDBv2.DataModel;
using IYLTDSU.Domain;
using IYLTDSU.Domain.Games;
using MediatR;
using Microsoft.Extensions.Options;

namespace IYLTDSU.Business.X01.GameDarts
{
    public record CreateX01GameDartCommandHandler(IDynamoDBContext DbContext, IOptions<ApplicationOptions> ApplicationOptions) : IRequestHandler<CreateX01GameDartCommand, CreateX01GameDartDetail>
    {
        public async Task<CreateX01GameDartDetail> Handle(CreateX01GameDartCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<GameDart> gameDarts = null;

            if (request.Game.Status == GameStatus.Qualifying)
            {
                gameDarts = GameDart.CreateQualifying(
                    request.GameId,
                    request.PlayerId,
                    request.Scores,
                    request.Game.X01!.StartingScore
                );
            }

            if (gameDarts != null)
            {
                var batchWrite = DbContext.CreateBatchWrite<GameDart>(ApplicationOptions.Value.ToOperationConfig()); batchWrite.AddPutItems(gameDarts);
                await batchWrite.ExecuteAsync(cancellationToken);
                request.GameDarts.AddRange(gameDarts);
            }

            return CreateX01GameDartDetail.Create(request.Game, request.GameDarts);
        }
    }
}
