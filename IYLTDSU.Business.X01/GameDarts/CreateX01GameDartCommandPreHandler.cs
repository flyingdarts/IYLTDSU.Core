using MediatR.Pipeline;

namespace IYLTDSU.Business.X01.GameDarts
{
    public record CreateX01GameDartCommandPreHandler(X01GameService X01GameService) : IRequestPreProcessor<CreateX01GameDartCommand>
    {
        public async Task Process(CreateX01GameDartCommand request, CancellationToken cancellationToken)
        {
            await X01GameService.Initialize(request.GameId);
            request.Game = X01GameService.Game;
            request.GamePlayers = X01GameService.Players;
            request.GameDarts = X01GameService.Darts;
        }
    }
}
