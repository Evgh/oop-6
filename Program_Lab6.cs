using System;
using System.Collections.Generic;
using System.Linq;

namespace oop_5
{
    // ---------------------------------------------------------------------------- добавлено в 6 лабе
    class Lab
    {
        private List<IProduct> products;
        public List<IProduct> Products
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
            if (!products.Contains(obj))
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
                i.Print();
            }
        }
    }


    static class LabControl
    {
        public static void Sort(this Lab lab)
        {
            var sorted = lab.Products.OrderByDescending(x => x.Price);
            foreach (IProduct i in sorted)
            {
                i.Print();
            }
        }

        public static int ScanAmount(this Lab lab)
        {
            return Scaner.Amount;
        }
        public static int CompAmount(this Lab lab)
        {
            return Computer.Amount;
        }
        public static int TablAmount(this Lab lab)
        {
            return Tablet.Amount;
        }

        public static List<IProduct> Elderst(this Lab lab)
        {
            var buff = new List<IProduct> { };

            foreach (IProduct item in lab.Products)
            {
                if (item.LifeTime > 3)
                {
                    buff.Add(item);
                }
            }
            return buff;
        } 
    }

    enum CONDITION { UNSOLD, SOLD};

    struct Data
    {
        public int _price;
        public int _life_time;
        public string _id;
        public CONDITION _is_sold;
    }

    abstract partial class Tech
    {
        // -------------------------------------- добавлено в 6 лабе
        protected Data _data;
    }


    sealed partial class Scaner : Tech, IProduct
    {
        // -------------------------------------- добавлено в 6 лабе 
        static Scaner()
        {
            Amount = 0;
        }
        public Scaner()
        {
            Amount++;

            var rr = new Random();
            _data = new Data();

            _data._is_sold = CONDITION.UNSOLD;
            _data._price = rr.Next(10, 100);
            _data._life_time = rr.Next(1, 5);
            _data._id = $"Scaner{Amount}";
        }



        public static int Amount { get; private set; }
        int IProduct.Price { get => _data._price; }
        CONDITION IProduct.IsSold
        {
            get => _data._is_sold;
            set => _data._is_sold = value;
        }
        public CONDITION IsSold
        {
            get => _data._is_sold;
        }
        public string Id
        {
            get => _data._id;
        }
        int IProduct.LifeTime
        {
            get => _data._life_time;
        }
    }

    sealed partial class Computer : TypingTech, IProduct
    {
        // -------------------------------------- добавлено в 6 лабе 
        static Computer()
        {
            Amount = 0;
        }
        public Computer()
        {
            Amount++;

            var rr = new Random();
            _data = new Data();

            _data._is_sold = CONDITION.UNSOLD;
            _data._price = rr.Next(10, 100);
            _data._life_time = rr.Next(1, 5);
            _data._id = $"Computer{Amount}";
        }

        public static int Amount { get; private set; }
        int IProduct.Price { get => _data._price; }
        CONDITION IProduct.IsSold
        {
            get => _data._is_sold;
            set => _data._is_sold = value;
        }
        public CONDITION IsSold
        {
            get => _data._is_sold;
        }
        public string Id
        {
            get => _data._id;
        }
        int IProduct.LifeTime
        {
            get => _data._life_time;
        }    
    }

    sealed partial class Tablet : TypingTech, IProduct
    {
        // -------------------------------------- добавлено в 6 лабе 
        static Tablet()
        {
            Amount = 0;
        }
        public Tablet()
        {
            Amount++;

            var rr = new Random();
            _data = new Data();

            _data._is_sold = CONDITION.UNSOLD;
            _data._price = rr.Next(10, 100);
            _data._life_time = rr.Next(1, 5);
            _data._id = $"Tablet{Amount}";
        }

        public static int Amount { get; private set; }
        int IProduct.Price { get => _data._price; }
        CONDITION IProduct.IsSold
        {
            get => _data._is_sold;
            set => _data._is_sold = value;
        }
        public CONDITION IsSold
        {
            get => _data._is_sold;
        }
        public string Id
        {
            get => _data._id;
        }
        int IProduct.LifeTime
        {
            get => _data._life_time;
        }
    }
}


