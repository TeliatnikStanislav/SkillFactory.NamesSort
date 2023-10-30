using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamesSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            NumberReader numberReader = new NumberReader();
            numberReader.NumberEvent += SortNames;
            
            while (true)
            {
            try 
            {
                    numberReader.Read();
                    Console.ReadLine();
            }
            catch(MyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            }
        }

        static void SortNames(int number, List<string> listNames)
        {
            switch (number)
            {
                case 1: listNames.Sort();
                ReadNames(listNames);
                break;
                case 2:
                    listNames.Sort((x, y) => string.Compare(y, x));
                    ReadNames(listNames);
                    break;
            }
        }

        static void ReadNames(List<string> listNames)
        {
            foreach (string name in listNames)
            {
                Console.WriteLine(name);
            }
        }
    }
    public class MyException : Exception
    {
        public MyException()
        { }

        public MyException(string message)
            : base(message)
        { }
    }
    class NumberReader
    {
        public delegate void NumberReaderDelegate(int number, List<string> listNames);
        public event NumberReaderDelegate NumberEvent;
        List<string> listNames = new List<string>
            {
                "Иванов",
                "Петров",
                "Aрбузов",
                "Бодров",
                "Дроздов"
            };
        public void Read()
        {
            Console.WriteLine();
            Console.WriteLine("Введите значение 1 или 2");
            
            int number = Convert.ToInt32(Console.ReadLine());
            if(number !=1 && number !=2 )
            {
                throw new MyException("Неверное значение");
            }
            NumberEnt(number, listNames);
        }

        protected virtual void NumberEnt(int number, List<string> listNames)
        {
            NumberEvent?.Invoke(number, listNames);
        }
    }
}
