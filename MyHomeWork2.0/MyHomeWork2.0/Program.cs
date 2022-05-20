using System;
using System.Text;
using MyHelperLibrary2._0;
using MyHomeWork2._0.LinkedList2;

// ЛинкедЛист заполняется с ввода в консоль u

namespace MyHomeWork2._0.LinkedList2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MyHelper.PrintWithColor("HelloWorld", ConsoleColor.DarkBlue, true);

            LinkedList list = new LinkedList();
            list.Inf();
            list.AddPeopleList();// количество PEOPLE определяет юзер
            list.PrintList();
            list.RemoveAt();
        }
    }
}
