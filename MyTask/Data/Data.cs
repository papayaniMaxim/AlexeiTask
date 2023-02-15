using System;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using MyTask.Models;
namespace MyTask.Data
{
    class Data
    {
        // Массив данных по умолчанию
        private string[] dataArray = new string[]
        {
        "5;0;aaa",
        "2;5;ggg",
        "1;2;bbb",
        "3;5;kkk",
        "4;1;lll",
        "6;2;vvv",
        "7;2;sss"
        };

        // Инициализируем список элемементов типа Element
        private List<Element> elementsList = new List<Element>();

        public List<Element> GetElementsFromDefaultData()
        {
            // Парсим данные и добавляем элемент типа Element в список 
            foreach (var item in dataArray)
            {
                string[] itemArray = item.Split(";");
                int id = Int32.Parse(itemArray[0]);
                int parentId = Int32.Parse(itemArray[1]);
                string text = itemArray[2];
                this.elementsList.Add(new Element
                {
                    Id = id,
                    ParentId = parentId,
                    Text = text,
                });
            };
            return this.elementsList;
        }

        public List<Element>? GetElementsFromCSVFile()
        {
            try
            {
                Console.WriteLine("Введите путь к файлу .csv");
                string? pathCsvFile = Console.ReadLine();
                if (pathCsvFile != null && pathCsvFile != "")
                {
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = false,
                    };
                    using (var reader = new StreamReader(pathCsvFile))
                    using (var csv = new CsvReader(reader, config))
                    {
                        return csv.GetRecords<Element>().ToList();
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка чтения файла:");
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}

