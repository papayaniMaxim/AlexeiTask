using MyTask.Models;
using MyTask.Data;
using MyTask.Services;

// Создаем экземпляр объекта данных
Data data = new Data();
// Пробуем считать данные из csv файла
List<Element>? elementsList = data.GetElementsFromCSVFile();
// Проверяем считались ли данные, если нет используем данные по умолчанию
if (elementsList == null) elementsList = data.GetElementsFromDefaultData();
// Выводим дерево элементов
ElementsServices.PrintElementsTree(elementsList);