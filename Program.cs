using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Линейный_список_Вставка
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleLinkedList list;
            list = new SingleLinkedList();
            list.Add(1, "Данил");
            list.Add(1, "Вячеслав");
            list.Add(1, "Александр");
            list.Add(1, "Гришка");
            list.Add(1, "Леха");
            string y;
            int n = 1;
            while (n != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Выберите функцию:");
                Console.WriteLine("0 - Выход");
                Console.WriteLine("1 - Просмотр списка");
                Console.WriteLine("2 - Добавление элемента в список");
                Console.WriteLine("3 - Удаление элемента из списка");
                Console.WriteLine("4 - Поиск элемента в списке");
                n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Console.WriteLine();
                        list.Print();
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Введите имя студента");
                        y = Convert.ToString(Console.ReadLine());
                        list.Add(1, y);
                        list.Print();
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine("Введите имя студента");
                        y = Convert.ToString(Console.ReadLine());
                        list.Delete(y);
                        list.Print();
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine("Введите имя студента:");
                        string nameToSearch = Console.ReadLine();
                        Node foundNode = list.SearchByName(nameToSearch);
                        if (foundNode != null)
                        {
                            Console.WriteLine($"Студент {nameToSearch} найден с номером {foundNode.Info}");
                        }
                        else
                        {
                            Console.WriteLine($"Студент {nameToSearch} не найден.");
                        }
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine();
                        n = 0;
                        break;
                }
            }
            list.Destroy();
            Console.ReadLine();
        }
    }
    public class Node
    {
        private int info;
        private Node link;
        private string name;
        
        public int Info
        {
            set { info = value; }
            get { return info; }
        }
        public Node Link
        {
            set { link = value; }
            get { return link; }
        }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public Node(int info, string name)       // конструктор
        {
            this.info = info;
            this.name = name;
            
        }
        public Node(int info, Node link, string name)    // конструктор
        {
            Info = info; Link = link; Name = name;
        }
    }


    public class SingleLinkedList // класс «Односвязные списки»
    {
        public int NOMER = 4999;
        private Node first; // ссылка на первый узел списка
        public Node First // свойства
        {
            get { return first; }
            set { first = value; }
        }
        public SingleLinkedList() // конструктор по умолчанию
        {
            first = null; // создание пустого списка
        }
        public SingleLinkedList(int[] dates, string[] names)
        {
            first = null; // создание пустого списка
            for (int i = 0; i < dates.Length; i++)
            {
                Node p = new Node(dates[i], first, names[i]); // вставка узла в начало списка
                first = p;
            }
        }
        public void Add(int key, string name)    //вставка в соответствии со значением ключа
        {
            NOMER += key;
            Node p=new Node(NOMER, name);   //создали новый элемент
            if(first == null)
            {
                first = p;
            }
            if (String.Compare(first.Name,p.Name) > 0)  //вставка перед первым элементом
            {
                p.Link = first;
                first = p;
                return;
            }
            Node pCur = first;
            Node pPred = first;
            while (pCur != null)
            {
                //pCur.Info
                if (String.Compare(pCur.Name,p.Name) > 0)
                {
                    pPred.Link = p;
                    p.Link = pCur;
                    return;
                }
                pPred = pCur;
                pCur = pCur.Link;
            }
            pPred.Link = p;
            p.Link = null;
        }
        public void Print()
        {
            Node p = first;
            Console.WriteLine();
            Console.WriteLine("Табельный номер фамилия \n");
            while (p != null)
            {
                Console.WriteLine(p.Info + " " + p.Name);
                p = p.Link;
            }
        }
        /*       public int Work() // суммирование значений информ. полей узлов списка
               {
                   Node p = first; int s = 0;
                   while (p != null)
                   {
                       s += p.Info; p = p.Link;
                   }
                   return s;
               }*/
        public void Delete(string name) // удаление элемента по имени
        {
            if (first == null)
            {
                Console.WriteLine("Список пуст, удаление невозможно");
                return;
            }

            if (first.Name == name) // если первый элемент нужно удалить
            {
                first = first.Link;
                return;
            }

            Node current = first;
            Node previous = null;

            while (current != null && current.Name != name)
            {
                previous = current;
                current = current.Link;
            }

            if (current == null) // если элемент не найден
            {
                Console.WriteLine("Элемент не найден, удаление невозможно");
                return;
            }

            previous.Link = current.Link; // переназначаем ссылки, чтобы пропустить удаляемый элемент
        }
        public Node SearchByName(string name)
        {
            Node current = first;
            while (current != null)
            {
                if (current.Name == name)
                {
                    return current;
                }
                current = current.Link;
            }
            return null;
        }
        public void Destroy() // разрушение списка
        {
            first = null;
        }
    }
}

