public class PlayerDartScores
{
    public Guid PlayerId { get; set; }
    public IEnumerable<DartScore> Scores { get; set; }
}