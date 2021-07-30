using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Day5
{
     abstract class FileMultimediale
    {
        public string Titolo { get; set; }
        public Autore Author { get; set; }

        public FileMultimediale()
        {

        }

        public FileMultimediale(string Titolo, Autore Author)
        {
            this.Titolo = Titolo;
            this.Author = Author;
        }

        public virtual string Print()
        {
            return $"Titolo:  {Titolo}, Autore: {Author.Nome} {Author.Cognome} - {Author.AnnoNascita}";
        }
    }
}
