using IYLTDSU.Domain;
using IYLTDSU.Domain.Games;

namespace IYLTDSU.Business.X01.GameDarts
{
    public class CreateX01GameDartDetail
    {
        public long GameId { get; set; }
        public bool RoundCompleted { get; set; }
        public GameStatus GameStatus { get; set; }

        public static CreateX01GameDartDetail Create(Game game, List<GameDart> latestGameDarts)
        {
            var everyPlayersDartCount = latestGameDarts.GroupBy(x => x.PlayerId).Select(x => x.Count()).ToList();
            return new CreateX01GameDartDetail()
            {
                GameId = game.GameId,
                RoundCompleted = everyPlayersDartCount.Count > 0 && !everyPlayersDartCount.Distinct().Skip(1).Any(),
                GameStatus = game.Status
            };
        }
    }
}
