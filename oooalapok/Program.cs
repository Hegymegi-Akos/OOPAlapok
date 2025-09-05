using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oooalapok
{
    public class Szemely
    {
        public string nev;
        private int kor;



        // Új konstruktor hozzáadva
        public Szemely(string nev, int kor)
        {
            this.nev = nev;
            this.Kor = kor;
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
                    throw new ArgumentOutOfRangeException(nameof(value), "Az életkor nem lehet negatív.");
                }

            }
        }
        public override string ToString()
        {
            return $"Név : {nev},Életkor :{Kor}";        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
           
            Szemely tanulo = new Szemely("Kiss Péter", 35);
          
            Console.WriteLine(tanulo);

       
        }
    }
}