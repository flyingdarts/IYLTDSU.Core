using IYLTDSU.Domain;
using IYLTDSU.Domain.Games;
using IYLTDSU.Domain.Games.Settings;

namespace IYLTDSU.Business
{
    public class SeedData
    {
        public Game Game { get; internal set; }
        public List<GamePlayer> Players { get; internal set; }
        public List<GameDart> Darts { get; internal set; }
        public SeedData()
        {
            Initialize();
        }
        private void Initialize()
        {
            GenerateGame();
            GeneratePlayers();
            GenerateDarts();
        }
        public void GenerateGame()
        {
            Game = new()
            {
                GameId = 637839509297991860,
                Type = GameType.X01,
                Status = GameStatus.Qualifying,
                PlayerCount = 5,
                X01 = new X01GameSettings
                {
                    Legs = 3,
                    Sets = 2,
                    DoubleOut = true,
                    DoubleIn = false,
                    StartingScore = 501
                }
            };
        }
        public void GeneratePlayers()
        {
            Players = new List<GamePlayer>
            {
                GamePlayer.Create(Game.GameId, Guid.NewGuid()),
                GamePlayer.Create(Game.GameId, Guid.NewGuid()),
                GamePlayer.Create(Game.GameId, Guid.NewGuid()),
                GamePlayer.Create(Game.GameId, Guid.NewGuid()),
                GamePlayer.Create(Game.GameId, Guid.NewGuid()),
                GamePlayer.Create(Game.GameId, Guid.NewGuid()),
                GamePlayer.Create(Game.GameId, Guid.NewGuid()),
                GamePlayer.Create(Game.GameId, Guid.NewGuid()),
                GamePlayer.Create(Game.GameId, Guid.NewGuid()),
                GamePlayer.Create(Game.GameId, Guid.NewGuid())
            };
        }
        public void GenerateDarts()
        {
            Darts = new List<GameDart>();

            foreach (var player in Players)
            {
                for (var j = 0; j < 3; j++)
                {
                    Darts.Add(new GameDart { PlayerId = player.PlayerId, Score = RandomScore() });
                }
            }
        }

        public int RandomScore()
        {
            return new List<int> { 0, 25, 50 }[new Random().Next(3)];
        }
    }
}
