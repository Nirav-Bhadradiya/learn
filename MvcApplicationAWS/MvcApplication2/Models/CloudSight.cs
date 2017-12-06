using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace DynamoDbCRUDApp.Models
{
    public class CloudSight
    {
        public static string BASE_URL = "https://api.cloudsightapi.com";
        string REQUESTS_URL = BASE_URL+ "/image_requests";
        string RESPONSES_URL = BASE_URL+ "/image_responses/";

        string DEFAULT_LOCALE = "en-US";
        int DEFAULT_POLL_TIMEOUT = 10 * 60;
        int INITIAL_POLL_WAIT = 4;
        string USER_AGENT = "cloudsight-python v1.0";

        // Possible values for current job status.

        // Recognition has not yet been completed for this image. Continue polling until
        // response has been marked completed.
        string STATUS_NOT_COMPLETED = "not completed";

        // Recognition has been completed. Annotation can be found in Name and Categories
        // field of Job structure.
        string STATUS_COMPLETED = "completed";

        // Token supplied on URL does not match an image.
        string STATUS_NOT_FOUND = "not found";

        //Image couldn't be recognized because of a specific reason. Check the
        // `reason` field.
        string STATUS_SKIPPED = "skipped";

        // Recognition process exceeded the allowed TTL setting.
        string STATUS_TIMEOUT = "timeout";


        // The API may choose not to return any response for given image. Below constants
        // include possible reasons for such behavior.

        // Offensive image content.
        string REASON_OFFENSIVE = "offensive";

        // Too blurry to identify.
        string REASON_BLURRY = "blurry";

        // Too close to identify.
        string REASON_CLOSE = "close";

        // Too dark to identify.
        string REASON_DARK = "dark";

        // Too bright to identify.
        string REASON_BRIGHT = "bright";

        // Content could not be identified.
        string REASON_UNSURE = "unsure";


        public class API
        {
            public API()
            {

            }

            public void ImageRequest(out string referenec)
            {
                referenec = "";
                WebClient wc = new WebClient();
                string strURL = "https://api.cloudsightapi.com/image_requests";
                wc.Headers.Add("Authorization", "Cloudsight  IveGBABKNFrSaXkK8YIo0g");
                    wc.Headers.Add("Host","api.cloudsightapi.com");
                //wc.Headers.Add("Origin:","https://cloudsightapi.com");
                string response = wc.DownloadString(strURL);
            }

            public string ImageRequest(out int referenec)
            {
                referenec = 0;
                return "";
            }
        }
    }
}