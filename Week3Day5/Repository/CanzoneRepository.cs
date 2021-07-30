using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day5.Repository
{
    class CanzoneRepository : IRepository<Canzone>
    {
        static Autore a1 = new Autore("Pippo", "Neri", 1990);
        static Autore a2 = new Autore("Pluto", "Verdi", 1950);
        static List<Canzone> canzoni = new List<Canzone>()
        {
            new Canzone("TitoloCanzone1", a1, GenereEnum.Rock),
            new Canzone("TitoloCanzone2", a2, GenereEnum.Pop),
            new Canzone("TitoloCanzone3", new Autore("Minnie", "Rosa", 2000), GenereEnum.Classic)
        };

        public List<Canzone> Fetch()
        {
            return canzoni;
        }

        public List<Canzone> getByGenere(int genere)
        {
            var canzoniByGenere = from canzone in canzoni
                                  where (int)canzone.Genere == genere
                                  select canzone;
            return canzoniByGenere.ToList();
        }
    }
}
