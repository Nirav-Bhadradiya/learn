using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamoDbCRUDApp.ViewModels
{
    public class SQSViewModel
    {
       public  List<string> queueURLs { get; set; }
    }
}