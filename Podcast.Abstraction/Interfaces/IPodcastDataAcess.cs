using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Podcast.Abstraction.Models;

namespace Podcast.Abstraction.Interfaces
{
    public interface IPodcastDataAcess
    {
        Task CreateOrUpdateAsync(PodcastModel podcast);

        Task<IEnumerable<PodcastModel>> ListAsync();

        Task DeleteAsync(PodcastModel podcast);

        Task<PodcastModel> GetAsync(string url);

        Task<IEnumerable<PodcastModel>> GetAsyncByCategory(string category);
    }
}
