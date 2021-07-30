using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day5.Repository
{
    class FileMultimedialeRepository : IRepository<FileMultimediale>
    {

        CanzoneRepository canzoneRepository = new CanzoneRepository();
        PodcastRepository podcastRepository = new PodcastRepository();

        List<FileMultimediale> fileMultimediali = new List<FileMultimediale>();

        public List<FileMultimediale> Fetch()
        {
            List<Canzone> canzoni = canzoneRepository.Fetch();
            List<Podcast> podcasts = podcastRepository.Fetch();

            fileMultimediali.AddRange(canzoni);
            fileMultimediali.AddRange(podcasts);

            return fileMultimediali;
        }
    }
}
