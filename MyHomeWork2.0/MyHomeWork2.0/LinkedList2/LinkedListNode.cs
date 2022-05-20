using System;
using System.Collections;
using MyHomeWork2._0.LinkedList2;

namespace MyHomeWork2._0.LinkedList2
{

    public class LinkedListNode
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public LinkedListNode next;

        //public LinkedListNode privious;
        public LinkedListNode(string x, string y, int z)
        {
            FirstName = x;
            LastName = y;
            Age = z;
            next = null;
        }
    }
}