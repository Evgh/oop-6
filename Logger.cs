using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace oop_5
{
	class ConsoleLogger
    {
        public static void Write(Exception e)
        {
            Console.WriteLine($"{DateTime.Now} | Error | {e.Message}");
        }
    }

    class FileLogger
    {
        public static void Write(Exception e, string path = "D:/OOP/oop-6/oop-67.txt")
        {
            try
            {
                using (var sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine($"{DateTime.Now} | Error | {e.Message}");
                }
            }
            catch (Exception e0)
            {
                Console.WriteLine(e0.Message);
            }
        }
    }
}


