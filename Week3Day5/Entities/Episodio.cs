using System;

namespace Week3Day5
{
    public class Episodio
    {
        public string Titolo { get; set; }
        public TimeSpan Durata { get; set; }
        bool IsListened { get; set; }

        public Episodio(string Titolo, TimeSpan Durata, bool IsListened)
        {
            this.Titolo = Titolo;
            this.Durata = Durata;
            this.IsListened = IsListened;
        }
    }
}