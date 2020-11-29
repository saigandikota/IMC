using System;
using System.IO;
using System.Net;
using System.Text;

namespace IMC.API.Integrations
{
    public static class ApiHelper
    {

        public static void ExecuteHttpAction(APIRequestData request, out APIResponseData response)
        {
            response = new APIResponseData();
            try
            {
                //create the request
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(request.PostURL);
                req.Method = request.HttpRequestType.ToString();

                //set the content type
                req.ContentType = "application/x-www-form-urlencoded ";
                req.Headers.Add(string.Format("Authorization: Bearer {0}", request.APIKey));

                //If PostDataJSON exists, then it will be a JSON Post to the vendor. 
                //This logic may need to update as per the integration requirements
                if (!string.IsNullOrEmpty(request.PostDataJSON))
                {
                    req.ContentType = "application/json";
                    byte[] data = Encoding.ASCII.GetBytes(request.PostDataJSON);
                    req.ContentLength = data.Length;
                    Stream requestStream = req.GetRequestStream();
                    requestStream.Write(data, 0, data.Length);
                    requestStream.Close();
                }

                //start the post
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                response.ResponseStatusCode = resp.StatusCode.ToString();

                //Check the outcome of the response
                if (resp.StatusCode == HttpStatusCode.OK)  //server responded 200
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                    string resptext = sr.ReadToEnd();
                    response.ResponseContent = resptext;
                    response.ResponseStatus = "Success";
                }
                else
                {
                    response.ResponseStatus = "Error: The server responded with the following error: " + resp.StatusDescription;
                    response.ResponseStatusCode = "FAIL";
                }
            }
            catch (Exception ex)
            {
                response.ResponseStatus = "Error: The server responded with the following error: " + ex.Message;
                response.ResponseStatusCode = "FAIL";
            }
        }
    }
}
