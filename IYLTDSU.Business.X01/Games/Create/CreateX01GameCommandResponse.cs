using IYLTDSU.Domain;
using IYLTDSU.Domain.Games;

namespace IYLTDSU.Business.X01.Games.Create;

public record CreateX01GameCommandResponse(
    Game Game,
    IEnumerable<GamePlayer> GamePlayers,
    IEnumerable<GameDart> GameDarts
);