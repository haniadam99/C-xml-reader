using Podcast.Abstraction.Interfaces;
using Podcast.Abstraction.Models;
using System;
using System.Collections.Generic;
using Xunit;
using Podcast.Serializer.XML;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace Podcast.Xml.Serializer.Test
{
    public class PodcastSerializerTest
    {
        [Fact]
        public async Task Serializer_ShouldSaveInXmlFile()
        {
            List<PodcastModel> podcastModels = new List<PodcastModel>();
            var itemList1 = new List<ItemDescription>();
            var itemDescription1 = new ItemDescription();

            itemDescription1.Name = "SvtNyheter";
            itemDescription1.Summary = "SVTlokaNyheter";
            itemList1.Add(itemDescription1);

            var itemList2 = new List<ItemDescription>();
            var itemDescription2 = new ItemDescription();

            itemDescription2.Name = "AftonbladetNyheter";
            itemDescription2.Summary = "AftonbladetLokalaNyheter";

            var podcast1 = new Podcast.Abstraction.Models.PodcastModel() { Name = "name1", Description = "des", Category = "Komedi", items = itemList1.ToArray() };
            var podcast2 = new Podcast.Abstraction.Models.PodcastModel() { Name = "name2", Description = "des1", Category = "Drama", items = itemList2.ToArray() };

            podcastModels.Add(podcast1);
            podcastModels.Add(podcast2);
               
            var podcastserialize = new PodcastxMLSerializer();
            await podcastserialize.SerializerAsync(podcastModels.AsEnumerable(), "c://temp/test.xml");

            var savedPodcasts = await podcastserialize.DeserializeAsync("c://temp/test1.xml");

            Assert.Equal(podcastModels, savedPodcasts, new PodcastEquality());


        }
    }
}
