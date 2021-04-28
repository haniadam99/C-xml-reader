using Podcast.Abstraction.Interfaces;
using Podcast.Abstraction.Models;
using Podcast.BusinessLayer;
using Podcast.Serializer.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PodcastBusinessLayer
{
    public class PodcastManager
    {
        private IPodcastDataAcess _podcastDataAcess;

        public PodcastManager(IPodcastDataAcess dataacess)
        {
            _podcastDataAcess = dataacess;
        }


        public async Task<PodcastModel> LoadAsync(string url)
        {
            XmlReader xmlReader = XmlReader.Create(url);
            var feed = SyndicationFeed.Load(xmlReader);
            var podcast = new PodcastModel
            {
                UrlAdress = url,
                Name = feed.Title.Text,
                Description = feed.Description.Text,
                numberOfItems = feed.Items.Count(),
             
            };
            
            var itemdescriptions = new List<ItemDescription>();
            foreach (var item in feed.Items)
            {
                itemdescriptions.Add(new ItemDescription() { Name = item.Title?.Text ?? "no Titel", Summary = item.Summary?.Text ?? "No summary" });
            }
            podcast.items = itemdescriptions.ToArray();
            podcast.LastExecuted = DateTime.UtcNow;
            
            await _podcastDataAcess.CreateOrUpdateAsync(podcast);
            return podcast;
        }

        public async Task<PodcastModel> LoadAllPodcastAsync(string url, string title, int interval, string category )
        {
            XmlReader xmlReader = XmlReader.Create(url);
            var feed = SyndicationFeed.Load(xmlReader);
            var podcast = new PodcastModel
            {
                UrlAdress = url,
                Name = title,
                Description = feed.Description.Text,
                numberOfItems = feed.Items.Count(),
                Interval = interval,
                Category = category,
                
            };

            var itemdescriptions = new List<ItemDescription>();
            foreach (var item in feed.Items)
            {
                itemdescriptions.Add(new ItemDescription() { Name = item.Title?.Text ?? "no Titel", Summary = item.Summary?.Text ?? "No summary" });
            }
            podcast.items = itemdescriptions.ToArray();
            podcast.LastExecuted = DateTime.UtcNow;

            await _podcastDataAcess.CreateOrUpdateAsync(podcast);
            return podcast;
        }

        public async Task DeleteAsync(PodcastModel podcast)
        {
            await _podcastDataAcess.DeleteAsync(podcast);
        }

        public async Task SerializeAsync()
        {
           var listofPodcasts = await _podcastDataAcess.ListAsync();
           var serializer = new PodcastxMLSerializer();

          await serializer.SerializerAsync(listofPodcasts, "podcastlista.xml");

        }

        public void DeserializeAsync()
        {
            var access = new PodcastxMLSerializer();
            var allPodcasts = access.DeserializeAsync("podcastlista.xml");

            foreach(var podcast in allPodcasts.Result)
            {
                _podcastDataAcess.CreateOrUpdateAsync(podcast);
            }
        }


        public async Task<IEnumerable<PodcastModel>>getAsyncByCategory(string category)
        {
            var podcastbyCategory = await _podcastDataAcess.GetAsyncByCategory(category);

            return podcastbyCategory;

        }

        public async Task<PodcastModel> GetAsync(string url)
        {
            try
            {
                return (await _podcastDataAcess.ListAsync()).Where(p => p.UrlAdress == url).FirstOrDefault();

            }
            catch
            {
                throw new PodcastNotFoundException();
            }
        }

        public async Task DeleteByCategoryAsync(string CategoryName)
        {
            var podcast = (await _podcastDataAcess.ListAsync()).Where(p => p.Category?.Equals(CategoryName, StringComparison.OrdinalIgnoreCase) ?? false).ToList();

            foreach (var p in podcast)
            {
                await _podcastDataAcess.DeleteAsync(p);
            }
        }

        public async Task ChangeCategoryAsync(string NewCategoryName, string OldCategoryName)
        {
            var podcast = (await ListAsync()).Where(p => p.Category?.Equals(OldCategoryName, StringComparison.OrdinalIgnoreCase)?? false).ToList();
            foreach (var p in podcast)
            {
                p.Category = NewCategoryName;
                await _podcastDataAcess.CreateOrUpdateAsync(p);
            }
        }

        public async Task<IEnumerable<PodcastModel>> ListAsync(string CategoryName) => (await ListAsync()).Where(p => p.Category.Equals(CategoryName, StringComparison.OrdinalIgnoreCase)).ToList();

        public async Task<IEnumerable<PodcastModel>> ListAsync() => await _podcastDataAcess.ListAsync();
    }
}
