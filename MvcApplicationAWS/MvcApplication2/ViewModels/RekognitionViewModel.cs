using Amazon.Rekognition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamoDbCRUDApp.ViewModels
{
    public class RekognitionViewModel
    {
        public string Name { get; set; }
        public List<Label> Labels { get; set; }
        public Label singleLable { get; set; }
    }
}