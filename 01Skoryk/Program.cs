using BusinessLayer.Entities;
using System;

namespace _01Skoryk
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c = new("Y", "V", "email.org");
            c.AddWallet("w", 100, Currency.USD, "");
            c.AddCategory("category", "");
            Wallet w = new Wallet(c, "w2", 200, Currency.USD, "");
            w.ConvertTo(Currency.UAH);
            Console.WriteLine(c.ToString());
        }
    }
}
