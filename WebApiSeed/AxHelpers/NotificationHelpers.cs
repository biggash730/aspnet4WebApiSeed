using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace WebApiSeed.AxHelpers
{
    [HubName("notificationhub")]
    public class NotificationHub : Hub { }

    public class SignalNotice
    {
        public SignalEvent SignalEvent { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public object Data { get; set; }
    }

    public enum SignalEvent
    {
        FoodOrderIn,
        FoodOrderReady,
        DrinkOrderIn,
        DrinkOrderReady,
        General,
    }

    public class NotificationHelpers
    {
        public static void OnSignalEvent(SignalEvent evnt, string msg, object data)
        {
            var notHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            notHub.Clients.All.notify(new SignalNotice
            {
                SignalEvent = evnt,
                Success = true,
                Message = msg,
                Data = data
            });
        }
    }
}