using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;

namespace WebApiSeed.Services
{
    public class ServicesScheduler
    {
        public static void Start()
        {
            var scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            var messageService = JobBuilder.Create<MessageProcessService>().Build();
            var msgTrigger = TriggerBuilder.Create()
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithIntervalInSeconds(5)
                        .RepeatForever())
                    .Build();

            scheduler.ScheduleJob(messageService, msgTrigger);
        }
    }
}