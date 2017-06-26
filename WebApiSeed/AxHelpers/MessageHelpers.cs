using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using RestSharp;
using RestSharp.Authenticators;
using WebApiSeed.Models;
using WedApiSeed;

namespace WebApiSeed.AxHelpers
{
    public class MessageHelpers
    {
        private static readonly MessageService MsgServiceSettings = SetupConfig.Setting.MessageService;
        public static void SendMessage(long msgId)
        {
            if (!MsgServiceSettings.IsActive) return;
            using (var db = new AppDbContext())
            {
                var eoe = db.Messages.First(x => x.Id == msgId && (x.Status == MessageStatus.Pending || x.Status == MessageStatus.Failed));

                var client = new RestClient(MsgServiceSettings.BaseUrl);
                var request = new RestRequest(MsgServiceSettings.SendMessageUrl, Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };
                request.AddHeader(HttpRequestHeader.Authorization.ToString(),
                    $"Bearer {MsgServiceSettings.ApiKey}");
                request.AddParameter("Type", MessageType.SMS.ToString());
                request.AddParameter("SenderId", MsgServiceSettings.SenderId);
                request.AddParameter("Subject", eoe.Subject);
                request.AddParameter("Message", eoe.Text);
                request.AddParameter("Recipients", eoe.Recipient);
                var res = client.Execute(request);
                eoe.Response = res.ResponseStatus + " @" + DateTime.Now;
                if (res.StatusCode != HttpStatusCode.OK)
                {
                    eoe.Status = MessageStatus.Failed;
                    return;
                }
                eoe.Status = MessageStatus.Sent;
                db.SaveChanges();
            }
        }
        public static IRestResponse SendEmailMessage(long id)
        {
            var db = new AppDbContext();
            var eoe = db.EmailOutboxEntries.First(x => x.Id == id && !x.IsSent);
            eoe.LastAttemptDate = DateTime.Now;
            var client = new RestClient
            {
                BaseUrl = new Uri("https://api.mailgun.net/v3"),
                Authenticator = new HttpBasicAuthenticator("api",
                    "key-xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx")
            };
            var request = new RestRequest();
            //request.
            request.AddParameter("domain",
                "sandboxxxxxxxxxxxxxxxxxxxxxxxxxxxx.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "App Name <mailgun@sandboxxxxxxxxxxxxxx.mailgun.org>");
            request.AddParameter("to", eoe.Receiver);
            request.AddParameter("subject", eoe.Subject);
            request.AddParameter("html", eoe.Message);
            request.AddParameter("text", "App Name");
            request.Method = Method.POST;
            var res = client.Execute(request);
            if (res.StatusCode == HttpStatusCode.OK)
            {
                eoe.IsSent = true;
                eoe.LastAttemptMessage = res.ResponseStatus.ToString();
            }
            else
            {
                eoe.LastAttemptMessage = res.ErrorMessage;
            }

            db.SaveChanges();
            return res;
        }
    }
}