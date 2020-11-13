using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace oop_5
{
    // ---------------------------------------------------------------------------- классы, разработанные в 5 лабе

    interface IProduct
    {
        // для 6 лабы
        int Price { get; }
        int LifeTime { get; }
        String Id { get; }
        protected CONDITION IsSold { get; set; }

        void Print()
        {
            Console.WriteLine($"{Id}| срок службы (в годах): {LifeTime}| цена: {Price} | продано ли: {IsSold}");
        }

        bool ToSell()
        {
            // модифицировано для 7й лабы
            if (Price < 20)
            {
                throw new InvalidPriceException();
            }
            else if(IsSold == CONDITION.SOLD)
            {
                throw new AlreadySoldException();
            }
            else 
            {
                IsSold = CONDITION.SOLD;
                return true;
            }
        }
        // было в 5 лабе
        void DoThing()
        {
            Console.WriteLine("Товар делает штуку по-интерфейсовски.");
        }
    }

    abstract partial class Tech 
    {
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

    sealed partial class Scaner : Tech, IProduct
    {
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
            return $"Сканер типа {GetType()}, работает ли: {isRunning}, продан ли: {IsSold}.";
        }
    }

    sealed partial class Computer : TypingTech, IProduct
    {
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

    sealed partial class Tablet : TypingTech, IProduct 
    {
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
            return $"Планшет типа {GetType()}, работает ли: {isRunning}, продан ли: {IsSold}.";
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
            var comp2 = new Computer();
            var scan = new Scaner();;
            var tabl = new Tablet();

            var lab = new Lab();

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

            lab.Add(comp);
            lab.Add(comp2);
            lab.Add(scan);
            lab.Add(tabl);

            Console.WriteLine("Весь массив:");
            lab.Print();
            Console.WriteLine();

            Console.WriteLine($"Количество компьютеров: {lab.CompAmount()}, сканеров: {lab.ScanAmount()}, планшетов: {lab.TablAmount()}\n");

            Console.WriteLine("Отсортированный по цене в порядке убывания массив:");
            lab.Sort();
            Console.WriteLine();


            //--------------------
            for (int i = 0; i < lab.Products.Count; i++)
            {
                try
                {
                    IProduct buff = lab[i];

                    try
                    {
                        if (lab[i].ToSell())
                        {
                            Console.Write($"Успешно продан товар ");
                        }
                    }
                    catch (InvalidPriceException)
                    {
                        Console.Write("Мы не можем продать по такой цене товар ");
                    }
                    catch (AlreadySoldException)
                    {
                        Console.Write("Продукт уже продан, наименование: ");
                    }
                    finally
                    {
                        lab[i].Print();
                    }

                }
                catch (CantSellException)
                {
                    Console.WriteLine("Невозможно продать товар, потому что такого товара нет");
                }
            }

            //--------------------
            try
            {
                IProduct buff = lab[lab.Products.Count - 1];

                try
                {
                    if (lab[lab.Products.Count - 1].ToSell())
                    {
                        Console.Write($"Успешно продан товар ");
                    }
                }
                catch (InvalidPriceException)
                {
                    Console.Write("Мы не можем продать по такой цене товар ");
                }
                catch (AlreadySoldException)
                {
                    Console.Write("Продукт уже продан, наименование: ");
                }
                finally
                {
                    lab[lab.Products.Count - 1].Print();
                }

            }
            catch (CantSellException)
            {
                Console.WriteLine("Невозможно продать товар, потому что такого товара нет");
            }
            
            //--------------------
            try
            {
                IProduct buff = lab[lab.Products.Count];

                try
                {
                    if (lab[lab.Products.Count].ToSell())
                    {
                        Console.Write($"Успешно продан товар ");
                    }
                }
                catch (InvalidPriceException)
                {
                    Console.Write("Мы не можем продать по такой цене товар ");
                }
                catch (AlreadySoldException)
                {
                    Console.Write("Продукт уже продан, наименование: ");
                }
                finally
                {
                    lab[lab.Products.Count].Print();
                }

            }
            catch (CantSellException)
            {
                Console.WriteLine("Невозможно продать товар, потому что такого товара нет");
            }
            try
            {
                String a = "";
                Console.WriteLine(a[1]);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                throw new DivideByZeroException();
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }

            /*int b = 9;
            Debug.Assert(b > 10, "Значение должно быть больше 10");*/
        }
    }
}
