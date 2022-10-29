using Amazon.DynamoDBv2.DataModel;

namespace IYLTDSU.Domain.Infrastructure
{
    public interface ISortKeyItem
    {
        [DynamoDBRangeKey("SK")] public string SortKey { get; set; }
    }
}