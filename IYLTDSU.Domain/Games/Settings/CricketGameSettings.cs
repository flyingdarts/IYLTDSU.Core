namespace IYLTDSU.Domain.Games.Settings
{
    public class CricketGameSettings : IGameSettings
    {
        public Dictionary<int, bool> Targets { get; set; }
        public CricketGameSettings(int sets, int legs)
        {
            Targets = new Dictionary<int, bool>();

            Enumerable
                .Range(15, 6)
                .Append(25)
                .ToList()
                .ForEach(x =>
                {
                    Targets.Add(x, false);
                }
                );
        }

        public int Legs { get; set; }
        public int Sets { get; set; }
    }
}
