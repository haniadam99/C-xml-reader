using Podcast.Abstraction.Models;
using PodcastBusinessLayer;
using System;
using System.Collections.Generic;
using System.Timers;


namespace Podcast.BusinessLayer
{
    public class PodcastScheduleService : ScheduleServiceBase
    {
        private readonly PodcastTimer[] _podcastTimers = new PodcastTimer[4];        
       
        public PodcastScheduleService(PodcastManager podcastmanager)
        {
            //only for test 
            _podcastTimers[0] = new PodcastTimer(podcastmanager, 1);
#if DEBUG
            _podcastTimers[1] = new PodcastTimer(podcastmanager, 3);
            _podcastTimers[2] = new PodcastTimer(podcastmanager, 6);
            _podcastTimers[3] = new PodcastTimer(podcastmanager, 9);
#else
            _podcastTimers[1] = new PodcastTimer(podcastmanager, 60);
            _podcastTimers[2] = new PodcastTimer(podcastmanager, 60*2);
            _podcastTimers[3] = new PodcastTimer(podcastmanager, 60*3);
#endif

        }

        public void AddPodcastTimer(PodcastModel podcast)
        {
            if (podcast.Interval < 0 || podcast.Interval > 3) throw new ArgumentException("Interval should be between 1-3");
            _podcastTimers[podcast.Interval].Add(podcast);
            Start();
        }

        public override void Start()
        {
            foreach (var t in _podcastTimers)
            {
                t.Start();
            }
        }

        public override void Stop()
        {
            foreach (var t in _podcastTimers)
            {
                t.Stop();
            }
        }
    }

    internal class PodcastTimer
    {
        private static object _lockObject = new object();
        private readonly PodcastManager _podcastManager;
        private readonly List<PodcastModel> _workingsList = new List<PodcastModel>();
        private readonly Timer _timer;
        private bool _ongoing = false;
        public PodcastTimer(PodcastManager podcastManager,  int numberOfsec)
        {
            _podcastManager = podcastManager;
            _timer = new Timer(numberOfsec * 1000);
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_ongoing) return;
 
            try
            {
                _ongoing = true;
                List<PodcastModel> tmp = new List<PodcastModel>();
                lock (_lockObject)
                {
                    foreach (var item in _workingsList)
                    {
                        tmp.Add(item);
                    }
                }

                foreach (var job in tmp)
                {
                    _podcastManager.LoadAllPodcastAsync(job.UrlAdress, job.Name, job.numberOfItems, job.Category).Wait();
                }
            }
            finally
            {
                _ongoing = false;
            }
        }
        public void Add(PodcastModel podcastModel)
        {
            lock (_lockObject)
            {
                _workingsList.Add(podcastModel);
            }
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
