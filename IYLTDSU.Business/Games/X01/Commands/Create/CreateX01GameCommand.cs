using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace IYLTDSU.Business.Games.X01.Create;
public record CreateX01GameCommand(int PlayerCount,
    int Sets,
    int Leg,
    bool DoubleIn,
    bool DoubleOut,
    int StartingScore,
    List<Guid> PlayerIds) : IRequest<CreateX01GameCommandResponse>;
