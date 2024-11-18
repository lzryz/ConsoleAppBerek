using ConsoleAppBerek;
using System.Text;

List<Berek> dolgozo = new();

using StreamReader sr = new("..\\..\\..\\src\\berek2020.txt", Encoding.UTF8);
sr.ReadLine();
while (!sr.EndOfStream)
{
    dolgozo.Add(new(sr.ReadLine()));
}

Console.WriteLine("3. feladat: Dolgozok szama: " + dolgozo.Count);

double atlagber = dolgozo.Average(d => d.Ber) / 1000;
Console.WriteLine($"4. feladat: Berek atlaga: {atlagber:0.0} eFt");

Console.Write("5. feladat: Kerem a reszleg nevet: ");
string reszleg = Console.ReadLine();

var dolgozokReszlegen = dolgozo.Where(d => d.Reszleg.ToLower() == reszleg.ToLower()).ToList();
string nem;
if (dolgozokReszlegen.Count > 0)
{
    var legnagyobbBer = dolgozokReszlegen.OrderByDescending(d => d.Ber).First();
    Console.WriteLine("6. feladat: A legtobbet kereso dolgozo a megadott reszlegen");
    if (legnagyobbBer.Neme){nem = "férfi";}
    else{nem = "nő";}
    Console.WriteLine($"Nev: {legnagyobbBer.Nev}\nNem: {nem}\nBelepes: {legnagyobbBer.Belepes}\nBer: {legnagyobbBer.Ber} Forint");
}
else
{
    Console.WriteLine("6. feladat: A megadott reszleg nem letezik a cegnel");
}

Console.WriteLine("7. feladat: Statisztika");

var reszlegStatisztika = dolgozo.GroupBy(d => d.Reszleg).Select(g => new{Reszleg=g.Key, Szam=g.Count()}).OrderBy(g => g.Reszleg);

foreach (var reszlegstat in reszlegStatisztika)
{
    Console.WriteLine($"{reszlegstat.Reszleg} - {reszlegstat.Szam} fő");
}
