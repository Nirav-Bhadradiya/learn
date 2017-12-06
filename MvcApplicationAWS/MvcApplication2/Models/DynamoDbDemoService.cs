using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;

namespace MvcApplication2.Models
{
    public class DynamoDbDemoService
    {
        IAmazonDynamoDB client;
        DynamoDBContext context;
        public DynamoDbDemoService()
        {
            Amazon.Util.ProfileManager.RegisterProfile("demo-aws-profile", "AKIAJZD645WL6ZGOVXVA", "s5qaWsjAqC8mu+3BY2Vy/g6fYnpg1TBcp6ukZD1U");
            client = new AmazonDynamoDBClient(Amazon.RegionEndpoint.USEast1);
            context = new DynamoDBContext(client);
        }

        public List<AttributeDefinition> GetTableInstance(string tblName)
        {
                DescribeTableRequest describeTableRequest = new DescribeTableRequest();
                describeTableRequest.TableName = tblName;
                DescribeTableResponse describeTableResponse = client.DescribeTable(describeTableRequest);
                return describeTableResponse.Table.AttributeDefinitions;
        }

        public List<string> GetTablesList()
        {
                ListTablesRequest listTablesRequest = new ListTablesRequest();
                listTablesRequest.Limit = 5;
                ListTablesResponse listTablesResponse = client.ListTables(listTablesRequest);
                return listTablesResponse.TableNames;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
           
            //context.Scan<Employee>(new ScanCondition("",ScanOperator.GreaterThan,0));

            employees.Add(context.Load<Employee>(0));
            //List<Employee> employees = new List<Employee>();

            //var table = Table.LoadTable(client, Utilities.Utility.EmployeeTable);
            //ScanFilter filter = new ScanFilter();
            ////filter.AddCondition("iemp_id", ScanOperator.IsNotNull, new List<AttributeValue>() { new AttributeValue() { N = "0" } });
            //filter.AddCondition("iemp_id", ScanOperator.IsNotNull);
            ////filter.AddCondition("iemp_id", ScanOperator.GreaterThan, 0);

            //// You are specifying optional parameters so use QueryOperationConfig.
            //ScanOperationConfig config = new ScanOperationConfig()
            //{
            //    Filter = filter,
            //    // Optional parameters.
            //    // Select = SelectValues.SpecificAttributes,
            //    AttributesToGet = new List<string> { "iemp_id", "demp_salary", "semp_name" }
            //    //ConsistentRead = true
            //};

            //Search search = table.Scan(config);

            ////List<Document> documentSet = new List<Document>();
            ////do
            ////{

            ////    documentSet = search.GetNextSet();
            //foreach (var document in search.Matches)
            //{

            //    Employee emp = new Employee();
            //    foreach (var attribute in document.GetAttributeNames())
            //    {
            //        string stringValue = null;
            //        var value = document[attribute];

            //        if (value is Primitive)
            //            stringValue = value.AsPrimitive().Value.ToString();
            //        else if (value is PrimitiveList)
            //            stringValue = string.Join(",", (from primitive
            //                            in value.AsPrimitiveList().Entries
            //                                            select primitive.Value).ToArray());

            //        switch (attribute)
            //        {
            //            case "iemp_id":
            //                emp.EmployeeId = Convert.ToInt32(stringValue);
            //                break;
            //            case "demp_salary":
            //                emp.Salary = Convert.ToInt32(stringValue);
            //                break;
            //            case "semp_name":
            //                emp.FirstName = stringValue;
            //                break;
            //        }
            //    }
            //    employees.Add(emp);
            //}
            //} while (!search.IsDone);

            //var request = new QueryRequest
            //{
            //    TableName = Utilities.Utility.EmployeeTable,
            //    KeyConditions = new Dictionary<string, Condition>
            //    {
            //        {
            //            "iemp_id",new Condition()
            //            {
            //                ComparisonOperator = ComparisonOperator.GT,
            //                AttributeValueList = new List<AttributeValue>
            //                {
            //                    new AttributeValue { N="0" }
            //                }
            //            }
            //        }
            //    }
            //};

            //var response = client.Query(request);

            return employees;
        }

        public bool AddEmployee(Employee emp)
        {
            context.Save(emp);
            return true;
        }
    }
}