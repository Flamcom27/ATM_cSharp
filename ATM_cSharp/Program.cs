using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM_cSharp
{
    public class Program
    {
        public static List<string> CalculateWithdraw(int sum, Dictionary<int, int> dict) 
        { 
            List<string> withdarw = new List<string>();
            int length;
            int output;
            do{
                length = Convert.ToString(sum).Length;
                switch (length) 
                {
                    case 3:
                        output = sum / 100;
                        dict[100] -= output;
                        withdarw.Add(String.Format("100$ x {0}", output));
                        sum -= output * 100;
                        continue;
                    case 2:
                        output = sum / 10;
                        foreach (int i in new List<int>() { 5, 2, 1 })
                        {
                            if (i <= output)
                            {
                                dict[i * 10] -= output / i;
                                withdarw.Add(String.Format("{0}$ x {1}", i * 10, output / i));
                                sum -= i * 10 * (output / i);
                                break;
                            }
                            else { continue; }
                        }
                        continue;
                    case 1:
                        output = sum;
                        foreach (int i in new List<int>() { 5, 2, 1 })
                        {
                            if (i <= output)
                            {
                                dict[i] -= output / i;
                                withdarw.Add(String.Format("{0}$ x {1}", i, output / i));
                                sum -= i * (output / i);
                                break;
                            }
                            else { continue; }
                        }
                        continue;
                }
            } while (sum != 0);
            return withdarw;
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
            Dictionary<int, int> moneyDict = CreateMoneyBank();
            int sum = InputSum();
            List<string> withdraw = CalculateWithdraw(sum, moneyDict);
            withdraw.ForEach(Console.WriteLine);
        }
    }
}