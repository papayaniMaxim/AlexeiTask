using MyTask.Models;
using MyTask.Data;
using MyTask.Services;

// Создаем экземпляр объекта данных
Data data = new Data();
// Пробуем считать данные из csv файла
List<Element>? elementsList = data.GetElementsFromCSVFile();
// Проверяем считались ли данные, если нет используем данные по умолчанию
if (elementsList == null) elementsList = data.GetElementsFromDefaultData();
// Выводим дерево элементов ver. 1
Console.WriteLine("Вывод версия № 1");
ElementsServices.PrintElementsTree(elementsList);
Console.WriteLine();

// Выводим дерево элементов ver. 2
Console.WriteLine("Вывод версия № 2");
foreach (var element in elementsList)
{
    List<Element> children = elementsList.FindAll(e => e.ParentId == element.Id);
    element.Childrens = children;
}

Element? parent = elementsList.Find(e => e.ParentId == 0);
if (parent == null) return;
string tab = "";

ElementsServices.PrintChildsTree(parent, ref tab);
