using System;
using System.Collections.Generic;
using System.Linq;

namespace selection
{
    class Program
    {
        static List<int> AutomaticCreateNumbers()
        {
            Console.WriteLine("Введите, пожалуйста, желаемое количество элементов, изкоторых планируете отбирать нужные числа");
            int quantityNumbers = Convert.ToInt32(Console.ReadLine());
            List<int> _numbers = new();
            Random rand = new();
            for (int i = 0; i < quantityNumbers; i++)
            {
                _numbers.Add(rand.Next(-20000, 20000));
            }
            Console.Write("Вы создали массив:\n");
            foreach (int i in _numbers)
            {
                Console.Write(i + "\n");
            }
            Console.WriteLine("\n");
            return _numbers;
        }

        static List<int> ManualCreateNumbers()
        {
            List<int> _numbers = new();
            Console.WriteLine("Введите, пожалуйста, элементы массива через пробел, запятую, точку или двоеточие:");
            _numbers = Console.ReadLine().Split(' ', ',', '.', ':', '\t').Select(i => Convert.ToInt32(i)).ToList();
            return _numbers;
        }

        static List<int> Select(List<int> _numbers)
        {
            Console.WriteLine("Введите, пожалуйста, нижнюю границу отбора");
            int firsrLimit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите, пожалуйста, верхнюю границу отбора");
            int secondLimit = Convert.ToInt32(Console.ReadLine());
            int bottom;
            int top;
            if (firsrLimit < secondLimit)
            {
                bottom = firsrLimit;
                top = secondLimit;
            }
            else
            {
                bottom = secondLimit;
                top = firsrLimit;
            }
            List<int> _selection = new();
            foreach (int i in _numbers)
            {
                if (i >= bottom & i <= top)
                {
                   _selection.Add(i);
                }
            }
            return (_selection);
        }
           


       static void Main(string[] args)
        {
            do
            {
                List<int> numbers;
                int optionCreateNumbers = 0;
                do
                {
                    Console.WriteLine("Массив сгенерировать автоматически или Вы введёте его сами?");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(" 1 - сгенерировать автоматически\t 2 - самостояельный ввод");
                    Console.ForegroundColor = ConsoleColor.White;
                    optionCreateNumbers = Convert.ToInt32(Console.ReadLine());
                    if (optionCreateNumbers == 1 | optionCreateNumbers == 2)
                    {
                        break;
                    }
                    Console.WriteLine("Сосредоточьтесь!");
                }
                while (optionCreateNumbers != 1 | optionCreateNumbers != 2);

                if (optionCreateNumbers == 1)
                    {
                    numbers = AutomaticCreateNumbers();
                    }
                    else
                    {
                    numbers = ManualCreateNumbers();
                    }
                   
                    List<int> selection = Select(numbers);
                    if (selection.Count == 0)
                    {
                    Console.WriteLine("Массив не содержит элементов в пределах указанных границ.");
                    }
                    else
                    {
                    Console.Write("Отобраны следующие числа: ");
                    foreach (int i in selection)
                    {
                        Console.Write(i + "  ");
                    }
                    Console.WriteLine("\n");
                    }
            }
            while (true);
       }
    }
}
