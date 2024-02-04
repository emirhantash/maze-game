using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1030510562
{
    internal class Bomba
    {
        public static string[] bombaSatir = new string[3];
        public static string[] bombaSutun = new string[3];
        public static string[,] BombaUret()
        {
            
            string[,] bombali = LabCoz.LabirentOku();
            Random sayiGen = new Random();
            for (int i = 0; i < 3; i++)
            {
                int a = sayiGen.Next(0, 30);
                string satir = Convert.ToString(a);
                int b = sayiGen.Next(0, 30);
                string sutun = Convert.ToString(b);
                bombali[a, b] = "B";
                bombaSatir[i] = satir;
                bombaSutun[i] = sutun;
            }
            return bombali;
        }
        public static bool BombaSesiVer()
        {
            if (LabCoz.LabirentCozum() == true)
            {
                Console.Beep(100, 850);
                return true;
            }
            return false;
        }
    }
}
