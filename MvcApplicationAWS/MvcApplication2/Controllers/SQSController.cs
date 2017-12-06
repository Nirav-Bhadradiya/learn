using DynamoDbCRUDApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DynamoDbCRUDApp.Controllers
{
    public class SQSController : Controller
    {
        //
        // GET: /SQS/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListQueue()
        {
            AWSSimpleQueueService sqsService = new AWSSimpleQueueService();

            var queus = sqsService.ListQueueURL("TEST_Q");
            return View();
        }


    }
}
