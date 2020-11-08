using System;
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
        protected CONDITION IsSold { get; set; }

        void ToSell()
        {
            if (IsSold == 0)
            {
                Console.WriteLine("Товар продан.");
                IsSold = CONDITION.SOLD;
            }
            else
            {
                Console.WriteLine("Товар нельзя продать снова -- он уже продан.");
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
