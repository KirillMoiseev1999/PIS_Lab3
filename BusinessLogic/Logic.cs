using PIS_Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Logic
    {
        public class StringProcessor
        {
            public static string RemoveOuterQuotes(string input)
            {
                if (string.IsNullOrEmpty(input) || !input.Contains("'")) return input; //Обработка пустых или некорректных строк
                int startIndex = input.IndexOf('\'');
                int endIndex = input.LastIndexOf('\'');
                if (startIndex == -1 || endIndex == -1 || startIndex >= endIndex) return input;  //Обработка некорректных строк
                return input.Substring(startIndex + 1, endIndex - startIndex - 1);
            }

            public static string RemoveSpacesAndTrim(string input)
            {
                if (string.IsNullOrEmpty(input)) return input; // Обработка пустых строк
                return Regex.Replace(input.Trim(), @"\s+", " ");
            }

            public static double ParseDouble(string input)
            {
                if (double.TryParse(input, out double result))
                {
                    return result;
                }
                throw new ArgumentException($"Не удалось преобразовать строку '{input}' в число double.");
            }

            public static int ParseInt(string input)
            {
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                throw new ArgumentException($"Не удалось преобразовать строку '{input}' в число int.");
            }

            public static bool ParseBool(string input)
            {
                if (bool.TryParse(input, out bool result))
                {
                    return result;
                }
                throw new ArgumentException($"Не удалось преобразовать строку '{input}' в логическое значение.");
            }

            public static bool IsNumeric(string s)
            {
                return double.TryParse(s, out double _);
            }

            public static bool IsBool(string s)
            {
                return s.Equals("true", StringComparison.OrdinalIgnoreCase) || s.Equals("false", StringComparison.OrdinalIgnoreCase);
            }
        }

        public static Sea ParseSea(string input)
        {
            string[] parts = input.Split('\'');
            if (parts.Length != 3)
            {
                throw new ArgumentException("Некорректный формат входной строки. Должно быть 'Имя' Данные.");
            }

            string name = parts[1].Trim();
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Имя моря не может быть пустым."); 
            }
            string[] dataParts = parts[2].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (dataParts.Length < 2)
            {
                throw new ArgumentException("Недостаточно данных для создания объекта моря.");
            }

            double depth;
            double salinity;

            try
            {
                depth = double.Parse(dataParts[0]);
                salinity = double.Parse(dataParts[1]);
            }
            catch (FormatException ex)
            {
                throw new ArgumentException($"Ошибка при парсинге глубины или солёности: {ex.Message}", ex);
            }

            if (dataParts.Length == 2)
            {
                return new Sea(name, depth, salinity);
            }
            else if (dataParts.Length == 3)
            {
                    bool hasPort;
                    int countryCount;

                    if (bool.TryParse(dataParts[2], out hasPort))
                    {
                        return new MarginalSeas(name, depth, salinity, hasPort);
                    }
                    else if (int.TryParse(dataParts[2], out countryCount))
                    {
                        return new InlandSea(name, depth, salinity, countryCount);
                    }
                    else
                    {
                        throw new ArgumentException("Некорректное значение для дополнительного параметра.");
                    }
            }
            else
            {
                throw new ArgumentException("Неверное количество параметров.");
            }
        }
    }
           






        //public static Sea ParseSea(string input)
        //{
        //    string name = StringProcessor.RemoveOuterQuotes(input);
        //    input = StringProcessor.RemoveSpacesAndTrim(input.Substring(input.LastIndexOf('\'') + 1));

        //    if (string.IsNullOrEmpty(input)) throw new ArgumentException("Некорректный формат входных данных.");

        //    string[] parts = input.Split(' ');
        //    if (parts.Length != 2) throw new ArgumentException("Неверное количество данных в строке.");

        //    double depth;
        //    double salinity;
        //    try
        //    {
        //        depth = StringProcessor.ParseDouble(parts[0]);
        //        salinity = StringProcessor.ParseDouble(parts[1]);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        throw new ArgumentException($"Ошибка при парсинге чисел: {ex.Message}");
        //    }

        //    return new Sea(name, depth, salinity);
        //}

        //public static InlandSea ParseInlandSea(string input)
        //{

        //    string name = StringProcessor.RemoveOuterQuotes(input);
        //    input = StringProcessor.RemoveSpacesAndTrim(input.Substring(input.LastIndexOf('\'') + 1));

        //    string[] parts = input.Split(' ');
        //    if (parts.Length != 3) throw new ArgumentException("Неверное количество данных в строке.");


        //    double depth;
        //    double salinity;
        //    int count;

        //    try
        //    {
        //        depth = StringProcessor.ParseDouble(parts[0]);
        //        salinity = StringProcessor.ParseDouble(parts[1]);
        //        count = StringProcessor.ParseInt(parts[2]);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        throw new ArgumentException($"Ошибка при парсинге чисел: {ex.Message}");
        //    }

        //    return new InlandSea(name, depth, salinity, count);
        //}

        //public static MarginalSeas ParseMarginalSeas(string input)
        //{
        //    string name = StringProcessor.RemoveOuterQuotes(input);
        //    input = StringProcessor.RemoveSpacesAndTrim(input.Substring(input.LastIndexOf('\'') + 1));

        //    string[] parts = input.Split(' ');
        //    if (parts.Length != 3) throw new ArgumentException("Неверное количество данных в строке для MarginalSeas.");

        //    double depth;
        //    double salinity;
        //    bool port;

        //    if (string.IsNullOrEmpty(name)) //Проверяем на пустое имя
        //    {
        //        throw new ArgumentException("Name cannot be empty.");
        //    }

        //    try
        //    {
        //        depth = StringProcessor.ParseDouble(parts[0]);
        //        salinity = StringProcessor.ParseDouble(parts[1]);
        //        port = StringProcessor.ParseBool(parts[2]);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        throw new ArgumentException($"Ошибка при парсинге данных: {ex.Message}");
        //    }

        //    return new MarginalSeas(name, depth, salinity, port);
        //}


    
}
