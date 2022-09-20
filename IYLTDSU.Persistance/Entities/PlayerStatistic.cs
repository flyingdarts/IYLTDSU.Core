namespace IYLTDSU.Persistance.Entities
{
    public class PlayerStatistic
    {
        public Guid PlayerId { get; set; }
        public GameType GameType { get; set; }
        public int TotalPoints { get; set; }
        public int NumberOfDarts { get; set; }
        public DateTime CreatedAt { get; set; }
        public PlayerStatistic(Guid playerId, GameType gameType, int totalPoints, int numberOfDarts)
        {
            PlayerId = playerId;
            GameType = gameType;
            TotalPoints = totalPoints;
            NumberOfDarts = numberOfDarts;
            CreatedAt = DateTime.UtcNow;
        }
    }
}