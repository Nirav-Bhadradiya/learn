using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace DynamoDbCRUDApp.Models
{
    public class AWSSimpleQueueService
    {
        IAmazonSQS sqsClient;

        public AWSSimpleQueueService()
        {
            sqsClient = new AmazonSQSClient(Amazon.RegionEndpoint.USEast1);
        }

        public string ListQueueURL(string queueName)
        {
            List<string> allqueues = new List<string>();
            ListQueuesResponse test = sqsClient.ListQueues(queueName);

            return test.QueueUrls.FirstOrDefault();
        }

        public SendMessageResponse AddMessageToQueue(string queueURL,string message)
        {
            SendMessageResponse response = null;
            SendMessageRequest request = new SendMessageRequest()
            {
                MessageBody = message,
                QueueUrl = queueURL
            };

            response = sqsClient.SendMessage(request);
            return response;
        }

    }
}