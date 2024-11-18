namespace ConsoleAppBerek;
internal class Berek
{
    public string Nev { get; set; }
    public bool Neme { get; set; }
    public string Reszleg { get; set; }
    public int Belepes { get; set; }
    public int Ber { get; set; }

    public Berek(string sor) {
        string[] v = sor.Split(';');
        Nev = v[0];
        Neme = v[1] == "férfi";
        Reszleg = v[2];
        Belepes = int.Parse(v[3]);
        Ber = int.Parse(v[4]);
    }
            
}
