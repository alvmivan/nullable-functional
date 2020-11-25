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
                    .Where(num => num == 2)
                    .Select(num => num + 1)
                    .Do(Console.WriteLine);
            }
            //OUT: 3

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = numbers[i].OrDefault(10);
            }


            Console.WriteLine(string.Join(",", numbers));
            //OUT: 1,2,10


            // with objects

            var jhon = new Person("jhon",17);
            var peter = new Person("peter",21);
            var people = new[]{jhon, null, peter, null};


            foreach (var person in people)
            {
                person
                    .Select(p => p.Name)
                    .Do(Console.WriteLine)
                    .DoWhenNull(()=>Console.WriteLine("is null"));
            }
            
            /*
             * Out:
             * jhon
             * is null
             * peter
             * is null
             */
            
            foreach (var person in people)
            {
                person
                    .Where(p=>p.Age>18)
                    .Select(p => p.Name)
                    .Do(Console.WriteLine)
                    .DoWhenNull(()=>Console.WriteLine("is null or under age"));
            }
            
            /*
             * Out:
             * is null or under age
             * is null or under age
             * peter
             * is null or under age
             */
            foreach (var person in people)
            {
                person
                    .Where(p=>p.Age>18)
                    .SelectOrElse(p => p.Name, "again, null or under age")
                    .Do(Console.WriteLine)
                    .DoWhenNull(()=>Console.WriteLine("This line should not be printed"));
            }
            
            /*
             * Out:
             * again, null or under age
             * again, null or under age
             * peter
             * again, null or under age
             */
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }


        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}