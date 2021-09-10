using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanugy
{
    public class SuliOsztaly
    {
        public List<Tanulo> Tanulok { get; set; }
        public List<Tanar> Tanarok { get; set; }
        public string Osztalynev { get; set; }

        public SuliOsztaly(List<Tanulo> tanulok, List<Tanar> tanarok, string osztalynev)
        {
            Tanulok = tanulok;
            Tanarok = tanarok;
            Osztalynev = osztalynev;
        }

        public void TanuloLista()
        {
            foreach (var i in Tanulok)
            {
                Console.WriteLine($"Név:{i.Nev},{i.SzuletesiEv}");
            }
        }

        public void TanarLista()
        {
            foreach (var i in Tanarok)
            {
                Console.WriteLine($"Név:{i.Nev},{i.Szak}");
            }
        }

       


    }
}
