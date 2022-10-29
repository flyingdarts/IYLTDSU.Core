using IYLTDSU.Domain;
using IYLTDSU.Domain.Games;
using MediatR;

namespace IYLTDSU.Business.X01.GameDarts
{
    public record CreateX01GameDartCommand(long GameId, Guid PlayerId, List<int> Scores) : IRequest<CreateX01GameDartDetail>
    {
        internal Game Game { get; set; }
        internal List<GamePlayer> GamePlayers { get; set; }
        internal List<GameDart> GameDarts { get; set; }
    }
}
