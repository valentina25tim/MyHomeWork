using System;
using System.Collections;
using MyHomeWork2._0.LinkedList2;
using System.Collections.Generic;
using System.Linq;

namespace MyHomeWork2._0.LinkedList2
{
    public class LinkedList
    {
        List<LinkedList> pl = new List<LinkedList>();

        public string FNane { get; set; }
        public string LName { get; set; }
        public int Ages { get; set; }
        public int Count { get; set; }

        public string FirstName1, LastName1;
        public int Age1;

        private int _numberPe;
        private int _count = 0;

        LinkedListNode head = null;

        public void Inf()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Эксепшены не прописаны)) Лучше придерживаться правил) \n");
        }
        private void AddNodeToFront()
        {
            Console.Write("\tNew person:\n First name -->");
            FirstName1 = Console.ReadLine();

            Console.Write(" Last name -->");
            LastName1 = Console.ReadLine();

            Console.Write(" Age-->");
            Age1 = Convert.ToInt32(Console.ReadLine());

            LinkedListNode node = new LinkedListNode(FirstName1, LastName1, Age1);

            //node.privious = new LinkedList();

            _count++;
            node.next = head;
            head = node;

        }

        public void AddPeopleList()
        {
            var show = false;
            do
            {
                Console.WriteLine("To add person input '+' or '-' to show a full list");

                var addShow = Convert.ToChar(Console.ReadLine());
                switch (addShow)
                {
                    case '+':
                        AddNodeToFront();
                        show = false;
                        break;
                    case '-':
                        show = true;
                        break;
                    default:
                        show = false;
                        break;
                }
            } while (show != true);

        }
        private void PrintListReady()
        {
            _numberPe = 1;

            foreach (LinkedList item in pl)
                Console.WriteLine($"{_numberPe++} - : {item.FNane} {item.LName} {item.Ages}");

        }
        public void RemoveAt()
        {
            Console.WriteLine("\tPeople list is ready:\n");

            PrintListReady();

            Console.Write("\nInput number to remove at list -->");
            var numb = int.Parse(Console.ReadLine());

            pl.RemoveAt(numb - 1);

            PrintListReady();
        }

        public void PrintList() // вывод 
        {
            Console.WriteLine("\n\t** List **\n Added people: ");

            LinkedListNode person = head;

            while (person != null)
            {
                pl.Add(new LinkedList()
                { FNane = Convert.ToString(person.FirstName), LName = Convert.ToString(person.LastName), Ages = person.Age });

                Console.WriteLine($" - {person.FirstName} {person.LastName} {person.Age}");// Выводится ссылочный список 
                person = person.next;
            }

        }
    }
}