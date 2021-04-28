using Podcast.BusinessLayer;
using Podcast.InMemory.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PodcastBusinessLayer.Test
{
    public class PodcastScheduleServiceTest
    {
        [Fact]
        public async Task  AddPodcastTimer_ShouldUpdatePodcastInGivenIntervall()
        {
            var rep = new PodcastRepository();
            var podcast1 = new Podcast.Abstraction.Models.PodcastModel() { Name = "name1", Description = "des", Category = "test1", Interval = 0 , UrlAdress= "https://www.svt.se/rss.xml" };
            await rep.CreateOrUpdateAsync(podcast1);

            var podcastmanager = new PodcastManager(rep);
            var podcastscheduleservice = new PodcastScheduleService(podcastmanager);

            podcast1.LastExecuted = DateTime.MinValue;
            podcastscheduleservice.AddPodcastTimer(podcast1);
            podcastscheduleservice.Start();
            await Task.Delay(2000);
            Assert.False(podcast1.LastExecuted > DateTime.MinValue);
        }
    }
}
