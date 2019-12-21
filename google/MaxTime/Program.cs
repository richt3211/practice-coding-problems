using System;

namespace MaxTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(solution("2?:?8"));
            Console.WriteLine(solution("?8:4?"));
            Console.WriteLine(solution("??:??"));
            Console.WriteLine(solution("06:34"));
            Console.WriteLine(solution("??:34"));
            Console.WriteLine(solution("06:??"));

        }

        static string solution(string T) {
            string result = "";

            // first character
            if (T[0] == '?')
            {
                if (T[1] == '?')
                {
                    result += '2';
                }
                else if (Int32.Parse(T[1].ToString()) > 3)
                {
                    result += '1';
                }
                else 
                {
                    result += '2';
                }
            }
            else 
            {
                result += T[0];
            }


            //second character
            if (T[1] == '?')            
            {
                if (T[0] == '?')
                {
                    result += '3';
                }
                else if (Int32.Parse(T[0].ToString())  == 2)
                {
                    result += '3';
                }
                else 
                {
                    result += '9';
                }
            }
            else 
            {
                result += T[1];
            }

            // third character
            result += ':';

            
            //fourth character
            if (T[3] == '?')
            {
                result += '5';
            }
            else 
            {
                result += T[3];
            }

            if (T[4] == '?')            
            {
                result += '9';
            }
            else 
            {
                result += T[4];
            }
            return result;
        }
    }
}
