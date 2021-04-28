using Podcast.Abstraction.Interfaces;
using Podcast.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Podcast.Serializer.XML
{
    public class PodcastxMLSerializer : IPodcastSerializer
    {
        public  Task<IEnumerable<PodcastModel>> DeserializeAsync(string path)
        {
            List<PodcastModel> listofPodcast;
            if (!File.Exists(path))
            {
                return Task.FromResult(Enumerable.Empty<PodcastModel>());
            }

            XmlSerializer xmlserializer = new XmlSerializer(typeof(List<PodcastModel>));
            using (FileStream inFile = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                listofPodcast = (List<PodcastModel>)xmlserializer.Deserialize(inFile);
            }

            return Task.FromResult(listofPodcast.AsEnumerable());
        }


        public Task SerializerAsync(IEnumerable<PodcastModel> podcasts, string path)
        {
            XmlSerializer xmlserializer = new XmlSerializer(podcasts.GetType());
            using (FileStream outFile = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                xmlserializer.Serialize(outFile, podcasts);
            }
            return Task.CompletedTask;
        }
    }
}
