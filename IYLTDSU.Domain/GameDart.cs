using Amazon.DynamoDBv2.DataModel;
using IYLTDSU.Domain.Infrastructure;
using Constants = IYLTDSU.Shared.Constants;

namespace IYLTDSU.Domain
{
    public class GameDart : IPrimaryKeyItem, ISortKeyItem, IAlternativeSortKeyItem
    {
        [DynamoDBHashKey("PK")]
        public string PrimaryKey { get; set; }

        [DynamoDBRangeKey("SK")]
        public string SortKey { get; set; }

        [DynamoDBLocalSecondaryIndexRangeKey("LSI1")]
        public string LocalSecondaryIndexItem { get; set; }

        public Guid Id { get; set; }
        public long GameId { get; set; }
        public Guid PlayerId { get; set; }
        public int Score { get; set; }
        public int GameScore { get; set; }
        public DateTime CreatedAt { get; set; }

        public GameDart()
        {
            PrimaryKey = Constants.GameDart;
        }
        public static GameDart CreateInitial(long gameId, Guid playerId, int gameScore)
        {
            var id = Guid.NewGuid();
            var createdAt = DateTime.UtcNow;

            return new GameDart()
            {
                Id = id,
                CreatedAt = createdAt,
                GameId = gameId,
                PlayerId = playerId,
                GameScore = gameScore,
                Score = 0,
                SortKey = $"{gameId}#{id}#{playerId}",
                LocalSecondaryIndexItem = $"{Constants.GameDart}#{playerId}#{createdAt}"
            };
        }
        public static GameDart Create(long gameId, Guid playerId, int score, int gameScore)
        {
            var id = Guid.NewGuid();
            var createdAt = DateTime.UtcNow;

            return new GameDart()
            {
                Id = id,
                CreatedAt = createdAt,
                GameId = gameId,
                PlayerId = playerId,
                GameScore = gameScore,
                Score = score,
                SortKey = $"{gameId}#{id}#{playerId}",
                LocalSecondaryIndexItem = $"{Constants.GameDart}#{playerId}#{createdAt}"
            };
        }

        public static IEnumerable<GameDart> CreateQualifying(long gameId, Guid playerId, List<int> scores, int gameScore)
        {
            var createdAt = DateTime.UtcNow;

            return scores.Select(x =>
            {
                var id = Guid.NewGuid();

                return new GameDart()
                {
                    Id = id,
                    CreatedAt = createdAt,
                    GameId = gameId,
                    PlayerId = playerId,
                    GameScore = gameScore,
                    Score = x,
                    SortKey = $"{gameId}#{id}#{playerId}",
                    LocalSecondaryIndexItem = $"{Constants.GameDart}#{playerId}#{createdAt}"
                };
            });
        }
    }
}
