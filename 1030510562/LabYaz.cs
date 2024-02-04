using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1030510562
{
    internal class LabYaz
    {
        public static void LabirentUret()
        {
            Random sayiGen = new Random();
            string[,] matris = new string[30, 30];
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    matris[i, j] = "1";
                }
            }
            int a = 0;
            int b = sayiGen.Next(0, 30);
            int yon;
            for (int k = 0; k < 3; k++)
            {
                while (a != 30)
                {
                    matris[b, a] = "0";
                    if(a == 0)
                    {
                        if (b == 0)//burada yon 0->assagi 1->sag
                        {
                            yon = sayiGen.Next(0, 2);
                            if (yon == 0)
                            {
                                b++;
                            }
                            else
                            {
                                a++;
                            }
                        }
                        else if (b == 29)//burada yon 0->yukari 1->sag
                        {
                            yon = sayiGen.Next(0, 2);
                            if (yon == 0)
                            {
                                b--;
                            }
                            else
                            {
                                a++;
                            }
                        }
                        else //burada yon 0->yukari 1->asagi 2-> sag
                        {
                            yon = sayiGen.Next(0, 4);
                            if (yon == 0)
                            {
                                b++;
                            }
                            else if (yon == 1)
                            {
                                b--;
                            }
                            else if (yon == 2)
                            {
                                a++;
                            }
                        }
                    }
                    else
                    {
                        if (b == 0)//burada yon 0->assagi 1->sag 
                        {
                            yon = sayiGen.Next(0, 2);
                            if (yon == 0)
                            {
                                b++;
                            }
                            else
                            {
                                a++;
                            }
                        }
                        else if (b == 29)//burada yon 0->yukari 1->sag
                        {
                            yon = sayiGen.Next(0, 2);
                            if (yon == 0)
                            {
                                b--;
                            }
                            else
                            {
                                a++;
                            }
                        }
                        else //burada yon 0->yukari 1->asagi 2-> sag 3->sol
                        {
                            yon = sayiGen.Next(0, 4);
                            if (yon == 0)
                            {
                                b++;
                            }
                            else if (yon == 1)
                            {
                                b--;
                            }
                            else if (yon == 2)
                            {
                                a++;
                            }
                            
                            else
                            {
                                a--;
                            }
                            
                        }
                    }

                }
            }
            int giris;
            int yol;
            for (int i = 0; i < 7; i++)
            {
                giris = sayiGen.Next(0, 30);
                matris[giris, 0] = "0";
            }
            for (giris = 0; giris < 30; giris++)
            {
                for (yol = 0; yol < 30; yol++)
                {
                    if (matris[giris, yol] == "1")
                    {
                        matris[giris, yol] = Convert.ToString(sayiGen.Next(0, 2));
                    }
                }
            }
            string dosyaAdi = "1030510562.txt";
            string dosyaYolu = @"c:\1030510562";
            string hedefYol = Path.Combine(dosyaYolu, dosyaAdi);
            FileStream dosyaIslem = File.Create(hedefYol);
            dosyaIslem.Close();
            StreamWriter yaz = new StreamWriter(hedefYol);

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (j == 0)
                    {
                        yaz.Write("{");
                        yaz.Write(matris[i, j]);
                        yaz.Write(",");
                    }
                    else if (j == 29)
                    {
                        yaz.Write(matris[i, j]);
                        yaz.Write("}");
                    }
                    else
                    {
                        yaz.Write(matris[i, j]);
                        yaz.Write(",");
                    }
                }
                yaz.Write("\n");
            }
            yaz.Close();
        }
    }
}
