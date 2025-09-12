using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oooalapok
{
    public class Szemely
    {
        protected string nev; // Védett adattag
        private int kor;

        public Szemely(string nev, int kor)
        {
            this.nev = nev;
            this.Kor = kor;
        }

        // Publikus property a nev eléréséhez
        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }

        public int Kor
        {
            get { return kor; }
            set
            {
                if (value >= 0)
                {
                    kor = value;
                }
                else
                {
                    Console.WriteLine("Hiba: Az életkor nem lehet negatív!");
                    return;
                }
            }
        }

        // Virtuális metódus polimorfizmushoz
        public virtual void Bemutatkozas()
        {
            Console.WriteLine($"Én {nev} vagyok, {Kor} éves.");
        }

        public override string ToString()
        {
            return $"Név: {nev}, Életkor: {Kor}";
        }
    }

    public class Hallgato : Szemely
    {
        private string neptunKod;

        public Hallgato(string nev, int kor, string neptunKod) : base(nev, kor)
        {
            this.NeptunKod = neptunKod;
        }

        public string NeptunKod
        {
            get { return neptunKod; }
            set
            {
                if (value.Length <= 6)
                {
                    neptunKod = value;
                }
                else
                {
                    Console.WriteLine("Hiba: A Neptun kód nem lehet hosszabb 6 karakternél!");
                    return;
                }
            }
        }

        // Polimorfizmus: a Bemutatkozas metódus felülírása
        public override void Bemutatkozas()
        {
            Console.WriteLine($"Én {nev} vagyok, {Kor} éves hallgató, Neptun kódom: {NeptunKod}.");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Neptun kód: {NeptunKod}";
        }
    }

    public class Dolgozo : Szemely
    {
        private decimal ber;

        public Dolgozo(string nev, int kor, decimal ber) : base(nev, kor)
        {
            this.Ber = ber;
        }

        public decimal Ber
        {
            get { return ber; }
            set
            {
                if (value >= 0)
                {
                    ber = value;
                }
                else
                {
                    Console.WriteLine("Hiba: A bér nem lehet negatív!");
                    return;
                }
            }
        }

        // Polimorfizmus: a Bemutatkozas metódus felülírása
        public override void Bemutatkozas()
        {
            Console.WriteLine($"Én {nev} vagyok, {Kor} éves dolgozó, bérem: {Ber:C}.");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Bér: {Ber:C}";
        }
    }

    public class BankSzamla
    {
        private decimal egyenleg;

        public BankSzamla(decimal kezdoEgyenleg)
        {
            if (kezdoEgyenleg < 0)
            {
                Console.WriteLine("Hiba: A kezdő egyenleg nem lehet negatív!");
                return;
            }
            this.egyenleg = kezdoEgyenleg;
        }

        public decimal Egyenleg
        {
            get { return egyenleg; }
            private set
            {
                if (value < 0)
                {
                    Console.WriteLine("Hiba: Az egyenleg nem lehet negatív!");
                    return;
                }
                egyenleg = value;
            }
        }

        public void Betesz(decimal osszeg)
        {
            if (osszeg <= 0)
            {
                Console.WriteLine("Hiba: A betét összegének pozitívnak kell lennie!");
                return;
            }
            Egyenleg += osszeg;
        }

        public void Kivesz(decimal osszeg)
        {
            if (osszeg <= 0)
            {
                Console.WriteLine("Hiba: A kivett összegnek pozitívnak kell lennie!");
                return;
            }
            if (egyenleg < osszeg)
            {
                Console.WriteLine("Hiba: Nincs elegendő egyenleg a kivételhez!");
                return;
            }
            Egyenleg -= osszeg;
        }

        public override string ToString()
        {
            return $"Egyenleg: {egyenleg:C}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Személy példányosítás
            Szemely tanulo = new Szemely("Kiss Péter", 35);
            Console.WriteLine(tanulo);

            // Bankszámla példányosítás és műveletek
            BankSzamla szamla = new BankSzamla(10000);
            Console.WriteLine(szamla);

            szamla.Betesz(5000);
            Console.WriteLine($"Befizetés után: {szamla}");

            szamla.Kivesz(3000);
            Console.WriteLine($"Kivétel után: {szamla}");

            szamla.Kivesz(20000);

            // Hallgatók lista létrehozása
            List<Hallgato> hallgatok = new List<Hallgato>
            {
                new Hallgato("Nagy Anna", 20, "ABC123"),
                new Hallgato("Kis Béla", 22, "XYZ789"),
                new Hallgato("Tóth Eszter", 19, "QWE456")
            };

            // Hallgatók nevének kiírása a Nev property-n keresztül
            Console.WriteLine("\nHallgatók nevei:");
            foreach (var hallgato in hallgatok)
            {
                Console.WriteLine(hallgato.Nev); // A Nev property használata
            }

            // Polimorfizmus demonstrálása
            Console.WriteLine("\nBemutatkozások:");
            List<Szemely> szemelyek = new List<Szemely>
            {
                new Hallgato("Szabó Katalin", 21, "DEF456"),
                new Dolgozo("Kovács János", 40, 300000)
            };

            foreach (var szemely in szemelyek)
            {
                szemely.Bemutatkozas();
            }
        }
    }
}