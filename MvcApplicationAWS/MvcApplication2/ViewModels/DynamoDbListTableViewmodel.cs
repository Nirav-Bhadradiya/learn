using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon.Runtime;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace MvcApplication2.ViewModels
{
    public class DynamoDbListTableViewModel
    {
        public List<string> dynamoDbtableLists { get; set; }
        public string TableName { get; set; }

        public List<AttributeDefinition> AttributeDefinition { get; set; }
        public string AttributeName { get; set; }
    }
}