using Podcast.Abstraction.Interfaces;
using Podcast.Abstraction.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using Podcast.Serializer.XML;


namespace Podcast.InMemory.DataAccess
{
    public class PodcastRepository : IPodcastDataAcess
    {
        private List<PodcastModel> _repository = new List<PodcastModel>();
        private static object _lockObject = new object();
        public Task DeleteAsync(PodcastModel podcast)
        {
            lock (_lockObject)
            {
                _repository.Remove(podcast);
                return Task.CompletedTask;
            }
        }

        //public Task<IEnumerable<PodcastModel>> SavePodcastsInMemory()
        //{
        //    var podcast = new PodcastxMLSerializer();
        //    var podcastlista = podcast.DeserializeAsync("podcastlista.xml");

        //    foreach(var p in podcastlista.Result)
        //    {
        //        _repository.Add(p);
        //    }
            
        //    return podcastlista;
   
        //}

        public Task<PodcastModel> GetAsync(string url)
        {
            lock (_lockObject)
            {
                var res = _repository.Where(p => p.UrlAdress.Equals(url, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                return Task.FromResult(res);
            }
        }


        public Task<IEnumerable<PodcastModel>> GetAsyncByCategory(string category)
        {
            lock (_lockObject)
            {
                var res = _repository.Where(p => p.Category?.Equals(category, StringComparison.OrdinalIgnoreCase)?? false).AsEnumerable();
                return Task.FromResult(res);
            }
        }

        public Task<IEnumerable<PodcastModel>> ListAsync()
        {
            lock (_lockObject)
            {
                var res = _repository.AsEnumerable();
                return Task.FromResult(res);
            }
        }

        public async Task CreateOrUpdateAsync(PodcastModel podcast)
        {
            var savedPodcast = await GetAsync(podcast.UrlAdress);
            lock (_lockObject)
            {
                if (savedPodcast == null)
                {
                    _repository.Add(podcast);
                }
                else
                {
                    var index = _repository.IndexOf(savedPodcast);
                    _repository[index] = podcast;
                }
            }
        }
    }
}
