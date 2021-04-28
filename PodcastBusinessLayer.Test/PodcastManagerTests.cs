using Podcast.InMemory.DataAccess;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PodcastBusinessLayer.Test
{
    public class PodcastManagerTests
    {
        [Fact]
        public async Task Load_WhenLoadValidRss_ShouldcreatePostcastModel()
        {
            var subject = new PodcastManager(new PodcastRepository());

            var loadedPodcast = await subject.LoadAsync("https://www.svt.se/rss.xml");

            Assert.Equal("https://www.svt.se/rss.xml", loadedPodcast.UrlAdress);
        }

        [Fact]
        public async Task Get_WhenIdIsPassed_ShouldReturnPodcastModel()
        {
            var rep = new PodcastRepository();
            var podcast = new Podcast.Abstraction.Models.PodcastModel() { UrlAdress="test", Name = "name", Description = "des" };
            await rep.CreateOrUpdateAsync(podcast);
            var subject = new PodcastManager(rep);

            var loadedPodcast = await subject.GetAsync("test");

            Assert.NotNull(loadedPodcast);
        }

        [Fact]
        public async Task List_ShouldReturnAllPodcastThatExistInList()
        {
            var rep = new PodcastRepository();
            var podcast1 = new Podcast.Abstraction.Models.PodcastModel() {UrlAdress="test1", Name = "name1", Description = "des" };
            var podcast2 = new Podcast.Abstraction.Models.PodcastModel() { UrlAdress = "test2", Name = "name2", Description = "des1" };
            await rep.CreateOrUpdateAsync(podcast1);
            await rep.CreateOrUpdateAsync(podcast2);
            var subject = new PodcastManager(rep);
            
            var loadedPodcast =  await subject.ListAsync();

            Assert.NotEmpty(loadedPodcast);
        }


        [Fact]
        public async Task Delete_ShouldDeleteThePodcastThatIsGiven()
        {
            var rep = new PodcastRepository();
            var podcast1 = new Podcast.Abstraction.Models.PodcastModel() { Name = "name1", Description = "des" };
            await rep.CreateOrUpdateAsync(podcast1);
            var subject = new PodcastManager(rep);

            await subject.DeleteAsync(podcast1);

            var podcastlist = new Podcast.InMemory.DataAccess.PodcastRepository();
            var lista = await podcastlist.ListAsync();
            Assert.Empty(lista);
        }

        [Fact]
        public async Task DeleteByCategory_DeleteAllPodcastsInCategory()
        {
            PodcastManager subject = await SetupPodcastWithCategoriesAsync("cat");

            await subject.DeleteByCategoryAsync("cat");

            Assert.Empty(await subject.ListAsync("cat"));
        }

        private static async Task<PodcastManager> SetupPodcastWithCategoriesAsync(string category)
        {
            var rep = new PodcastRepository();
            var podcast1 = new Podcast.Abstraction.Models.PodcastModel() { UrlAdress = "test1", Name = "name1", Description = "des", Category = category };
            var podcast2 = new Podcast.Abstraction.Models.PodcastModel() { UrlAdress = "test2", Name = "name1", Description = "des", Category = category };
            var podcast3 = new Podcast.Abstraction.Models.PodcastModel() { UrlAdress = "test3", Name = "name1", Description = "des", Category = "test2" };
            await rep.CreateOrUpdateAsync(podcast1);
            await rep.CreateOrUpdateAsync(podcast2);
            await rep.CreateOrUpdateAsync(podcast3);
            var subject = new PodcastManager(rep);
            return subject;
        }

        [Fact]
        public async Task ChangeCategory_ShouldChangeCategoryInEveryPodcastWithSameCategoryName()
        {
            var rep = new PodcastRepository();
            var podcast1 = new Podcast.Abstraction.Models.PodcastModel() { UrlAdress = "test1", Name = "name1", Description = "des", Category = "test1" };
            var podcast2 = new Podcast.Abstraction.Models.PodcastModel() { UrlAdress = "test2", Name = "name1", Description = "des", Category = "test1" };
            var podcast3 = new Podcast.Abstraction.Models.PodcastModel() { UrlAdress = "test3", Name = "name1", Description = "des", Category = "test1" };
            await rep.CreateOrUpdateAsync(podcast1);
            await rep.CreateOrUpdateAsync(podcast2);
            await rep.CreateOrUpdateAsync(podcast3);
            var subject = new PodcastManager(rep);

            await subject.ChangeCategoryAsync("categorynew", "test1");

            Assert.Empty(await subject.ListAsync("test1"));
            Assert.NotEmpty(await subject.ListAsync("categorynew"));
        }

        [Fact]
        public async Task List_GetListOfPodcast_ShouldGiveListInSpecificCategory()
        {
            var rep = new PodcastRepository();
            var podcast1 = new Podcast.Abstraction.Models.PodcastModel() { Name = "name1", Description = "des", Category = "test1" };
            await rep.CreateOrUpdateAsync(podcast1);
            var subject = new PodcastManager(rep);

            await subject.ListAsync("test1");

            Assert.NotEmpty(await subject.ListAsync("test1"));
        }
    }
}
