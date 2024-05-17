using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GravitonEcoCoreService.Managers
{
    internal class WebServer
    {
        public void StartServer()
        {
            using var listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8001/");

            listener.Start();

            Console.WriteLine("Listening on port 8001...");

            while (true)
            {
                HttpListenerContext ctx = listener.GetContext();
                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;

                if (req.HttpMethod == "GET")
                {
                    string url = req.Url.AbsolutePath;
                    if (url == "/")
                    {
                        HandleRootRequest(resp);
                    }
                    else if (url == "/data")
                    {
                        HandleDataRequest(req, resp);
                    }
                    else
                    {
                        SendJsonResponse(resp, new { error = "Not Found" }, HttpStatusCode.NotFound);
                    }
                }
                else
                {
                    SendJsonResponse(resp, new { error = "Method Not Allowed" }, HttpStatusCode.MethodNotAllowed);
                }

                resp.Close();
            }
        }

        private void HandleRootRequest(HttpListenerResponse response)
        {
            var responseObject = new { message = "Welcome to the server!" };
            SendJsonResponse(response, responseObject, HttpStatusCode.OK);
        }

        private void HandleDataRequest(HttpListenerRequest request, HttpListenerResponse response)
        {
            string alias = request.QueryString["alias"];
            if (int.TryParse(request.QueryString["interval"], out int interval))
            {
                if (string.IsNullOrEmpty(alias))
                {
                    SendJsonResponse(response, new { error = "Please provide an alias parameter." }, HttpStatusCode.BadRequest);
                }
                else
                {
                    DateTime now = DateTime.Now;
                    DateTime startTime = now.AddHours(-interval);
                    DateTime endTime = now.AddHours(interval);

                    using var context = new ApplicationContext();
                    var data = context.Sensor
                        .Where(s => s.Alias == alias && s.Timestamp.ToUniversalTime() >= startTime.ToUniversalTime() && s.Timestamp.ToUniversalTime() <= endTime.ToUniversalTime())
                        .ToList();

                    if (data.Count > 0)
                    {
                        var avg = data.Average(s => s.Value);
                        var max = data.Max(s => s.Value);
                        var min = data.Min(s => s.Value);

                        var responseObject = new
                        {
                            Alias = alias,
                            AverageValue = avg,
                            MaxValue = max,
                            MinValue = min,
                            StartTime = startTime,
                            EndTime = endTime
                        };

                        SendJsonResponse(response, responseObject, HttpStatusCode.OK);
                    }
                    else
                    {
                        SendJsonResponse(response, new { error = "No data found for the given alias and time range." }, HttpStatusCode.NotFound);
                    }
                }
            }
            else
            {
                SendJsonResponse(response, new { error = "Invalid or missing interval parameter." }, HttpStatusCode.BadRequest);
            }
        }

        private void SendJsonResponse(HttpListenerResponse response, object responseObject, HttpStatusCode statusCode)
        {
            string jsonString = JsonSerializer.Serialize(responseObject);
            byte[] buffer = Encoding.UTF8.GetBytes(jsonString);
            response.StatusCode = (int)statusCode;
            response.StatusDescription = statusCode.ToString();
            response.ContentType = "application/json";
            response.ContentLength64 = buffer.Length;

            using var output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
        }
    }
}