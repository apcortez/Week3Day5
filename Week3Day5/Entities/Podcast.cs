using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day5
{
    class Podcast : FileMultimediale
    {
        public string Descrizione { get; set; }
        public Dictionary<string, Episodio> Episodi { get; set; }

        public Podcast(string Titolo, Autore Author, string Descrizione, Dictionary<string, Episodio> Episodi)
            :base(Titolo, Author)
        {
            this.Descrizione = Descrizione;
            this.Episodi = Episodi;
        }

        public override string Print()
        {
            return $"Canzone -> {base.Print()}, Descrizione: {Descrizione}";
        }

    }
}
