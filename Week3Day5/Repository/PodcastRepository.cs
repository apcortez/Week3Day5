using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day5.Repository
{
    class PodcastRepository : IRepository<Podcast>
    {
        static Autore pa1 = new Autore("Tizio", "Neri", 1980);
        static Autore pa2 = new Autore("Caio", "Rossi", 1965);

        static Episodio p1e1 = new Episodio("Episodio1", new TimeSpan(0, 50, 30), true);
        static Episodio p1e2 = new Episodio("Episodio2", new TimeSpan(0, 55, 10), false);
        static Episodio p2e1 = new Episodio("Episodio1Podcast2", new TimeSpan(0, 35, 50), true);
        static Episodio p2e2 = new Episodio("Episodio2Podcast2", new TimeSpan(1, 55, 10), false);
        
        static Dictionary<string, Episodio> episodi = new Dictionary<string, Episodio>
        {
            {p1e1.Titolo, p1e1 },
            {p1e2.Titolo, p1e2 }
        };

        static Dictionary<string, Episodio> episodip2 = new Dictionary<string, Episodio>
        {
            {p2e1.Titolo, p2e1 },
            {p2e2.Titolo, p2e2 }
        };


        static List<Podcast> podcasts = new List<Podcast>
        {
            new Podcast("TitoloPodcast1", pa1, "DescrizionePodcast1",  episodi),
            new Podcast("Podcast2", pa2, "DescrizionePodcast2", episodip2)
        };
        public List<Podcast> Fetch()
        {
            return podcasts;
        }

        internal static bool Exists(string podcastChoosen)
        {
            return podcasts.Any(p => p.Titolo == podcastChoosen);
        }

        internal static Podcast GetByTitolo(string podcastChoosen)
        {
            var podc = from podcast in podcasts
                       where podcast.Titolo == podcastChoosen
                       select podcast;
            return podc.First();

        }

        internal static List<Podcast> FilterByDuration(TimeSpan timeChoosen)
        {
            List<Podcast> pFilterByDuration = new List<Podcast>();
            foreach (var podcast in podcasts)
            {
                foreach (var episodio in podcast.Episodi)
                {
                    if (episodio.Value.Durata <= timeChoosen)
                    {
                        pFilterByDuration.Add(podcast);
                        break;
                    }
                }
            }
            return pFilterByDuration;
        }
    }

}
