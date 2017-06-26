using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using WebApiSeed.AxHelpers;
using WebApiSeed.Models;

namespace WebApiSeed.Services
{
    public class MessageProcessor
    {
        public void Send()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var unsentMsgs = db.Messages.Where(x => (x.Status == MessageStatus.Pending || x.Status == MessageStatus.Failed)).ToList();

                    foreach (var msg in unsentMsgs)
                    {
                        MessageHelpers.SendMessage(msg.Id);
                    }
                }
            }
            catch (Exception) { }
        }


    }
    [DisallowConcurrentExecution]
    public class MessageProcessService : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            new MessageProcessor().Send();
        }
    }
}