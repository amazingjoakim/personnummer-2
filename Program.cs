using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Personnummer_uppgift
{
    class Program
    {
        static void Main(string[] args)
        {

            bool numberc = false;
            string year;
            string month;
            string day;
            string birthnum = "1";
            string kon;
            int w = 0;

            while (w == 0)
            {
                Console.Write("skriv in personnummer: ");

                string num = Console.ReadLine();




                //Cecking if Lenght is correct
                if (num.Length == 12)
                {

                    //split string for easy compare
                    year = num.Substring(0, 4);
                    month = num.Substring(4, 2);
                    day = num.Substring(6, 2);
                    birthnum = num.Substring(8, 3);
                    kon = num.Substring(11);

                    //checks the personnummer if correct
                    numberc = Twelve(year, month, day, birthnum);
                }
                else if (num.Length == 10)
                {

                    //split string for easy compare
                    year = num.Substring(0, 2);
                    month = num.Substring(2, 2);
                    day = num.Substring(4, 2);
                    birthnum = num.Substring(6, 3);
                    kon = num.Substring(9);

                    Console.WriteLine(year);
                    Console.WriteLine(month);
                    Console.WriteLine(day);
                    Console.WriteLine(birthnum);
                    Console.WriteLine(kon);
                    //checks the personnummer if correct
                    numberc = Ten(year, month, day, birthnum);


                }


                //writes out if personnummer is correct
                if (numberc)
                {
                    Console.WriteLine("Personnummer godkänt");
                    w++;
                }
                else
                {
                    Console.WriteLine("personnummer inte godkänd, försök igen");
                }


            }

            //writes out if person is man or woman
            if (int.Parse(birthnum) % 2 == 0)
            {
                Console.WriteLine("kön: kvinna");
            }
            else
            {
                Console.WriteLine("kön: man");
            }



            Console.ReadKey();



        }


        static bool DayControll(string month, string day, bool leapyear)
        {
            switch (month)
            {
                case "01":
                    for (int i = 1; i <= 31; i++)
                    {
                        if (int.Parse(day) == i)
                            return true;
                    }
                    break;
                case "02":
                    if (leapyear)
                    {
                        for (int i = 1; i <= 29; i++)
                        {
                            if (int.Parse(day) == i)
                                return true;
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= 28; i++)
                        {
                            if (int.Parse(day) == i)
                                return true;
                        }
                        break;
                    }
                    break;
                case "03":
                    for (int i = 1; i <= 31; i++)
                    {
                        if (int.Parse(day) == i)
                            return true;
                    }
                    break;
                case "04":
                    for (int i = 1; i <= 30; i++)
                    {
                        if (int.Parse(day) == i)
                            return true;
                    }
                    break;
                case "05":
                    for (int i = 1; i <= 31; i++)
                    {
                        if (int.Parse(day) == i)
                            return true;
                    }
                    break;
                case "06":
                    for (int i = 1; i <= 30; i++)
                    {
                        if (int.Parse(day) == i)
                            return true;
                    }
                    break;
                case "07":
                    for (int i = 1; i <= 31; i++)
                    {
                        if (int.Parse(day) == i)
                            return true;
                    }
                    break;
                case "08":
                    for (int i = 1; i <= 31; i++)
                    {
                        if (int.Parse(day) == i)
                            return true;
                    }
                    break;
                case "09":
                    for (int i = 1; i <= 30; i++)
                    {
                        if (int.Parse(day) == i)
                            return true;
                    }
                    break;
                case "10":
                    for (int i = 1; i <= 31; i++)
                    {
                        if (int.Parse(day) == i)
                            return true;
                    }
                    break;
                case "11":
                    for (int i = 1; i <= 30; i++)
                    {
                        if (int.Parse(day) == i)
                            return true;
                    }
                    break;
                case "12":
                    for (int i = 1; i <= 31; i++)
                    {
                        if (int.Parse(day) == i)
                            return true;
                    }
                    break;
                default:
                    return false;



            }

            return false;



        }
        static bool Twelve(string year, string month, string day, string birthnum)
        {
            bool leapyear;


            //check if year is leap year
            if (int.Parse(year) % 400 == 0)
            {
                leapyear = true;
            }
            else if (int.Parse(year) % 100 != 0)
            {
                leapyear = true;
            }
            else if (int.Parse(year) % 4 == 0)
            {
                leapyear = true;
            }
            else
            {
                leapyear = false;
            }

            //Checking if year is correct
            if (int.Parse(year) >= 1753 && int.Parse(year) <= 2020)
            {

                //checking if month is correct
                if (int.Parse(month) <= 12)
                {

                    //cecking if date is correct
                    if (DayControll(month, day, leapyear))
                    {

                        //loop to check if birth number is correct
                        for (int i = 0; i <= 999; i++)
                        {

                            if (int.Parse(birthnum) == i)
                            {
                                return true;
                            }

                        }

                    }

                }



            }


            return false;
        }

        static bool Ten(string year, string month, string day, string birthnum)
        {

            bool leapyear;


            //check if year is leap year
            if (int.Parse(year) % 400 == 0)
            {
                leapyear = true;
            }
            else if (int.Parse(year) % 100 != 0)
            {
                leapyear = true;
            }
            else if (int.Parse(year) % 4 == 0)
            {
                leapyear = true;
            }
            else
            {
                leapyear = false;
            }

            //Checking if year is correct
            if (1900 + int.Parse(year) >= 1753 && 1900 + int.Parse(year) <= 2020)
            {

                //checking if month is correct
                if (int.Parse(month) <= 12)
                {

                    //cecking if date is correct
                    if (DayControll(month, day, leapyear))
                    {

                        //loop to check if birth number is correct
                        for (int i = 0; i <= 999; i++)
                        {

                            if (int.Parse(birthnum) == i)
                            {
                                return true;
                            }

                        }

                    }

                }



            }

            return false;

        }

    }
}
