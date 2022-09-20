using Amazon.DynamoDBv2.DataModel;

namespace IYLTDSU.Backend.LambdaApi;

public class ApplicationOptions
{
    public string DynamoDbTable { get; set; }
    public DynamoDBOperationConfig ToOperationConfig()
    {
        return new DynamoDBOperationConfig { OverrideTableName = DynamoDbTable };
    }
}
