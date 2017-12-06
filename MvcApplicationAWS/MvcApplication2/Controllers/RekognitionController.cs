using Amazon.Rekognition.Model;
using Amazon.SQS.Model;
using DynamoDbCRUDApp.Models;
using DynamoDbCRUDApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DynamoDbCRUDApp.Controllers
{
    public class RekognitionController : Controller
    {
        //
        // GET: /Rekognition/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult DetectCelebrity(HttpPostedFileBase file)
        {
            Celebrity CelebName = new Celebrity();
            RekognitionViewModel viewmodel = new RekognitionViewModel();
            if (file != null)
            {
                RekognitionService service = new RekognitionService();
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    CelebName = service.DetectCelebrity(ms).FirstOrDefault();

                    //add celebrity name to SQS to send an email to send an alert
                    AWSSimpleQueueService queueService = new AWSSimpleQueueService();
                    SendMessageResponse response = queueService.AddMessageToQueue(queueService.ListQueueURL("TEST_Q"), CelebName.Name.ToString());

                    viewmodel.Name = CelebName == null ? "Person is not Celebrity / Not Found" : CelebName.Name + "/" + response.MessageId;
                }

            }
            // after successfully uploading redirect the user
            return View("CelebrityInfo", viewmodel);
        }


        //public ActionResult DetectCelebrity(HttpPostedFileBase file)
        //{
        //    List<Label> labels = new List<Label>();
        //    RekognitionViewModel viewmodel = new RekognitionViewModel();
        //    RekognitionService service = new RekognitionService();
        //    service.GetCloudSightData(file);
        //    if (file != null)
        //    {
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            file.InputStream.CopyTo(ms);
        //            labels = service.RecognizeImage(ms);
        //            viewmodel.Labels = labels == null ? new List<Label>() { new Label { Name = "" } } : labels;
        //        }
        //    }

        //    // after successfully uploading redirect the user
        //    return View("RecognizeImage", viewmodel);
        //}

    }
}
