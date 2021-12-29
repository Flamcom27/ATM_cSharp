using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM_cSharp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int, int> moneyDict = new Dictionary<int, int>();
            moneyDict.Add(1, 2);
            moneyDict.Add(2, 6);
            foreach (int i in moneyDict.Keys)
            {
                Console.WriteLine("key:{0} value{1}", i, moneyDict[i]);
            }
        }
    }
}