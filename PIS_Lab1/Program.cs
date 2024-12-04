using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace PIS_Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ЧТЕНИЕ С ФАЙЛА 
            string filePath = "test.txt";
            string[] lines = File.ReadAllLines(filePath);

            // ЧТЕНИЕ СО СТРОКИ 
            //string linesX = "1 'Каспийское море' 123,5 14,3     \r\n " +
            //    "            2 'Внутреннее     море' 100      10   5 \r\n" +
            //    " 3 'Карское     море' 100      10   true \r\n         " +
            //    "3 'Арайское     море' 100      10   false \r\n" +
            //    "   1 'Каспийское           море' 1000    14,323113    \r\n" +
            //    "2  '_Qwerty     море' 1,3179      101   52";
            //string[] stringSeparators = new string[] { "\r\n" };
            //string[] lines = linesX.Split(stringSeparators, StringSplitOptions.None);

            List<Sea> seaList = new List<Sea>();
            ////foreach (string line in lines)
            ////{
            ////    string nowString = Logic.RemovingSpaces(line);

            ////    char option = nowString[0];
            ////    nowString = Logic.RemoveOption(nowString);

            ////    switch (option)
            ////    {
            ////        case '1':
            ////            seaList.Add(Logic.ParsFirst(nowString));
            ////            break;

            ////        case '2':
            ////            seaList.Add(Logic.ParsSecond(nowString));
            ////            break;

            ////        case '3':
            ////            seaList.Add(Logic.ParsThird(nowString));
            ////            break;
            ////    }  
            ////}

            ////foreach (Sea sea in seaList)
            ////{
            ////    sea.Print();
            ////}
        }
    }
}
