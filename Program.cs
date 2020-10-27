using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
            double o;
            bool bkon = false;
            string num = "";
            string year;
            string month;
            string day;
            string yearcheck;
            string birthnum = "1";
            string kon;
            int w = 0;
            bool parse;

            while (w == 0)
            {
                Console.Write("skriv in personnummer: ");

                num = Console.ReadLine();


                int n;
                parse = int.TryParse(num, out n);
                //Cecking if Lenght is correct
                if (num.Length == 12 && parse)
                {

                    //split string for easy compare
                    year = num.Substring(0, 4);
                    month = num.Substring(4, 2);
                    day = num.Substring(6, 2);
                    birthnum = num.Substring(8, 3);
                    kon = num.Substring(11);

                    //checks the personnummer if correct
                    numberc = Twelve(year, month, day, birthnum);

                   bkon = Luhn(num, kon);

                    


                }
                else if (num.Length == 11)
                {

                    //split string for easy compare
                    year = num.Substring(0, 2);
                    month = num.Substring(2, 2);
                    day = num.Substring(4, 2);
                    yearcheck = num.Substring(6, 1);
                    birthnum = num.Substring(7, 3);
                    kon = num.Substring(10);

                    parse = double.TryParse(year + month + day + birthnum + kon, out o);


                    Console.WriteLine(year);
                    Console.WriteLine(month);
                    Console.WriteLine(day);
                    Console.WriteLine(birthnum);
                    Console.WriteLine(kon);
                    if (parse)
                    {
                        //checks the personnummer if correct
                        numberc = Ten(year, month, day, birthnum, yearcheck);

                        bkon = Luhn(num, kon);
                    }

                }


                //writes out if personnummer is correct
                if (numberc && bkon)
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
            if (int.Parse(year) % 4 == 0)
            {
                leapyear = true;
                Console.WriteLine("är skottår");
            }
            else if (int.Parse(year) % 400 == 0 && int.Parse(year) % 100 != 0)
            {
                leapyear = true;
                Console.WriteLine("är skottår");
            }
            else
            {
                leapyear = false;
                Console.WriteLine("är inte skottår");
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

        static bool Ten(string year, string month, string day, string birthnum, string yearcheck)
        {

            bool leapyear;
            int numyear;
            numyear = int.Parse(year);


            

            Console.WriteLine(yearcheck);
            if(numyear <= 20 && yearcheck == "-")
            {
                numyear = numyear + 2000;
            }
            else if(yearcheck == "+")
            {
                numyear = numyear + 1800;
            }
            else if(yearcheck == "-" && numyear > 20)
            {
                numyear = numyear + 1900;
            }
            else
            {
                return false;
            }

            //check if year is leap year
            if (numyear % 400 == 0)
            {
                leapyear = true;
                Console.WriteLine("är skottår");
            }
            else if (numyear % 100 != 0 && numyear % 4 == 0)
            {
                leapyear = true;
                Console.WriteLine("är skottår");
            }
            else
            {
                leapyear = false;
                Console.WriteLine("är inte skottår");
            }

            //Checking if year is correct
            if (numyear >= 1753 && numyear <= 2020)
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


        static bool Luhn(string num, string numberc)
        {
            int summa = 0;
            
            if(num.Length == 11)
            {
                string n = num.Substring(0, 6);
                string m = num.Substring(7);
                num = n + m;
                Console.WriteLine(num);
            }
            int[] array = new int[num.Length];

            for (int i = 0; i <= array.Length - 1; i++)
            {
                
                
                
                    array[i] = int.Parse(num.Substring(i, 1));
                    Console.WriteLine(array[i]);
                

            }
            

            if (num.Length == 12) {
                for (int j = 2; j <= array.Length - 2; j++)
                {


                    if (j % 2 != 0)
                    {
                        Console.WriteLine(array[j] + "*" + 1);
                        array[j] = array[j] * 1;
                        Console.WriteLine(array[j]);

                    }


                    else if (j % 2 == 0)
                    {

                        Console.WriteLine(array[j] + "*" + 2);
                        array[j] = array[j] * 2;
                        Console.WriteLine(array[j]);


                    }


                }

                for (int i = 0; i <= array.Length - 1; i++)
                {
                    if (array[i] > 9)
                    {
                        string a = "fel";
                        a = array[i].ToString();
                        a = a.Substring(0, 1);
                        Console.WriteLine("string a =" + a);
                        string b = "fel";
                        b = array[i].ToString();
                        b = b.Substring(1, 1);
                        Console.WriteLine("b = " + b);
                        int c = int.Parse(a);
                        int d = int.Parse(b);
                        array[i] = c + d;
                        Console.WriteLine(array[i]);

                    }
                }
                
                for (int i = 2; i <= array.Length - 2; i++)
                {

                    summa = summa + array[i];


                }
            }
            else if(num.Length == 10)
            {
                for (int j = 0; j <= array.Length - 2; j++)
                {


                    if (j % 2 != 0)
                    {
                        Console.WriteLine(array[j] + "*" + 1);
                        array[j] = array[j] * 1;
                        Console.WriteLine(array[j]);

                    }


                    else if (j % 2 == 0)
                    {

                        Console.WriteLine(array[j] + "*" + 2);
                        array[j] = array[j] * 2;
                        Console.WriteLine(array[j]);


                    }


                }

                for (int i = 0; i <= array.Length - 1; i++)
                {
                    if (array[i] > 9)
                    {
                        string a = "fel";
                        a = array[i].ToString();
                        a = a.Substring(0, 1);
                        Console.WriteLine("string a =" + a);
                        string b = "fel";
                        b = array[i].ToString();
                        b = b.Substring(1, 1);
                        Console.WriteLine("b = " + b);
                        int c = int.Parse(a);
                        int d = int.Parse(b);
                        array[i] = c + d;
                        Console.WriteLine(array[i]);

                    }
                }

                for (int i = 0; i <= array.Length - 2; i++)
                {

                    summa = summa + array[i];


                }




            }
            Console.WriteLine(summa);
            summa = (10 - (summa % 10)) % 10;
            Console.WriteLine(summa);

            if(summa == int.Parse(numberc))
            {
                return true;
            }
            
            
                return false;
           

            

        }

    }
}
