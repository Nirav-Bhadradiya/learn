using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.Rekognition.Model.Internal.MarshallTransformations;
using System.IO;
using System.Net;
using static DynamoDbCRUDApp.Models.CloudSight;

namespace DynamoDbCRUDApp.Models
{
    public class RekognitionService
    {
        IAmazonRekognition amazonRekognitionClient;
        public RekognitionService()
        {
            //Amazon.Util.ProfileManager.RegisterProfile("demo-aws-profile", "AKIAJZD645WL6ZGOVXVA", "s5qaWsjAqC8mu+3BY2Vy/g6fYnpg1TBcp6ukZD1U");
            amazonRekognitionClient = new AmazonRekognitionClient(Amazon.RegionEndpoint.USEast1);
        }

        public List<Celebrity> DetectCelebrity(MemoryStream image)
        {
            RecognizeCelebritiesRequest req = new RecognizeCelebritiesRequest() { Image = new Image { Bytes = image } };

            RecognizeCelebritiesResponse respone = amazonRekognitionClient.RecognizeCelebrities(req);

            return respone.CelebrityFaces;
        }

        public List<Label> RecognizeImage(MemoryStream image)
        {
            DetectLabelsRequest req = new DetectLabelsRequest() { Image = new Image { Bytes = image} };

            return amazonRekognitionClient.DetectLabels(req).Labels;
        }

        public string GetCloudSightData(HttpPostedFileBase file)
        {
            API cs = new API();
            string refference;
            cs.ImageRequest(out refference);
            return "";
        }
    }
}