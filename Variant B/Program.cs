using System;

/*
 Загрузить фургон определенного объема грузом на определенную сумму из различных сортов кофе, находящихся, к тому же, 
в разных физических состояниях (зерно, молотый, растворимый в банках и пакетиках). 
Учитывать объем кофе вместе с упаковкой. 
Провести сортировку товаров на основе соотношения цены и веса. 
Найти в фургоне товар, соответствующий заданному диапазону параметров качества.
 */



namespace Variant_B
{
    abstract class Coffee
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Weight { get; set; }
        public string State { get; set; }
        public int Volume { get; set; }

        /* public Coffee(double price, int weight, string state)
         {
             Price = price;
             Weight = weight;
             State = state;
         }*/
        public virtual void GetParametrsOfProduct(string state)
        {
            Price = Price;
            Volume = Volume;
        }
    }


    class Jacobs : Coffee
    {
        public Jacobs(double price, int weight, string state) 
        {
            Name = "Jacobs";
            Price = price;
            Weight = weight;
            State = state;
        }

        public override void GetParametrsOfProduct(string state)
        {
            switch (state)
            {
                case "зерно в банках": break;




                case "зерно в пакетиках": break;
                case "молотый в банках ": break;
                case "молотый в пакетиках": break;
                case "растворимый в банках": break;
                case "растворимый в пакетиках": break;
            }






            Price = Price;
            Weight = Weight;
        }




    }

    class Jardin 
    { }

    class Gold 
    { }












    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
