using System;
using MyTask.Models;

namespace MyTask.Services
{
	public class ElementsServices
	{
        public static void PrintElementsTree(in List<Element> elementsList)
        {
            // Группируем отсортированные элементы по ключу ParentId
            var groupsByParent = elementsList
                .OrderBy(e => e.Id)
                .ToLookup(e => e.ParentId);
            // Определяем корневой элемент
            var parent = elementsList.Find(e => e.ParentId == 0);
            // Проверяем его наличие в списке
            if (parent == null)
            {
                Console.WriteLine("В списке данных отсутствует корневой элемент");
                return;
            }
            // Выводим в консоль корневой элемент
            Console.WriteLine($"{parent.Id} {parent.ParentId} {parent.Text}");
            // Табуляция
            string tab = "";
            // Вывод в консоль дочерних элементов
            PrintChildrensTree(parent);

            void PrintChildrensTree(Element parent)
            {
                // Увеличиваем табуляцию для вложенных элементов
                tab += " ";
                // Перебором выводим дочерние элементы корневого элемента
                foreach (var child in groupsByParent[parent.Id])
                {
                    Console.WriteLine($"{tab}{child.Id} {child.ParentId} {child.Text}");
                    // Проверяем наличие дочерних элементов,
                    // при их наличии рекурсией вывводим их
                    if (groupsByParent[child.Id].Count() != 0)
                    {
                        PrintChildrensTree(child);
                        tab = tab.Remove(0, 1);
                    }
                }
            }
        }


    }
}

