using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using FileParserNetStandard;
using ObjectLibrary;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise {
 
    
    internal class Delegate_Exercise {
        public static void Main(string[] args)
        {
            DataParser dataparser = new DataParser();
            CsvHandler csvhandler = new CsvHandler();

            Func<List<List<string>>, List<List<string>>> x = new Func<List<List<string>>, List<List<string>>>(dataparser.StripQuotes);
            x += dataparser.StripWhiteSpace;
            x += RemoveHash;
            csvhandler.ProcessCsv(@"C:\Users\Hamish\source\repos\Dip-Seminar-Delegates-Lambda-Linq_Exercises\data.csv", @"C:\Users\Hamish\source\repos\Dip-Seminar-Delegates-Lambda-Linq_Exercises\processed_data.csv", x);

        }

        public static List<List<string>> RemoveHash(List<List<string>> data)
        {
            for (int row = 0; row < data.Count; row++)
            {
                for (int index = 0; index < data[row].Count; index++)
                {
                    data[row][index] = data[row][index].Trim('#');
                }
            }
            return data;
        }
    }
}