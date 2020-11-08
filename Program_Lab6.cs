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



    abstract partial class Tech
    {
        // -------------------------------------- добавлено в 6 лабе
        protected static int _amount;

        protected int _price;
        protected bool _is_sold;
        protected int _id;
        protected int _life_time;
    }


    sealed partial class Scaner : Tech, IProduct
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
    }

    sealed partial class Computer : TypingTech, IProduct
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
    }

    sealed partial class Tablet : TypingTech, IProduct
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

    }

}


