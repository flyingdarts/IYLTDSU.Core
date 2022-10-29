using Amazon.DynamoDBv2.DataModel;
using IYLTDSU.Domain.Games.Settings;
using IYLTDSU.Domain.Infrastructure;
using Constants = IYLTDSU.Shared.Constants;
namespace IYLTDSU.Domain.Games
{
    public class Game : IPrimaryKeyItem, ISortKeyItem, IAlternativeSortKeyItem
    {
        [DynamoDBHashKey("PK")]
        public string PrimaryKey { get; set; }

        [DynamoDBRangeKey("SK")]
        public string SortKey { get; set; }

        [DynamoDBLocalSecondaryIndexRangeKey("LSI1")]
        public string LocalSecondaryIndexItem { get; set; }


        public long GameId { get; set; }
        public GameType Type { get; set; }
        public GameStatus Status { get; set; }
        public int PlayerCount { get; set; }

        public X01GameSettings? X01 { get; set; }
        public CricketGameSettings? Cricket { get; set; }

        public DateTime CreatedAt => new(GameId);

        public Game()
        {
            GameId = DateTime.UtcNow.Ticks;
            Status = GameStatus.Qualifying;
            PrimaryKey = Constants.Game;
            SortKey = $"{GameId}#{Status}";
            LocalSecondaryIndexItem = $"{Status}#{GameId}";
        }
        public static Game Create(int playerCount, X01GameSettings settings)
        {
            return new Game()
            {
                Type = GameType.X01,
                PlayerCount = playerCount,
                X01 = settings
            };
        }

        public static Game Create(int playerCount, CricketGameSettings settings)
        {
            return new Game()
            {
                Cricket = settings,
                Type = GameType.Cricket,
                PlayerCount = playerCount
            };
        }
    }
}