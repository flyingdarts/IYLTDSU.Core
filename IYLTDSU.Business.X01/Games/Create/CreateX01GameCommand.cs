using MediatR;

namespace IYLTDSU.Business.X01.Games.Create;
public class CreateX01GameCommand : IRequest<CreateX01GameDetail>
{
    public int PlayerCount { get; set; }
    public int Sets { get; set; }
    public int Leg { get; set; }
    public bool DoubleIn { get; set; }
    public bool DoubleOut { get; set; }
    public int StartingScore { get; set; }
    public List<Guid> PlayerIds { get; set; }
}