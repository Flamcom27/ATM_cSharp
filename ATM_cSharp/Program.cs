using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM_cSharp
{
    public class GlobalVars
    {       
        public Dictionary<int, int> moneyDict = new Dictionary<int, int>();
        public int sum;
        public List<string> withdraw = new List<string>();
    }
    public class Program
    {
        public static void SortWithdraw(GlobalVars GV, int output, int length, List<int> banknotes, int dec)
        {
            foreach (int i in banknotes)
            {
                output = GV.sum / dec;
                output *= dec;
                if (i <= output)
                {
                    GV.moneyDict[i] -= output / i;
                    GV.withdraw.Add(String.Format("{0}$ x {1}", i, output / i));
                    GV.sum -= output - (output % i);
                    if (output - i == 0) { break; }
                    else { continue; }
                }
                else { continue; }
            }
        }
        public static void CalculateWithdraw(GlobalVars GV) 
        { 
            int length;
            int output = 0;
            do{
                length = Convert.ToString(GV.sum).Length;
                switch (length) 
                {
                    case 3:
                        SortWithdraw(GV, output, length, new List<int> { 100 }, 100);
                        continue;
                    case 2:
                        SortWithdraw(GV, output, length, new List<int> { 50, 20, 10 }, 10);
                        continue;
                    case 1:
                        SortWithdraw(GV, output, length, new List<int> { 5, 2, 1 }, 1);
                        continue;
                }
            } while (GV.sum != 0);
        }
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
        public static int InputSum()
        {
            Console.Write("enter an amount you want to withdraw: ");
            int money = Convert.ToInt32(Console.ReadLine());
            return money;
        }
        public static void Main(string[] args)
        {
            var GV = new GlobalVars();
            GV.moneyDict = CreateMoneyBank();
            GV.sum = InputSum();
            CalculateWithdraw(GV);
            GV.withdraw.ForEach(Console.WriteLine);
        }
    }
}