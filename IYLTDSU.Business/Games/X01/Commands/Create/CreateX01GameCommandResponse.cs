using IYLTDSU.Persistance.Entities;

namespace IYLTDSU.Business.Games.X01.Create;

public record CreateX01GameCommandResponse(
    Game Game,
    IEnumerable<GamePlayer> GamePlayers,
    IEnumerable<GameDart> GameDarts
);
