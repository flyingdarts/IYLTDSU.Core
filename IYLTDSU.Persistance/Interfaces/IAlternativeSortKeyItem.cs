using Amazon.DynamoDBv2.DataModel;

namespace IYLTDSU.Persistance.Interfaces
{
    public interface IAlternativeSortKeyItem
    {
        [DynamoDBRangeKey("LSI1")] public string LocalSecondaryIndexItem { get; set; }
    }
}