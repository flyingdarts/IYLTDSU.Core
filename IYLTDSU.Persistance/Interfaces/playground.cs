using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IYLTDSU.Persistance.Interfaces
{
    public interface ITournament : IPrimaryKeyItem, ISortKeyItem, IAlternativeSortKeyItem
    { 
        public long Id { get; set; }
        public DateTime CreatedAt { get { return DateTimeOffset.FromUnixTimeSeconds(Id).UtcDateTime; } }
    }

    public interface ISocialMediaGroup : IPrimaryKeyItem, ISortKeyItem, IAlternativeSortKeyItem
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get { return DateTimeOffset.FromUnixTimeSeconds(Id).UtcDateTime; } }
        
    }
}
