using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day5
{
    class Canzone : FileMultimediale
    {
        public GenereEnum Genere { get; set; }

        public Canzone(string Titolo, Autore Author, GenereEnum Genere)
            :base(Titolo, Author)
        {
            this.Genere = Genere;
        }

        public override string Print()
        {
            return $"Canzone -> {base.Print()}, Genere: {Genere}";
        }
    }

    enum GenereEnum
    {
        Rock = 1,
        Pop = 2,
        Classic =3
    }
}
