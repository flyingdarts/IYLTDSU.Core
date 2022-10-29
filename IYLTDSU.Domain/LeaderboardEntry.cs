using IYLTDSU.Domain.Games;

namespace IYLTDSU.Domain
{
    public class LeaderboardEntry
    {
        public Guid PlayerId { get; set; }
        public int Rank { get; set; }
        public int GamesWon { get; set; }
        public GameType GameType { get; set; }
        public LeaderboardEntry(Guid playerId, int rank, int gamesWon, GameType gameType)
        {
            PlayerId = playerId;
            Rank = rank;
            GamesWon = gamesWon;
            GameType = gameType;
        }
    }
}
