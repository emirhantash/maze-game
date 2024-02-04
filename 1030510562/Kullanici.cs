using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1030510562
{
    internal class Kullanici
    {
        public static void Oyun()
        {
            Console.Title = "1030510562 Vize 2 Proje: Labirent";
            Console.WindowHeight = 50;
            Console.WindowWidth = 100;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vize 2 Proje\n");
            basla:
            Console.WriteLine("1.Labirent Oku ve Coz\n2.Labirent Uret\n\nLutfen bir islem seciniz...");
            int secim = Convert.ToInt32(Console.ReadLine());

            if (secim == 1)
            {
                Console.Clear();
                if (Bomba.BombaSesiVer() == true)
                {
                    Console.Clear();
                    Console.WriteLine("Bombaya carptiniz!");
                    goto bitir;
                }
                else
                {
                    goto bitir;
                }
            }
            else if (secim == 2)
            {
                LabYaz.LabirentUret();
                Console.WriteLine("Labirent uretildi. Cikmak istiyor musunuz?");
                Console.WriteLine("1. Evet");
                Console.WriteLine("2. Hayir");
                int secim2 = Convert.ToInt32(Console.ReadLine());
                switch (secim2)
                {
                    case 1:
                        goto bitir;
                    case 2:
                        goto basla;
                }
            }
            else
            {
                Console.WriteLine("404");
                goto bitir;
            }
            bitir:
            Console.WriteLine("Oyun Bitti.");
        } 
    }
}
