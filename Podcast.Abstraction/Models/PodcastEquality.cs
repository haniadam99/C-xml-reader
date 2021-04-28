using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Podcast.Abstraction.Models
{
    public class PodcastEquality : IEqualityComparer<PodcastModel>
    {
        public bool Equals(PodcastModel x, PodcastModel y)
        {
            if ((x.Name == y.Name) &&
               (x.Description == y.Description) &&
               (x.Interval == y.Interval) &&
               (x.UrlAdress == y.UrlAdress) &&
               (x.items.SequenceEqual(y.items, new ItemDescriptionEqality())))
            {
                return true;
            }


            return false;
        }

        public int GetHashCode(PodcastModel obj)
        {
            return obj.Name.GetHashCode() ^ obj.Description.GetHashCode() ^ obj.UrlAdress.GetHashCode() ^ obj.items.Sum(s=>s.GetHashCode());
        }
    }

    public class ItemDescriptionEqality : IEqualityComparer<ItemDescription>
    {
        public bool Equals(ItemDescription x, ItemDescription y)
        {
            if ((x.Name == y.Name) && (x.Summary == y.Summary))
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(ItemDescription obj)
        {
            return obj.Name.GetHashCode() ^ obj.Summary.GetHashCode();
        }
    }
}
