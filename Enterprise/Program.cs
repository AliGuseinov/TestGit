using System;

namespace Enterprise
{
    class Enterprise
    {
        public string workName;

        public static int quantity;

        public void doWork()
        {
            Console.WriteLine(workName + " is working");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Enterprise ent = new Enterprise();
            ent.workName = "89";
            ent.doWork();

            Enterprise ent1 = new Enterprise();
            ent1.workName = "8999";
            ent1.doWork();

            Enterprise.quantity = 2;

            Console.WriteLine(ent.workName);
            Console.WriteLine(Enterprise.quantity);
        }
    }
}
