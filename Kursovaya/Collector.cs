using System;
using System.IO;

namespace Kursovaya
{
    class Collector
    {
        private String collector_name;
        private String workshop;
        private int[] count = new int[5];

        public Collector()
        {
            this.collector_name = "";
            this.workshop = "";
            count[0] = 0;
            count[1] = 0;
            count[2] = 0;
            count[2] = 0;
            count[4] = 0;
        }

        public Collector(String name, String workshop, int[] count)
        {
            this.collector_name = name;
            this.workshop = workshop;
            this.count = count;
        }

        public void input()
        {
            Console.WriteLine("Введите Ф.И.О.:");
            this.collector_name = Console.ReadLine();
            Console.WriteLine("Введите название цеха:");
            this.workshop = Console.ReadLine();
            Console.WriteLine("Введите количество изделий в течение 5-ти дней:");
            for (int i = 0; i < 5; i++) this.count[i] = int.Parse(Console.ReadLine());
        }

        public void output()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine(this.collector_name + " (" + this.workshop + ")");
            for(int i = 0; i < 5; i++) Console.Write(this.count[i] + "  ");
            Console.WriteLine("\n-----------------------");
        }

        public void loadFromFile(StreamReader sr)
        {
            this.collector_name = sr.ReadLine();
            this.workshop = sr.ReadLine();
            for (int i = 0; i < 5; i++) this.count[i] = int.Parse(sr.ReadLine());
        }

        public void saveToFile(StreamWriter sw)
        {
            sw.WriteLine(this.collector_name);
            sw.WriteLine(this.workshop);
            for (int i = 0; i < 5; i++) sw.WriteLine(this.count[i]);
        }

        public void getMax()
        {
            int max = 0;
            for (int i = 0; i < 5; i++) { if (count[i] > count[max]) max = i; }
            String[] name = { "Понедельник (1)", "Вторник (2)", "Среда (3)", "Четверг (4)", "Пятница (5)" };
            Console.WriteLine(this.collector_name + " (" + name[max] + " - " + this.count[max] + " деталей)");
        }

        public int getSum()
        {
            int sum = 0;
            for (int i = 0; i < 5; i++) sum += this.count[i];
            return sum;
        }

        public String getName()
        {
            return this.collector_name;
        }

        public String getWorkshop()
        {
            return this.workshop;
        }

        public void setWorkshop(String text)
        {
            this.workshop = text;
        }

        public int[] getCounts()
        {
            return this.count;
        }

        public void addCounts(Collector collector)
        {
            for (int i = 0; i < 5; i++)
                this.count[i] += collector.count[i];
        }
    }
}
