using System;
using System.Collections.Generic;
using System.Linq;

namespace oop_5
{

    // ---------------------------------------------------------------------------- добавлено в 6 лабе

    class Lab
    {
        List<IProduct> products;
        List<IProduct> Products
        {
            get => products;
            set => products = value;
        }

        public Lab()
        {
            products = new List<IProduct> { };
        }

        public void Add(IProduct obj)
        {
            if (products.Contains(obj)) 
                products.Add(obj);
        }
        public void Remove(IProduct obj)
        {
            if (products.Contains(obj))
                products.Remove(obj);
        }
        public void Print()
        {
            foreach (IProduct i in products)
            {
                Console.WriteLine(i);
            }
        }
        public void Sort()
        {
            var sorted = products.OrderByDescending(x => x.Price);
            foreach (IProduct i in sorted)
            {
                Console.WriteLine(i);
            }
        }
        public int ScanAmount()
        {
            return Scaner.Amount;
        }
        public int CompAmount()
        {
            return Computer.Amount;
        }
        public int TablAmount()
        {
            return Tablet.Amount;
        }
    }

    // ---------------------------------------------------------------------------- классы, разработанные в 5 лабе

        interface IProduct
    {
        // для 6 лабы
        int Price { get; }
        int LifeTime { get; }
        protected bool IsSold { get; set;}
        // было в 5 лабе
        void ToSell()
        {
            if (!IsSold)
            {
                Console.WriteLine("Товар продан.");
                IsSold = true;
            }
            else
            {
                Console.WriteLine("Товар нельзя продать снова -- он уже продан.");
            }            
        }

        void DoThing()
        {
            Console.WriteLine("Товар делает штуку по-интерфейсовски.");
        }
    }

    abstract class Tech 
    {
        // -------------------------------------- добавлено в 6 лабе
        protected static int _amount;

        protected int _price;
        protected bool _is_sold;
        protected int _id;
        protected int _life_time;

        // -------------------------------------- осталось без изменений из 5 лабы 
        protected bool isRunning;
        protected Tech()
        {
            isRunning = false;
        }

        public bool TurnOn()
        {
            isRunning = true;
            return true;
        }
        public bool TurnOff()
        {
            isRunning = false;
            return true;
        }
        public virtual bool IsItRunning()
        {
            return isRunning;
        }
        public override string ToString()
        {
            return $"Техника типа {GetType()}, работает ли: {isRunning}.";
        }
    }

    abstract class TypingTech : Tech
    {
        public abstract bool InputText();
        public override string ToString()
        {
            return $"Печатающее устройство типа {GetType()}, работает ли: {isRunning}.";
        }
    }

    sealed class Scaner : Tech, IProduct
    {
        //  -------------------------------------- добавлено в 6 лабе 
        static Scaner()
        {
            _amount = 0;
        }
        public Scaner()
        {
            _amount++;

            var rr = new Random();

            _price = rr.Next(10, 100);
            _is_sold = false;
            _id = _amount + 1000;
            _life_time = rr.Next(1, 5);
        }

        public static int Amount { get => _amount; }
        int IProduct.Price { get => _price; }
        bool IProduct.IsSold
        {
            get => _is_sold;
            set => _is_sold = value;
        }
        public bool IsSold
        {
            get => _is_sold;
        }
        public int Id
        {
            get => _id;
        }
        int IProduct.LifeTime
        {
            get => _life_time;
        }

        // -------------------------------------- осталось без изменений из 5 лабы
        public override bool IsItRunning()
        {
            if (base.isRunning)
            {
                Console.WriteLine("Сканер сканирует.");
            }
            else
            {
                Console.WriteLine("Сканер не сканирует.");
            }
            return base.isRunning;
        }

        // Штуки.
        public void DoThing()
        {
            Console.WriteLine("Сканер делает штуку по-сканерски");
        }
        void IProduct.DoThing()
        {
            Console.WriteLine("Сканер делает штуку по-интерфейсовски");
        }

        public override string ToString()
        {
            return $"Сканер типа {GetType()}, работает ли: {isRunning}, продан ли: {_is_sold}.";
        }
    }

    sealed class Computer : TypingTech, IProduct
    {
        // -------------------------------------- добавлено в 6 лабе 
        static Computer()
        {
            _amount = 0;
        }
        public Computer()
        {
            _amount++;

            var rr = new Random();

            _price = rr.Next(10, 100);
            _is_sold = false;
            _id = _amount;
            _life_time = rr.Next(1, 5);
        }

        public static int Amount { get => _amount; }
        int IProduct.Price { get => _price; }
        bool IProduct.IsSold
        {
            get => _is_sold;
            set => _is_sold = value;
        }
        public bool IsSold
        {
            get => _is_sold;
        }
        public int Id
        {
            get => _id;
        }
        int IProduct.LifeTime
        {
            get => _life_time;
        }
        // -------------------------------------- осталось без изменений из 5 лабы
        public override bool InputText()
        {
            Console.WriteLine("Набирается текст на клавиатуре");
            return true;
        }

        // Штуки.
        public void DoThing()
        {
            Console.WriteLine("Компьютер делает штуку по-компьютерски");
        }
        void IProduct.DoThing()
        {
            Console.WriteLine("Компьютер делает штуку по-интерфейсовски");
        }

        public override string ToString()
        {
            return $"Компьютер типа {GetType()}, работает ли: {isRunning}.";
        }
    }

    sealed class Tablet : TypingTech, IProduct 
    {
        // -------------------------------------- добавлено в 6 лабе 
        static Tablet()
        {
            _amount = 0;
        }
        public Tablet()
        {
            _amount++;

            var rr = new Random();

            _price = rr.Next(10, 100);
            _is_sold = false;
            _id = _amount;
            _life_time = rr.Next(1, 5);
        }


        public static int Amount { get => _amount; }
        int IProduct.Price { get => _price; }
        bool IProduct.IsSold
        {
            get => _is_sold;
            set => _is_sold = value;
        }
        public bool IsSold
        {
            get => _is_sold;
        }
        public int Id
        {
            get => _id;
        }
        int IProduct.LifeTime
        {
            get => _life_time;
        }

        // -------------------------------------- осталось без изменений из 5 лабы
        public override bool InputText()
        {
            Console.WriteLine("Набирается текст пальцами");
            return true;
        }

        // Штуки.
        public void DoThing()
        {
            Console.WriteLine("Планшет делает штуку по-планшетски");
        }
        void IProduct.DoThing()
        {
            Console.WriteLine("Планшет делает штуку по-интерфейсовски");
        }

        // Переопределение методов обджекта.
        public override int GetHashCode()
        {
            Random rr = new Random();
            return rr.Next();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override string ToString()
        {
            return $"Планшет типа {GetType()}, работает ли: {isRunning}, продан ли: {_is_sold}.";
        }
    }

    class Printer
    {
        internal void IAmPrinting(Tech obj) => Console.WriteLine($"{obj.GetType()} | {obj}");
    }


    class Program
    {
        static void Main(string[] args)
        {
            var comp = new Computer();
            var scan = new Scaner();
            var tabl = new Tablet();

            IProduct icomp = null;
            Tech ttabl = null;

            if (comp is IProduct)
            {
                icomp = comp as IProduct;
            }

            if (tabl is Tech)
            {
                ttabl = tabl as Tech;
            }


            Console.WriteLine($"Работает ли сканер? - {scan.IsItRunning()}");
            scan.TurnOn();
            Console.WriteLine($"А теперь работает? - {scan.IsItRunning()}\n");
            Console.WriteLine($"Продали? {scan.IsSold}");

            Console.WriteLine($"Работает ли комп? - {comp.IsItRunning()}");
            comp.TurnOn();
            Console.WriteLine($"Ну и ладно, что не работает, продадим");
            icomp.ToSell();
            //Console.WriteLine($"Продали? {icomp.IsSold}");
            Console.WriteLine($"Попробуем продать еще?");
            ((IProduct)comp).ToSell();


            Console.WriteLine($"\nВключим планшет");
            ttabl.TurnOn();
            if (ttabl.IsItRunning())
            {
                Console.WriteLine("Заработал");
            }
            else
            {
                Console.WriteLine("Почему-то не заработал");
            }

            Console.WriteLine("\n Теперь проверяем работу штук");
            icomp.DoThing();
            comp.DoThing();
        }
    }
}
