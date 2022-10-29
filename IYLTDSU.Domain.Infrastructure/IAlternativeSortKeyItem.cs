using Amazon.DynamoDBv2.DataModel;

namespace IYLTDSU.Domain.Infrastructure
{
    public interface IAlternativeSortKeyItem
    {
        [DynamoDBRangeKey("LSI1")] public string LocalSecondaryIndexItem { get; set; }
    }
}