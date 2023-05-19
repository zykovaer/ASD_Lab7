using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_Lab7
{
    class Program
    {

        static void Main(string[] args)
        {
            ConsoleKeyInfo K;
            int len = 0;
            UserList<int> def = new UserList<int>();
            UserList<int> def2 = new UserList<int>();
            UserList<int> def3 = new UserList<int>();
            UserList<int> def4 = def;
            UserList<int> def5 = def2;
            int t = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("1.Ввод первого листа");
                Console.WriteLine("2.Ввод второго листа");
                Console.WriteLine("3.Вставить после каждого элемента, занимающего четную позицию в nсписке, новый элемент Е ");
                Console.WriteLine("4.Создать новый список L, содержащий элементы списков L1 и L2, чередующиеся между собой (если списки L1 и L2 одинаковой длины)");
                Console.WriteLine("5.Вывод");
                Console.WriteLine("6.Добавить в начало");
                Console.WriteLine("7.Добавить в конец");
                Console.WriteLine("8.Поиск элемента по значению(bool)");
                Console.WriteLine("9.Поиск элемента по номеру");
                Console.WriteLine("0.Добавить перед заданным");
                Console.WriteLine("a.Добавить после заданного");
                Console.WriteLine("s.Удалить из начала");
                Console.WriteLine("d.Удалить из конца");
                Console.WriteLine("f.Удалить перед заданным");
                Console.WriteLine("g.Удалить после заданного");
                Console.WriteLine("Esc. Выход из программы");
                K = Console.ReadKey();
                try
                {
                    switch (K.Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            len = Inpiut();
                            def = GenerateStack(len);
                            Console.WriteLine(def.ToString());
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            len = Inpiut();
                            def2 = GenerateStack(len);
                            Console.WriteLine(def2.ToString());
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            if (def.Count == 0)
                            {
                                Console.WriteLine("Первый лист пуст: ");
                                len = Inpiut();
                                def = GenerateStack(len);
                            }

                     
                            Console.WriteLine("Введите элемент E");
                            int E = int.Parse(Console.ReadLine());
                            def3=vstav(def, E);
                            Console.WriteLine($"Итог слияния: {def3.ToString()}");
                            break;
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:
                            if (def.Count == 0)
                            {
                                Console.WriteLine("Первый лист пуст: ");
                                len = Inpiut();
                                def = GenerateStack(len);
                            }
                            if (def2.Count == 0)
                            {
                                Console.WriteLine("Второй лист пуст: ");
                                len = Inpiut();
                                def2 = GenerateStack(len);
                            }
                            if(def.Count== def2.Count())
                            {
                                Console.WriteLine($"Первый список: {def.ToString()}");
                                Console.WriteLine($"Второй список: {def2.ToString()}");
                                def3 = FindSame(def,def2);
                                Console.WriteLine($"Итог слияния: ");
                                Output(def3);
                            }
                            else
                            {
                                Console.WriteLine("Массивы разной длины");
                            }
                            
                            break;
                        case ConsoleKey.D5:
                        case ConsoleKey.NumPad5:
                            Console.WriteLine(def.ToString());
                            break;
                        case ConsoleKey.D6:
                        case ConsoleKey.NumPad6:
                            Console.WriteLine("Введите число: ");
                            t = InpUser();
                            def.PushFirst(t);
                            break;
                        case ConsoleKey.D7:
                        case ConsoleKey.NumPad7:
                            Console.WriteLine("Введите число: ");
                            t = InpUser();
                            def.PushBack(t);
                            break;
                        case ConsoleKey.D8:
                        case ConsoleKey.NumPad8:
                            Console.WriteLine("Введите число: ");
                            t = InpUser();
                            Console.WriteLine(def.Contains(t));
                            break;
                        case ConsoleKey.D9:
                        case ConsoleKey.NumPad9:
                            Console.WriteLine("Введите номер: ");
                            t = InpUser();
                            t = def.Search(t);
                            if(t == 0)
                            Console.WriteLine();
                            else Console.WriteLine(t);
                            break;
                        case ConsoleKey.D0:
                        case ConsoleKey.NumPad0:
                            Console.WriteLine("Введите число: ");
                            t = InpUser();
                            Console.WriteLine("Введите номер: ");
                            len = InpUser();
                            def.AddBefore(t,len);
                            break;
                        case ConsoleKey.A:
                            Console.WriteLine("Введите число: ");
                            t = InpUser();
                            Console.WriteLine("Введите номер: ");
                            len = InpUser();
                            def.AddAfter(t, len);
                            break;
                        case ConsoleKey.S:
                            def.PopFirst();
                            break;
                        case ConsoleKey.D:
                            def.PopBack();
                            break;
                        case ConsoleKey.F:
                            Console.WriteLine("Введите номер: ");
                            t = InpUser();
                            def.DelBefore(t);
                            break;
                        case ConsoleKey.G:
                            Console.WriteLine("Введите номер: ");
                            t = InpUser();
                            def.DelAfter(t);
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                        default: Console.WriteLine("Request not processed"); break;
                    }
                    //System.Threading.Thread.Sleep(4000);
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (K.Key != ConsoleKey.Escape);
            
        }

        static int Inpiut()
        {
            int N = 0;
            while (true)
            {
                try
                {
                    Console.Write("Введите количество элементов: ");
                    N = int.Parse(Console.ReadLine());

                    if (N < 1) throw new Exception("Такого не может быть!!!\n");
                    return N;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static int InpUser()
        {
            int N = 0;
            while (true)
            {
                try
                {
                    N = int.Parse(Console.ReadLine());
                    return N;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return N;
        }

        static UserList<int> GenerateStack(int N)
        {
            UserList<int> fStack = new UserList<int>();
            Random rnd = new Random();
            int k;
            int[] arr = new int[N];
            try
            {
                for (int i = 0; i < N; i++)
                {
                    k = rnd.Next(1, 10);
                    fStack.PushFirst(k);
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return fStack;
        }
        //1 задача
        static UserList<int> FindSame(UserList<int> st, UserList<int> st2)
        {
            UserList<int> tmp = new UserList<int>();
            UserList<int> tmp2= new UserList<int>();
            UserList<int> list = new UserList<int>();
            for (int k = 1; k <= st.Count; k++)
            {
                tmp.PushBack(st.Search(k));
            }
            for (int k = 1; k <= st2.Count; k++)
            {
                tmp2.PushBack(st2.Search(k));
            }
            for(int i =1; i <= tmp2.Count; i++)
            {
                list.PushBack(tmp.Search(i));
                list.PushBack(tmp2.Search(i));
            }
            return list;

        }
        static UserList<int> vstav(UserList<int> ls, int E)
        {
            UserList<int> got = new UserList<int>();
            UserList<int> got1 = new UserList<int>();
            for(int k = 1; k <= ls.Count;k++ )
            {
                got.PushBack(ls.Search(k));
            }
           for (int i=1; i<got.Count(); i = i + 2)
            {
                got.AddAfter(E, i);
                i++;
            }
            return got;
        }

      

      
       

        static void Output(UserList<int> aft)
        {
            //aft.Dequeue();
            int N = aft.Count;
            //Console.WriteLine(N);
            Console.WriteLine("\nПреобразованный лист: ");
            while (N > 0)
            {
                Console.Write($"{aft.PopFirst()} ");
                N--;
            }
            Console.WriteLine();
        }

      \
    }
}
