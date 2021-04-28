using Podcast.Abstraction.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Podcast.Abstraction.Interfaces
{
    public interface IPodcastSerializer
    {
        Task SerializerAsync(IEnumerable<PodcastModel> podcasts, string path);

        Task<IEnumerable<PodcastModel>> DeserializeAsync(string path);
    }
}
