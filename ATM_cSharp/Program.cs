using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM_cSharp
{
    public class Program
    {
        public static Dictionary<int, int> CreateMoneyBank()
        {
            List<int> banknotes = new List<int>() { 1, 2, 5, 10, 20, 50, 100 };
            Dictionary<int, int> moneyDict = new Dictionary<int, int>();
            foreach (int i in banknotes)
            {
                moneyDict.Add(i, 100);
            }
            return moneyDict;
        }
        public static int InputWithdraw()
        {
            int money = Convert.ToInt32(Console.ReadLine());
            return money;
        }
        public static void Main(string[] args)
        {
            Dictionary<int, int> moneyDict = CreateMoneyBank();
            int Withdraw = InputWithdraw();
        }
    }
}