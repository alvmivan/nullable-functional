using System;

namespace NullableFunctional
{
    public class Example
    {
        public static void Main(string[] _)
        {
            int? num1 = 1;
            int? num2 = 2;
            int? numNull = null;

            int?[] numbers = {num1, num2, numNull};

            num1.Do(Console.WriteLine);
            numNull.Do(Console.WriteLine);
            num2.Do(Console.WriteLine);
            
            /*
             * OUT:
             * 1
             * 2
             */

            num1.DoWhenAbsent(() => Console.WriteLine("null value for num1"));
            num2.DoWhenAbsent(() => Console.WriteLine("null value for num2"));
            numNull.DoWhenAbsent(() => Console.WriteLine("null value for numNull"));

            /*
             * OUT:
             * null value for numNull
             */

            foreach (var number in numbers)
            {
                number
                    .Where(num=>num == 2)
                    .Select(num => num + 1)
                    .Do(Console.WriteLine);
            }
            //OUT: 3

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = numbers[i].OrDefault(10);
            }
            
            
            Console.WriteLine(string.Join(",",numbers));
            //OUT: 1,2,10
            
            
            
            
            
        }
    }
}