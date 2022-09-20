using Amazon.DynamoDBv2.DataModel;

namespace IYLTDSU.Persistance.Entities
{
    public interface ISortKeyItem
    {
        [DynamoDBRangeKey("SK")] public string SortKey { get; set; }
    }
}