using Amazon.DynamoDBv2.DataModel;

namespace CrudDynamoDB.Models
{
    [DynamoDBTable("e-commerce-table")]
    public class User
    {
        [DynamoDBHashKey("pk")]
        public string Site { get; set; }
        [DynamoDBRangeKey("sk")]
        public string Email { get; set; }
        [DynamoDBProperty]
        public string City { get; set; }
        [DynamoDBProperty]
        public string Name { get; set; }
        [DynamoDBProperty]
        public string Password { get; set; }
        public User()
        {
            
        }
    }
}
