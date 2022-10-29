using Amazon.DynamoDBv2.DataModel;

namespace IYLTDSU.Business;

public class ApplicationOptions
{
    public string DynamoDbTable { get; set; }
    public DynamoDBOperationConfig ToOperationConfig()
    {
        return new DynamoDBOperationConfig { OverrideTableName = DynamoDbTable };
    }
}
