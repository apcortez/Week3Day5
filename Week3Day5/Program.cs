using System;
using System.Collections.Generic;
using Week3Day5.Repository;

namespace Week3Day5
{
    class Program
    {
        static CanzoneRepository canzoneRepository = new CanzoneRepository();
        static PodcastRepository podcastRepository = new PodcastRepository();
     
        static void Main(string[] args)
        {
            int scelta;
            do
            {
                Console.WriteLine("Benvenuto! Scegli l'operazione da fare:");
                Console.WriteLine("1 - Visualizza tutte le canzoni");
                Console.WriteLine("2 - Visualizza tutti i podcasts");
                Console.WriteLine("3 - Filtra per genere");
                Console.WriteLine("4 - Visualizza un podcast");
                Console.WriteLine("5 - Filtra per durata");
                Console.WriteLine("0 - Per uscire");
                while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 5)
                {
                    Console.WriteLine("Inserisci un'operazone valida. Riprova: ");
                }
                switch (scelta)
                {
                    case 1:
                        ViewCanzoni();
                        break;
                    case 2:
                        ViewPodcasts();
                        break;
                    case 3:
                        ChooseGenere();
                        break;
                    case 4:
                        ChooosePodcast();
                        break;
                    case 5:
                        ChooseDurata();
                        break;
                    case 0:
                        break;
                }
                Console.WriteLine("\n");
            } while (scelta != 0);
        }

        private static void ChooseDurata()
        { int ore, minuti, secondi;
            Console.WriteLine("Inserisci il numero di ore del podcast: ");
            while (!int.TryParse(Console.ReadLine(), out ore) || ore < 0)
            {
                Console.WriteLine("Inserisci un numero di ore valido. Riprova: ");
            }
            
            Console.WriteLine("Inserisci il numero di minuti del podcast: ");
            while (!int.TryParse(Console.ReadLine(), out minuti) || minuti < 0 || minuti>59)
            {
                Console.WriteLine("Inserisci un numero di minuti valido. Riprova: ");
            }

            Console.WriteLine("Inserisci il numero di secondi del podcast: ");
            while (!int.TryParse(Console.ReadLine(), out secondi) || secondi < 0 || secondi>59)
            {
                Console.WriteLine("Inserisci un numero di secondi valido. Riprova: ");
            }

            TimeSpan timeChoosen = new TimeSpan(ore, minuti, secondi);

            List<Podcast> podcastFilteredByDuration = PodcastRepository.FilterByDuration(timeChoosen);
            if (podcastFilteredByDuration != null && podcastFilteredByDuration.Count == 0)
            {
                Console.WriteLine("Nessun match trovato.");
            }
            else
            {
                foreach (var podcast in podcastFilteredByDuration)
                {
                    Console.WriteLine(podcast.Print());
                    foreach (var episodio in podcast.Episodi)
                    {
                        if (episodio.Value.Durata <= timeChoosen)
                        {

                            Console.WriteLine("Episodio: " + episodio.Value.Titolo + ", Durata: " + episodio.Value.Durata.Hours + ":" + episodio.Value.Durata.Minutes + ":" + episodio.Value.Durata.Seconds);
                        }
                    }
                }
            }
            
        }

        private static void ChooosePodcast()
        {
            Console.WriteLine("Scrivi il nome di un podcast da visualizzare: ");
            string podcastChoosen = Console.ReadLine();
            bool exist = PodcastRepository.Exists(podcastChoosen);
            if (exist)
            {
                Podcast pc = PodcastRepository.GetByTitolo(podcastChoosen);
                Console.WriteLine(pc.Print()+ "\n");
                foreach(var episodio in pc.Episodi)
                {
                    Console.WriteLine($"Titolo: {episodio.Key}, Durata: {episodio.Value.Durata.Hours}:{episodio.Value.Durata.Minutes}:{episodio.Value.Durata.Seconds}");
                }
            }
            else
            {
                Console.WriteLine("Mi dispiace ma il podcast inserito non è stato trovato.");
            }
        }

        private static void ChooseGenere()
        {
            int scelta;
            Console.WriteLine("Scegli un genere tra quelli elencati: ");
            Console.WriteLine((int)GenereEnum.Rock + " - " + GenereEnum.Rock);
            Console.WriteLine((int)GenereEnum.Pop + " - " + GenereEnum.Pop);
            Console.WriteLine((int)GenereEnum.Classic + " - " + GenereEnum.Classic);
            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta >3)
            {
                Console.WriteLine("Inserisci un'operazone valida. Riprova: ");
            }
           
            List<Canzone> canzoniByGenere = canzoneRepository.getByGenere(scelta);
            foreach(var canzone in canzoniByGenere)
            {
                Console.WriteLine(canzone.Print());
            }
        }

        private static void ViewPodcasts()
        {
            List<Podcast> podcasts = podcastRepository.Fetch();
            foreach(var podcast in podcasts)
            {
                Console.WriteLine(podcast.Print());
            }
        }

        private static void ViewCanzoni()
        {
            List<Canzone> canzoni = canzoneRepository.Fetch();

            foreach(var canzone in canzoni)
            {
                Console.WriteLine(canzone.Print());
            }
        }
    }
}
        