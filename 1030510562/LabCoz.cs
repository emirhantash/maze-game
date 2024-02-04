using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _1030510562
{
    internal class LabCoz
    {
        public static string[,] LabirentOku()
        {
            string dosyaYolu = @"c:\1030510562\1030510562.txt";
            string metin = System.IO.File.ReadAllText(dosyaYolu);
            char[] fazlalik = { '{', '}', ',', ' ', '\n', '\r' };
            string[] kabaLabirent = metin.Split(fazlalik, StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine("{0}", kabaLabirent.Length);
            string[,] labirentMatris = new string[30, 30];
            int k = 0;
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    labirentMatris[i, j] = kabaLabirent[k];
                    k++;
                }
            }
            return labirentMatris;
        } 
        public static bool LabirentCozum()
        {
            int sayac = 0;
            LabCoz:
            sayac++;
            Console.Clear();
            string[,] bombaliLabirent = Bomba.BombaUret();
            int xPos = 0;
            int yPos = sayac - 1;
            bool bomba = false;
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.Write(bombaliLabirent[i, j]);
                }
                Console.Write("\n");
            }
            Console.SetCursorPosition(xPos, yPos);
            Console.Write("=");
            Thread.Sleep(15);
            while (xPos != 29 && yPos != 30 &&bomba == false)//en saga gelmedi ise ve bombaya rastlamadi ise
            {
                if (xPos == 0)//en solda ise
                {
                    if (yPos == 0)//en yukarda ise
                    {
                        if (bombaliLabirent[yPos, xPos + 1] == "0" || bombaliLabirent[yPos, xPos + 1] == "B")//saga bak
                        {
                            xPos++;
                            if (bombaliLabirent[yPos, xPos] == "B")
                            {
                                bomba = true;
                            }
                            bombaliLabirent[yPos, xPos] = "=";
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("=");
                            Thread.Sleep(15);
                        }
                        else if (bombaliLabirent[yPos + 1, xPos] == "0" || bombaliLabirent[yPos + 1, xPos] == "B")//asagi bak
                        {
                            yPos++;
                            if (bombaliLabirent[yPos, xPos] == "B")
                            {
                                bomba = true;
                            }
                            bombaliLabirent[yPos, xPos] = "=";
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("=");
                            Thread.Sleep(15);
                        }
                        else
                        {
                            if (bombaliLabirent[yPos + 1, xPos] == "=")//asagi bak
                            {
                                yPos++;
                                bombaliLabirent[yPos, xPos] = "*";
                                Console.SetCursorPosition(xPos, yPos);
                                Console.Write("*");
                                Thread.Sleep(15);
                            }
                            else if (bombaliLabirent[yPos, xPos + 1] == "=")//saga bak
                            {
                                xPos++;
                                bombaliLabirent[yPos, xPos] = "*";
                                Console.SetCursorPosition(xPos, yPos);
                                Console.Write("*");
                                Thread.Sleep(15);
                            }
                            
                            else
                            {
                                if (bombaliLabirent[yPos, xPos + 1] == "*")//saga bak
                                {
                                    xPos++;
                                    bombaliLabirent[yPos, xPos] = "/";
                                    Console.SetCursorPosition(xPos, yPos);
                                    Console.Write("/");
                                    Thread.Sleep(15);
                                }
                                else if (bombaliLabirent[yPos + 1, xPos] == "*")//asagi bak
                                {
                                    yPos++;
                                    bombaliLabirent[yPos, xPos] = "/";
                                    Console.SetCursorPosition(xPos, yPos);
                                    Console.Write("/");
                                    Thread.Sleep(15);
                                }
                                else
                                {
                                    if (bombaliLabirent[yPos + 1, xPos] == "/")//asagi bak
                                    {
                                        yPos++;
                                        bombaliLabirent[yPos, xPos] = "?";
                                        Console.SetCursorPosition(xPos, yPos);
                                        Console.Write("?");
                                        Thread.Sleep(15);
                                    }
                                    else if (bombaliLabirent[yPos, xPos + 1] == "/")//saga bak
                                    {
                                        xPos++;
                                        bombaliLabirent[yPos, xPos] = "?";
                                        Console.SetCursorPosition(xPos, yPos);
                                        Console.Write("?");
                                        Thread.Sleep(15);
                                    }
                                    else
                                    {
                                        if (bombaliLabirent[yPos, xPos + 1] == "?")//saga bak
                                        {
                                            xPos++;
                                            bombaliLabirent[yPos, xPos] = "-";
                                            Console.SetCursorPosition(xPos, yPos);
                                            Console.Write("-");
                                            Thread.Sleep(15);
                                        }
                                        if (bombaliLabirent[yPos + 1, xPos] == "?")//asagi bak
                                        {
                                            yPos++;
                                            bombaliLabirent[yPos, xPos] = "-";
                                            Console.SetCursorPosition(xPos, yPos);
                                            Console.Write("-");
                                            Thread.Sleep(15);
                                        }
                                        
                                        else
                                        {
                                            goto LabCoz;
                                        }   
                                    }
                                }
                            }
                        }
                    }
                    else if (yPos == 29)//en altta ise
                    {
                        if (bombaliLabirent[yPos, xPos + 1] == "0" || bombaliLabirent[yPos, xPos + 1] == "B")//saga bak
                        {
                            xPos++;
                            if (bombaliLabirent[yPos, xPos] == "B")
                            {
                                bomba = true;
                            }
                            bombaliLabirent[yPos, xPos] = "=";
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("=");
                            Thread.Sleep(15);
                        }
                        else if (bombaliLabirent[yPos - 1, xPos] == "0" || bombaliLabirent[yPos - 1, xPos] == "B")//yukari bak
                        {
                            yPos--;
                            if (bombaliLabirent[yPos, xPos] == "B")
                            {
                                bomba = true;
                            }
                            bombaliLabirent[yPos, xPos] = "=";
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("=");
                            Thread.Sleep(15);
                        }
                        else
                        {
                            if (bombaliLabirent[yPos - 1, xPos] == "=")//yukari bak
                            {
                                yPos--;
                                bombaliLabirent[yPos, xPos] = "*";
                                Console.SetCursorPosition(xPos, yPos);
                                Console.Write("*");
                                Thread.Sleep(15);
                            }
                            else if (bombaliLabirent[yPos, xPos + 1] == "=")//saga bak
                            {
                                xPos++;
                                bombaliLabirent[yPos, xPos] = "*";
                                Console.SetCursorPosition(xPos, yPos);
                                Console.Write("*");
                                Thread.Sleep(15);
                            }
                            
                            else
                            {
                                if (bombaliLabirent[yPos, xPos + 1] == "*")//saga bak
                                {
                                    xPos++;
                                    bombaliLabirent[yPos, xPos] = "/";
                                    Console.SetCursorPosition(xPos, yPos);
                                    Console.Write("/");
                                    Thread.Sleep(15);
                                }
                                else if (bombaliLabirent[yPos - 1, xPos] == "*")//yukari bak
                                {
                                    yPos--;
                                    bombaliLabirent[yPos, xPos] = "/";
                                    Console.SetCursorPosition(xPos, yPos);
                                    Console.Write("/");
                                    Thread.Sleep(15);
                                }
                                else
                                {
                                    if (bombaliLabirent[yPos - 1, xPos] == "/")//yukari bak
                                    {
                                        yPos--;
                                        bombaliLabirent[yPos, xPos] = "?";
                                        Console.SetCursorPosition(xPos, yPos);
                                        Console.Write("?");
                                        Thread.Sleep(15);
                                    }
                                    else if (bombaliLabirent[yPos, xPos + 1] == "/")//saga bak
                                    {
                                        xPos++;
                                        bombaliLabirent[yPos, xPos] = "?";
                                        Console.SetCursorPosition(xPos, yPos);
                                        Console.Write("?");
                                        Thread.Sleep(15);
                                    }
                                    else
                                    {
                                        if (bombaliLabirent[yPos, xPos + 1] == "?")//saga bak
                                        {
                                            xPos++;
                                            bombaliLabirent[yPos, xPos] = "-";
                                            Console.SetCursorPosition(xPos, yPos);
                                            Console.Write("-");
                                            Thread.Sleep(15);
                                        }
                                        else if (bombaliLabirent[yPos - 1, xPos] == "?")//yukari bak
                                        {
                                            yPos--;
                                            bombaliLabirent[yPos, xPos] = "-";
                                            Console.SetCursorPosition(xPos, yPos);
                                            Console.Write("-");
                                            Thread.Sleep(15);
                                        }
                                        else
                                        {
                                            goto LabCoz;
                                        }  
                                    }   
                                }
                            }
                        }
                    }
                    else//en yukarda veya en asagida degil ise
                    {
                        if (bombaliLabirent[yPos, xPos + 1] == "0" || bombaliLabirent[yPos, xPos + 1] == "B")//saga bak
                        {
                            xPos++;
                            if (bombaliLabirent[yPos, xPos] == "B")
                            {
                                bomba = true;
                            }
                            bombaliLabirent[yPos, xPos] = "=";
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("=");
                            Thread.Sleep(15);
                        }
                        else if (bombaliLabirent[yPos - 1, xPos] == "0" || bombaliLabirent[yPos - 1, xPos] == "B")//yukari bak
                        {
                            yPos--;
                            if (bombaliLabirent[yPos, xPos] == "B")
                            {
                                bomba = true;
                            }
                            bombaliLabirent[yPos, xPos] = "=";
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("=");
                            Thread.Sleep(15);
                        }
                        else if (bombaliLabirent[yPos + 1, xPos] == "0" || bombaliLabirent[yPos + 1, xPos] == "B")//asagi bak
                        {
                            yPos++;
                            if (bombaliLabirent[yPos, xPos] == "B")
                            {
                                bomba = true;
                            }
                            bombaliLabirent[yPos, xPos] = "=";
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("=");
                            Thread.Sleep(15);
                        }
                        else
                        {
                            if (bombaliLabirent[yPos + 1, xPos] == "=")//asagi bak
                            {
                                yPos++;
                                bombaliLabirent[yPos, xPos] = "*";
                                Console.SetCursorPosition(xPos, yPos);
                                Console.Write("*");
                                Thread.Sleep(15);
                            }
                            else if (bombaliLabirent[yPos - 1, xPos] == "=")//yukari bak
                            {
                                yPos--;
                                bombaliLabirent[yPos, xPos] = "=";
                                Console.SetCursorPosition(xPos, yPos);
                                Console.Write("*");
                                Thread.Sleep(15);
                            }
                            else if (bombaliLabirent[yPos, xPos + 1] == "=")//saga bak
                            {
                                xPos++;
                                bombaliLabirent[yPos, xPos] = "*";
                                Console.SetCursorPosition(xPos, yPos);
                                Console.Write("*");
                                Thread.Sleep(15);
                            } 
                            else
                            {
                                if (bombaliLabirent[yPos, xPos + 1] == "*")//saga bak
                                {
                                    xPos++;
                                    bombaliLabirent[yPos, xPos] = "/";
                                    Console.SetCursorPosition(xPos, yPos);
                                    Console.Write("/");
                                    Thread.Sleep(15);
                                }
                                else if (bombaliLabirent[yPos - 1, xPos] == "*")//yukari bak
                                {
                                    yPos--;
                                    bombaliLabirent[yPos, xPos] = "/";
                                    Console.SetCursorPosition(xPos, yPos);
                                    Console.Write("/");
                                    Thread.Sleep(15);
                                }
                                else if (bombaliLabirent[yPos + 1, xPos] == "*")//asagi bak
                                {
                                    yPos++;
                                    bombaliLabirent[yPos, xPos] = "/";
                                    Console.SetCursorPosition(xPos, yPos);
                                    Console.Write("/");
                                    Thread.Sleep(15);
                                } 
                                else
                                {
                                    if (bombaliLabirent[yPos + 1, xPos] == "/")//asagi bak
                                    {
                                        yPos++;
                                        bombaliLabirent[yPos, xPos] = "?";
                                        Console.SetCursorPosition(xPos, yPos);
                                        Console.Write("?");
                                        Thread.Sleep(15);
                                    }
                                    else if (bombaliLabirent[yPos - 1, xPos] == "/")//yukari bak
                                    {
                                        yPos--;
                                        bombaliLabirent[yPos, xPos] = "?";
                                        Console.SetCursorPosition(xPos, yPos);
                                        Console.Write("?");
                                        Thread.Sleep(15);
                                    }
                                    else if (bombaliLabirent[yPos, xPos + 1] == "/")//saga bak
                                    {
                                        xPos++;
                                        bombaliLabirent[yPos, xPos] = "?";
                                        Console.SetCursorPosition(xPos, yPos);
                                        Console.Write("?");
                                        Thread.Sleep(15);
                                    }
                                    else
                                    {
                                        if (bombaliLabirent[yPos, xPos + 1] == "?")//saga bak
                                        {
                                            xPos++;
                                            bombaliLabirent[yPos, xPos] = "-";
                                            Console.SetCursorPosition(xPos, yPos);
                                            Console.Write("-");
                                            Thread.Sleep(15);
                                        }
                                        else if (bombaliLabirent[yPos - 1, xPos] == "?")//yukari bak
                                        {
                                            yPos--;
                                            bombaliLabirent[yPos, xPos] = "-";
                                            Console.SetCursorPosition(xPos, yPos);
                                            Console.Write("-");
                                            Thread.Sleep(15);
                                        }
                                        else if (bombaliLabirent[yPos + 1, xPos] == "?")//asagi bak
                                        {
                                            yPos++;
                                            bombaliLabirent[yPos, xPos] = "-";
                                            Console.SetCursorPosition(xPos, yPos);
                                            Console.Write("-");
                                            Thread.Sleep(15);
                                        }
                                        else
                                        {
                                            goto LabCoz;
                                        } 
                                    } 
                                }
                            }
                        }
                    }
                }
                else if (xPos != 0)//en solda degil ise
                {
                    if (yPos == 0)//en yukarda ise
                    {
                        if (bombaliLabirent[yPos, xPos + 1] == "0" || bombaliLabirent[yPos, xPos + 1] == "B")//saga bak
                        {
                            xPos++;
                            if (bombaliLabirent[yPos, xPos] == "B")
                            {
                                bomba = true;
                            }
                            bombaliLabirent[yPos, xPos] = "=";
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("=");
                            Thread.Sleep(15);
                        }
                        else if (bombaliLabirent[yPos + 1, xPos] == "0" || bombaliLabirent[yPos + 1, xPos] == "B")//asagi bak
                        {
                            yPos++;
                            if (bombaliLabirent[yPos, xPos] == "B")
                            {
                                bomba = true;
                            }
                            bombaliLabirent[yPos, xPos] = "=";
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("=");
                            Thread.Sleep(15);
                        }

                        else if (bombaliLabirent[yPos, xPos - 1] == "0" || bombaliLabirent[yPos, xPos - 1] == "B")//sola bak
                        {
                            xPos--;
                            if (bombaliLabirent[yPos, xPos] == "B")
                            {
                                bomba = true;
                            }
                            bombaliLabirent[yPos, xPos] = "=";
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("=");
                            Thread.Sleep(15);
                        }
                        else//geri don
                        {
                            if (bombaliLabirent[yPos, xPos - 1] == "=")//sola bak
                            {
                                xPos--;
                                bombaliLabirent[yPos, xPos] = "*";
                                Console.SetCursorPosition(xPos, yPos);
                                Console.Write("*");
                                Thread.Sleep(15);
                            }
                            else if (bombaliLabirent[yPos + 1, xPos] == "=")//asagi bak
                            {
                                yPos++;
                                bombaliLabirent[yPos, xPos] = "*";
                                Console.SetCursorPosition(xPos, yPos);
                                Console.Write("*");
                                Thread.Sleep(15);
                            }
                            else if (bombaliLabirent[yPos, xPos + 1] == "=")//saga bak
                            {
                                xPos++;
                                bombaliLabirent[yPos, xPos] = "*";
                                Console.SetCursorPosition(xPos, yPos);
                                Console.Write("*");
                                Thread.Sleep(15);
                            }
                            else
                            {
                                if (bombaliLabirent[yPos, xPos + 1] == "*")//saga bak
                                {
                                    xPos++;
                                    bombaliLabirent[yPos, xPos] = "/";
                                    Console.SetCursorPosition(xPos, yPos);
                                    Console.Write("/");
                                    Thread.Sleep(15);
                                }
                                else if (bombaliLabirent[yPos + 1, xPos] == "*")//asagi bak
                                {
                                    yPos++;
                                    bombaliLabirent[yPos, xPos] = "/";
                                    Console.SetCursorPosition(xPos, yPos);
                                    Console.Write("/");
                                    Thread.Sleep(15);
                                }
                                else if (bombaliLabirent[yPos, xPos - 1] == "*")//sola bak
                                {
                                    xPos--;
                                    bombaliLabirent[yPos, xPos] = "/";
                                    Console.SetCursorPosition(xPos, yPos);
                                    Console.Write("/");
                                    Thread.Sleep(15);
                                }                   
                                else
                                {
                                    if (bombaliLabirent[yPos, xPos - 1] == "/")//sola bak
                                    {
                                        xPos--;
                                        bombaliLabirent[yPos, xPos] = "?";
                                        Console.SetCursorPosition(xPos, yPos);
                                        Console.Write("?");
                                        Thread.Sleep(15);
                                    }
                                    else if (bombaliLabirent[yPos + 1, xPos] == "/")//asagi bak
                                    {
                                        yPos++;
                                        bombaliLabirent[yPos, xPos] = "?";
                                        Console.SetCursorPosition(xPos, yPos);
                                        Console.Write("?");
                                        Thread.Sleep(15);
                                    }
                                    else if (bombaliLabirent[yPos, xPos + 1] == "/")//saga bak
                                    {
                                        xPos++;
                                        bombaliLabirent[yPos, xPos] = "?";
                                        Console.SetCursorPosition(xPos, yPos);
                                        Console.Write("?");
                                        Thread.Sleep(15);
                                    }
                                    else
                                    {
                                        if (bombaliLabirent[yPos, xPos + 1] == "?")//saga bak
                                        {
                                            xPos++;
                                            bombaliLabirent[yPos, xPos] = "-";
                                            Console.SetCursorPosition(xPos, yPos);
                                            Console.Write("-");
                                            Thread.Sleep(15);
                                        }
                                        else if (bombaliLabirent[yPos + 1, xPos] == "?")//asagi bak
                                        {
                                            yPos++;
                                            bombaliLabirent[yPos, xPos] = "-";
                                            Console.SetCursorPosition(xPos, yPos);
                                            Console.Write("-");
                                            Thread.Sleep(15);
                                        }
                                        else if (bombaliLabirent[yPos, xPos - 1] == "?")//sola bak
                                        {
                                            xPos--;
                                            bombaliLabirent[yPos, xPos] = "-";
                                            Console.SetCursorPosition(xPos, yPos);
                                            Console.Write("-");
                                            Thread.Sleep(15);
                                        }
                                        else
                                        {
                                            goto LabCoz;
                                        }
                                    }  
                                }
                            }

                        }
                    }
                    else if (yPos == 29)//en altta ise
                    {
                        if (bombaliLabirent[yPos, xPos + 1] == "0" || bombaliLabirent[yPos, xPos + 1] == "B")//saga bak
                        {
                            xPos++;
                            if (bombaliLabirent[yPos, xPos] == "B")
                            {
                                bomba = true;
                            }
                            bombaliLabirent[yPos, xPos] = "=";
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("=");
                            Thread.Sleep(15);
                        }
                        else if (bombaliLabirent[yPos - 1, xPos] == "0" || bombaliLabirent[yPos - 1, xPos] == "B")//yukari bak
                        {
                            yPos--;
                            if (bombaliLabirent[yPos, xPos] == "B")
                            {
                                bomba = true;
                            }
                            bombaliLabirent[yPos, xPos] = "=";
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("=");
                            Thread.Sleep(15);
                        }

                        else if (bombaliLabirent[yPos, xPos - 1] == "0" || bombaliLabirent[yPos, xPos - 1] == "B")//sola bak
                        {
                            xPos--;
                            if (bombaliLabirent[yPos, xPos] == "B")
                            {
                                bomba = true;
                            }
                            bombaliLabirent[yPos, xPos] = "=";
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("=");
                            Thread.Sleep(15);
                        }
                        else//geri don
                        {
                            if (bombaliLabirent[yPos, xPos - 1] == "=")//sola bak
                            {
                                xPos--;
                                bombaliLabirent[yPos, xPos] = "*";
                                Console.SetCursorPosition(xPos, yPos);
                                Console.Write("*");
                                Thread.Sleep(15);
                            }
                            else if (bombaliLabirent[yPos - 1, xPos] == "=")//yukari bak
                            {
                                yPos--;
                                bombaliLabirent[yPos, xPos] = "*";
                                Console.SetCursorPosition(xPos, yPos);
                                Console.Write("*");
                                Thread.Sleep(15);
                            }
                            else if (bombaliLabirent[yPos, xPos + 1] == "=")//saga bak
                            {
                                xPos++;
                                bombaliLabirent[yPos, xPos] = "*";
                                Console.SetCursorPosition(xPos, yPos);
                                Console.Write("*");
                                Thread.Sleep(15);
                            }
                                               
                            else
                            {
                                if (bombaliLabirent[yPos, xPos + 1] == "*")//saga bak
                                {
                                    xPos++;
                                    bombaliLabirent[yPos, xPos] = "/";
                                    Console.SetCursorPosition(xPos, yPos);
                                    Console.Write("/");
                                    Thread.Sleep(15);
                                }
                                else if (bombaliLabirent[yPos - 1, xPos] == "*")//yukari bak
                                {
                                    yPos--;
                                    bombaliLabirent[yPos, xPos] = "/";
                                    Console.SetCursorPosition(xPos, yPos);
                                    Console.Write("/");
                                    Thread.Sleep(15);
                                }
                                else if (bombaliLabirent[yPos, xPos - 1] == "*")//sola bak
                                {
                                    xPos--;
                                    bombaliLabirent[yPos, xPos] = "/";
                                    Console.SetCursorPosition(xPos, yPos);
                                    Console.Write("/");
                                    Thread.Sleep(15);
                                }
                                else
                                {
                                    if (bombaliLabirent[yPos, xPos - 1] == "/")//sola bak
                                    {
                                        xPos--;
                                        bombaliLabirent[yPos, xPos] = "?";
                                        Console.SetCursorPosition(xPos, yPos);
                                        Console.Write("?");
                                        Thread.Sleep(15);
                                    }
                                    else if (bombaliLabirent[yPos - 1, xPos] == "/")//yukari bak
                                    {
                                        yPos--;
                                        bombaliLabirent[yPos, xPos] = "?";
                                        Console.SetCursorPosition(xPos, yPos);
                                        Console.Write("?");
                                        Thread.Sleep(15);
                                    }
                                    else if (bombaliLabirent[yPos, xPos + 1] == "/")//saga bak
                                    {
                                        xPos++;
                                        bombaliLabirent[yPos, xPos] = "?";
                                        Console.SetCursorPosition(xPos, yPos);
                                        Console.Write("?");
                                        Thread.Sleep(15);
                                    }
                                    else
                                    {
                                        if (bombaliLabirent[yPos, xPos + 1] == "?")//saga bak
                                        {
                                            xPos++;
                                            bombaliLabirent[yPos, xPos] = "-";
                                            Console.SetCursorPosition(xPos, yPos);
                                            Console.Write("-");
                                            Thread.Sleep(15);
                                        }
                                        else if (bombaliLabirent[yPos - 1, xPos] == "?")//yukari bak
                                        {
                                            yPos--;
                                            bombaliLabirent[yPos, xPos] = "-";
                                            Console.SetCursorPosition(xPos, yPos);
                                            Console.Write("-");
                                            Thread.Sleep(15);
                                        }
                                        else if (bombaliLabirent[yPos, xPos - 1] == "?")//sola bak
                                        {
                                            xPos--;
                                            bombaliLabirent[yPos, xPos] = "-";
                                            Console.SetCursorPosition(xPos, yPos);
                                            Console.Write("?");
                                            Thread.Sleep(15);
                                        }
                                        else
                                        {
                                            goto LabCoz;
                                        }
                                    }     
                                }
                            }

                        }
                    }
                    else//en solda değil ve en yukarda veya en asagida degil ise
                    {
                        if (bombaliLabirent[yPos, xPos + 1] == "0" || bombaliLabirent[yPos, xPos + 1] == "B")//saga bak
                        {
                            xPos++;
                            if (bombaliLabirent[yPos, xPos] == "B")
                            {
                                bomba = true;
                            }
                            bombaliLabirent[yPos, xPos] = "=";
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("=");
                            Thread.Sleep(15);
                        }
                        else if (bombaliLabirent[yPos - 1, xPos] == "0" || bombaliLabirent[yPos - 1, xPos] == "B")//yukari bak
                        {
                            yPos--;
                            if (bombaliLabirent[yPos, xPos] == "B")
                            {
                                bomba = true;
                            }
                            bombaliLabirent[yPos, xPos] = "=";
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("=");
                            Thread.Sleep(15);
                        }
                        else if (bombaliLabirent[yPos + 1, xPos] == "0" || bombaliLabirent[yPos + 1, xPos] == "B")//asagi bak
                        {
                            yPos++;
                            if (bombaliLabirent[yPos, xPos] == "B")
                            {
                                bomba = true;
                            }
                            bombaliLabirent[yPos, xPos] = "=";
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("=");
                            Thread.Sleep(15);
                        }
                        else if (bombaliLabirent[yPos, xPos - 1] == "0" || bombaliLabirent[yPos, xPos - 1] == "B")//sola bak
                        {
                            xPos--;
                            if (bombaliLabirent[yPos, xPos] == "B")
                            {
                                bomba = true;
                            }
                            bombaliLabirent[yPos, xPos] = "=";
                            Console.SetCursorPosition(xPos, yPos);
                            Console.Write("=");
                            Thread.Sleep(15);
                        }
                        else//en yukarıda veya en asagida degil ve etrafinda hic 0 yoksa
                        {
                            if (bombaliLabirent[yPos, xPos - 1] == "=")//sola bak
                            {
                                xPos--;
                                bombaliLabirent[yPos, xPos] = "*";
                                Console.SetCursorPosition(xPos, yPos);
                                Console.Write("*");
                                Thread.Sleep(15);
                            }
                            else if (bombaliLabirent[yPos + 1, xPos] == "=")//asagi bak
                            {
                                yPos++;
                                bombaliLabirent[yPos, xPos] = "*";
                                Console.SetCursorPosition(xPos, yPos);
                                Console.Write("*");
                                Thread.Sleep(15);
                            }
                            else if (bombaliLabirent[yPos - 1, xPos] == "=")//yukari bak
                            {
                                yPos--;
                                bombaliLabirent[yPos, xPos] = "*";
                                Console.SetCursorPosition(xPos, yPos);
                                Console.Write("*");
                                Thread.Sleep(15);
                            }
                            else if (bombaliLabirent[yPos, xPos + 1] == "=")//saga bak
                            {
                                xPos++;
                                bombaliLabirent[yPos, xPos] = "*";
                                Console.SetCursorPosition(xPos, yPos);
                                Console.Write("*");
                                Thread.Sleep(15);
                            }
                            else
                            {
                                if (bombaliLabirent[yPos, xPos + 1] == "*")//saga bak
                                {
                                    xPos++;
                                    bombaliLabirent[yPos, xPos] = "/";
                                    Console.SetCursorPosition(xPos, yPos);
                                    Console.Write("/");
                                    Thread.Sleep(15);
                                }
                                else if (bombaliLabirent[yPos - 1, xPos] == "*")//yukari bak
                                {
                                    yPos--;
                                    bombaliLabirent[yPos, xPos] = "/";
                                    Console.SetCursorPosition(xPos, yPos);
                                    Console.Write("/");
                                    Thread.Sleep(15);
                                }
                                else if (bombaliLabirent[yPos + 1, xPos] == "*")//asagi bak
                                {
                                    yPos++;
                                    bombaliLabirent[yPos, xPos] = "/";
                                    Console.SetCursorPosition(xPos, yPos);
                                    Console.Write("/");
                                    Thread.Sleep(15);
                                }
                                else if (bombaliLabirent[yPos, xPos - 1] == "*")//sola bak
                                {
                                    xPos--;
                                    bombaliLabirent[yPos, xPos] = "/";
                                    Console.SetCursorPosition(xPos, yPos);
                                    Console.Write("/");
                                    Thread.Sleep(15);
                                }
                                else
                                {
                                    if (bombaliLabirent[yPos, xPos - 1] == "/")//sola bak
                                    {
                                        xPos--;
                                        bombaliLabirent[yPos, xPos] = "?";
                                        Console.SetCursorPosition(xPos, yPos);
                                        Console.Write("?");
                                        Thread.Sleep(15);
                                    }
                                    else if (bombaliLabirent[yPos + 1, xPos] == "/")//asagi bak
                                    {
                                        yPos++;
                                        bombaliLabirent[yPos, xPos] = "?";
                                        Console.SetCursorPosition(xPos, yPos);
                                        Console.Write("?");
                                        Thread.Sleep(15);
                                    }
                                    else if (bombaliLabirent[yPos - 1, xPos] == "/")//yukari bak
                                    {
                                        yPos--;
                                        bombaliLabirent[yPos, xPos] = "?";
                                        Console.SetCursorPosition(xPos, yPos);
                                        Console.Write("?");
                                        Thread.Sleep(15);
                                    }
                                    else if (bombaliLabirent[yPos, xPos + 1] == "/")//saga bak
                                    {
                                        xPos++;
                                        bombaliLabirent[yPos, xPos] = "?";
                                        Console.SetCursorPosition(xPos, yPos);
                                        Console.Write("?");
                                        Thread.Sleep(15);
                                    } 
                                    else
                                    {
                                        if (bombaliLabirent[yPos, xPos + 1] == "?")//saga bak
                                        {
                                            xPos++;
                                            bombaliLabirent[yPos, xPos] = "-";
                                            Console.SetCursorPosition(xPos, yPos);
                                            Console.Write("-");
                                            Thread.Sleep(15);
                                        }
                                        else if (bombaliLabirent[yPos - 1, xPos] == "?")//yukari bak
                                        {
                                            yPos--;
                                            bombaliLabirent[yPos, xPos] = "-";
                                            Console.SetCursorPosition(xPos, yPos);
                                            Console.Write("-");
                                            Thread.Sleep(15);
                                        }
                                        else if (bombaliLabirent[yPos + 1, xPos] == "?")//asagi bak
                                        {
                                            yPos++;
                                            bombaliLabirent[yPos, xPos] = "-";
                                            Console.SetCursorPosition(xPos, yPos);
                                            Console.Write("-");
                                            Thread.Sleep(15);
                                        }
                                        else if (bombaliLabirent[yPos, xPos - 1] == "?")//sola bak
                                        {
                                            xPos--;
                                            bombaliLabirent[yPos, xPos] = "-";
                                            Console.SetCursorPosition(xPos, yPos);
                                            Console.Write("-");
                                            Thread.Sleep(15);
                                        }
                                        else
                                        {
                                            goto LabCoz;
                                        }  
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (bomba == true)
            {

                return true; ;
            }
        tusSecim:
            Console.SetCursorPosition(0, 31);
            Console.WriteLine("Dogru yol koordinatlarını gormek icin klavyenizden X tusuna basiniz");
            Console.WriteLine("Bombalarin konumlarini gormek icin klavyenizden B tusuna basiniz");
            Console.WriteLine("Labirentin orijinal halini gormek icin klavyenizden L tusuna basiniz");
            Console.WriteLine("Cikmak icin klavyenizden Q tusuna basiniz");
            string secim = Console.ReadLine();
            if(secim == "x")
            {
                Console.Clear();
                for(int i = 0; i < 30; i++)
                {
                    for(int j = 0; j < 30; j++)
                    {
                        if(bombaliLabirent[i,j] == "=")
                        {
                            Console.WriteLine("({0}, {1})", i, j);
                        }
                    }
                }
            }
            else if (secim == "b")
            {
                Console.Clear();
                for(int i = 0; i < 3; i++)
                {
                    Console.WriteLine("({0}, {1})",Bomba.bombaSatir[i], Bomba.bombaSutun[i]);
                }
            }
            else if(secim == "l")
            {
                Console.Clear();
                string[,] orj  = Bomba.BombaUret();
                for(int i = 0; i < 30; i++)
                {
                    for(int j = 0; j < 30; j++)
                    {
                        Console.Write(orj[i,j]);
                    }
                    Console.Write("\n");
                }
            }
            else if(secim== "q")
            {
                goto bitir;
            }
            else
            {
                Console.WriteLine("404");
                goto tusSecim;
            }
            bitir:
            return false;
        }
    }
}
