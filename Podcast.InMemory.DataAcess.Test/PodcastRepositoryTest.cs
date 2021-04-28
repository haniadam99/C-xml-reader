using Podcast.InMemory.DataAccess;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Podcast.InMemory.DataAcess.Test
{
    public class PodcastRepositoryTest
    {
        [Fact]
        public async Task Get_WhenPodcastExists_ShouldReturnIt()
        {
            var subject = new PodcastRepository();
            var podcast = new Abstraction.Models.PodcastModel() { UrlAdress="test", Name = "name", Description = "des" };
            await subject.CreateOrUpdateAsync(podcast);

            var loadedPodcast = await subject.GetAsync(podcast.UrlAdress);
            Assert.NotNull(loadedPodcast);
            Assert.Equal("test", loadedPodcast.UrlAdress);
            Assert.Equal("name", loadedPodcast.Name);
        }

        [Fact]
        public async Task Get_WhenPodcastNotExists_ShouldReturnNull()
        {
            var subject = new PodcastRepository();

            var loadedPodcast = await subject.GetAsync("www.bad.se");
            Assert.Null(loadedPodcast);
        }


        [Fact]
        public async Task Create_WhenNewPodcastcreate_ShouldBeSave()
        {
            var subject = new PodcastRepository();
            var podcast = new Abstraction.Models.PodcastModel() {UrlAdress="test", Name = "name", Description = "des" };
            await subject.CreateOrUpdateAsync(podcast);
            Assert.Equal("test", podcast.UrlAdress);
        }

        [Fact]
        public async Task Delete_WhenPodcastExist_ShouldBeDeleted()
        {
            var subject = new PodcastRepository();
            var podcast = new Abstraction.Models.PodcastModel() {UrlAdress="test", Name = "name", Description = "des" };
            await subject.CreateOrUpdateAsync(podcast);

            await subject.DeleteAsync(podcast);
            var p = await subject.GetAsync(podcast.UrlAdress);
            Assert.Null(p);
        }

        [Fact]
        public async Task List_WhenPodcastsExists_ShouldReturnList()
        {
            var subject = new PodcastRepository();
            var podcast = new Abstraction.Models.PodcastModel() { UrlAdress = "test1", Name = "name1", Description = "des" };
            var podcast1 = new Abstraction.Models.PodcastModel() { UrlAdress = "test2", Name = "name2", Description = "des" };
            await subject.CreateOrUpdateAsync(podcast);
            await subject.CreateOrUpdateAsync(podcast1);

            var p = await subject.ListAsync();
            Assert.NotEmpty(p);
            Assert.Equal(2,p.Count());
            Assert.Contains("name1", p.Select(l=>l.Name));
            Assert.Contains("name2", p.Select(l=>l.Name));
        }
    }
}
