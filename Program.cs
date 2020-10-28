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
            
            bool format = false;
            bool luhnb = false;
            string answer = "";
            string year;
            string month;
            string day;
            string centurycheck;
            string birthnum = "1";
            string controlnumber;
            int w = 0;
            bool parse;

            //while loop if user input is incorrect
            while (w == 0)
            {
                Console.WriteLine("skriv personnummret i ett av formaten nedan");
                Console.WriteLine("yyyymmddnnnc eller yymmdd-nnnc"); 
                Console.Write("skriv in personnummer: ");

                //input from user
                answer = Console.ReadLine();


                //checking if input can be converted correctly
                parse = double.TryParse(answer, out double n);

                //Cecking if Lenght is correct
                if (answer.Length == 12 && parse)
                {

                    //split string for easy compare
                    year = answer.Substring(0, 4);
                    month = answer.Substring(4, 2);
                    day = answer.Substring(6, 2);
                    birthnum = answer.Substring(8, 3);
                    controlnumber = answer.Substring(11);

                    //outputs true if personnummer format is correct
                    format = Twelve(year, month, day, birthnum);

                    //outputs true if controll number is same as user input
                    luhnb = Luhn(answer, controlnumber);

                    


                }


                else if (answer.Length == 11)
                {

                    //split string for easy compare
                    year = answer.Substring(0, 2);
                    month = answer.Substring(2, 2);
                    day = answer.Substring(4, 2);
                    centurycheck = answer.Substring(6, 1); //minus or plus if over 100 years old
                    birthnum = answer.Substring(7, 3);
                    controlnumber = answer.Substring(10);

                    //checking if input can be converted correctly
                    parse = double.TryParse(year + month + day + birthnum + controlnumber, out double o);


                    
                    if (parse)
                    {
                        //outputs true if personnummer format is correct
                        format = Ten(year, month, day, birthnum, centurycheck);

                        //outputs true if controll number is same as user input
                        luhnb = Luhn(answer, controlnumber);
                    }

                }


                //writes out if personnummer is correct
                if (format && luhnb)
                {
                    Console.WriteLine();
                    Console.WriteLine("Personnummer godkänt");
                    w++;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(answer);
                    Console.WriteLine("personnummer ej godkänd, försök igen");
                    Console.WriteLine();
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


        static bool DateControll(string month, string day, bool leapyear)
        {
            
            // checking if date is correct with corresponding month
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
                
            }
            else if (int.Parse(year) % 400 == 0 && int.Parse(year) % 100 != 0)
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
                    if (DateControll(month, day, leapyear))
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


            
            // adds century depending on -/+
            if(numyear < 21 && yearcheck == "-")
            {
                numyear = numyear + 2000;
            }
            else if(yearcheck == "+" && numyear < 21)
            {
                numyear = numyear + 1800;
            }
            else if(yearcheck == "+" && numyear > 20)
            {
                numyear = numyear + 1900;
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
            }
            else if (numyear % 100 != 0 && numyear % 4 == 0)
            {
                leapyear = true;
            }
            else
            {
                leapyear = false;
            }

            //Checking if year is correct
            if (numyear >= 1753 && numyear <= 2020)
            {

                //checking if month is correct
                if (int.Parse(month) <= 12)
                {

                    //cecking if date is correct
                    if (DateControll(month, day, leapyear))
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
                //taking away with the -/+
                string n = num.Substring(0, 6);
                string m = num.Substring(7);
                num = n + m;
            }
            int[] array = new int[num.Length];

            //converts string to int array
            for (int i = 0; i <= array.Length - 1; i++)
            {
                
                array[i] = int.Parse(num.Substring(i, 1));
                    

            }
            

            if (num.Length == 12) {

                //multiply numbers with 2 or 1
                for (int j = 2; j <= array.Length - 2; j++)
                {


                    //odd muliply with 1
                    if (j % 2 != 0)
                    {

                        array[j] = array[j] * 1;

                    }

                    //even multiply with 2
                    else if (j % 2 == 0)
                    {

                        array[j] = array[j] * 2;


                    }


                }

                for (int i = 0; i <= array.Length - 1; i++)
                {
                    if (array[i] > 9)
                    {   
                        //seperates the first number
                        string a = "fel";
                        a = array[i].ToString();
                        a = a.Substring(0, 1);
                        
                        //seperates the second number
                        string b = "fel";
                        b = array[i].ToString();
                        b = b.Substring(1, 1);
                        
                        //adds the first and second number together
                        int c = int.Parse(a);
                        int d = int.Parse(b);
                        array[i] = c + d;
                        

                    }
                }
                
                //adds everything together
                for (int i = 2; i <= array.Length - 2; i++)
                {

                    summa = summa + array[i];


                }
            }
            else if(num.Length == 10)
            {

                //multiply numbers with 2 or 1
                for (int j = 0; j <= array.Length - 2; j++)
                {

                    //odd muliply with 1
                    if (j % 2 != 0)
                    {

                        array[j] = array[j] * 1;

                    }

                    //even multiply with 2
                    else if (j % 2 == 0)
                    {

                        array[j] = array[j] * 2;

                    }


                }

                for (int i = 0; i <= array.Length - 1; i++)
                {
                    if (array[i] > 9)
                    {

                        //seperates the first number
                        string a = "fel";
                        a = array[i].ToString();
                        a = a.Substring(0, 1);

                        //seperates the second number
                        string b = "fel";
                        b = array[i].ToString();
                        b = b.Substring(1, 1);

                        //adds the first and second number together
                        int c = int.Parse(a);
                        int d = int.Parse(b);
                        array[i] = c + d;
                        

                    }
                }

                //adds everything together
                for (int i = 0; i <= array.Length - 2; i++)
                {

                    summa = summa + array[i];


                }




            }

            //calulates the control number
            summa = (10 - (summa % 10)) % 10;
            
            //cecks if control number is same as user input
            if(summa == int.Parse(numberc))
            {
                return true;
            }
            
            
                return false;
           

            

        }

    }
}
