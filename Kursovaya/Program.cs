using System;
using System.IO;

namespace Kursovaya
{
    class Program
    {
        static int n = 0;
        static Collector[] list = new Collector[n];
        static void Main(string[] args)
        {
            try
            {
                LoadAllFromFile();
                for (int i = 0; i < n; i++) list[i].output();

                Console.WriteLine("Введите название цеха для вывода:");
                string search = Console.ReadLine();
                for (int i = 0; i < n; i++)
                {
                    if (list[i].getWorkshop() == search) list[i].getMax();
                }

                Console.WriteLine("\n\nФормирование файла с общим количеством изделий за неделю...");
                StreamWriter sw = new StreamWriter("Сформированный файл.txt", false, System.Text.Encoding.GetEncoding(1251));
                for (int i = 0; i < n; i++)
                {
                    sw.WriteLine(list[i].getName());
                    sw.WriteLine(list[i].getSum());
                }
                sw.Close();
                Console.WriteLine("Файл сформирован. Вывод на экран:");
                StreamReader sr = new StreamReader("Сформированный файл.txt", System.Text.Encoding.GetEncoding(1251));
                string line;
                while ((line = sr.ReadLine()) != null) Console.WriteLine(line);
                sr.Close();

                Console.WriteLine("\nДобавление записи в исходный файл. Введите данные:");
                n++;
                Array.Resize(ref list, list.Length + 1);
                list[n - 1] = new Collector();
                list[n - 1].input();
                SaveAllToFile();

                Console.WriteLine("Введите Ф.И.О. для удаления:");
                string name = Console.ReadLine();
                for (int i = 0; i < n; i++)
                {
                    if (list[i].getName() == name) list[i] = null;
                }
                SaveAllToFile();
                LoadAllFromFile();

                Console.WriteLine("Введите Ф.И.О. сборщика, которому хотите изменить имя цеха:");
                name = Console.ReadLine();
                for (int i = 0; i < n; i++)
                {
                    if (list[i].getName() == name)
                    {
                        Console.WriteLine("Введите новое наименование цеха:");
                        list[i].setWorkshop(Console.ReadLine());
                    }
                }
                SaveAllToFile();
                Collector a = new Collector("Иван", "Цех А", new int[] { 10, 10, 10, 10, 10 });
                a.addCounts(a);
                a.output();
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine("Ошибка: {0}", e.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        static void SaveAllToFile()
        {
            for (int i = 0; i < list.Length; i++) if (list[i] == null) n--;
            StreamWriter sw = new StreamWriter("Сборщик цеха.txt", false, System.Text.Encoding.GetEncoding(1251));
            sw.WriteLine(n);
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] != null) list[i].saveToFile(sw);
            }
            sw.Close();
        }
        static void LoadAllFromFile()
        {
            StreamReader sr = new StreamReader("Сборщик цеха.txt", System.Text.Encoding.GetEncoding(1251));
            n = int.Parse(sr.ReadLine());
            list = new Collector[n];
            for (int i = 0; i < n; i++)
            {
                list[i] = new Collector();
                list[i].loadFromFile(sr);
            }
            sr.Close();
        }
    }
}
