namespace Week3Day5
{
    public class Autore
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int AnnoNascita { get; set; }

        public Autore() { }

        public Autore(string Nome, string Cognome, int AnnoNascita)
        {
            this.Nome = Nome;
            this.Cognome = Cognome;
            this.AnnoNascita = AnnoNascita;
        }
    }
}