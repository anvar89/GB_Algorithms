using System;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 2. Требуется реализовать класс двусвязного списка и операции вставки, удаления и поиска элемента в нём в соответствии с интерфейсом.");

            NodeList list = new NodeList();

            list.AddNode(1);
            list.AddNode(2);
            list.AddNode(3);
            list.AddNode(4);
            list.AddNode(5);
            list.AddNode(5);
            list.AddNodeAfter(list.FindNode(5), 400);

            Console.WriteLine(list);
        }


    }

    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }

    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    class NodeList : ILinkedList
    {
        private int count;

        Node head;
        Node tail;

        public void AddNode(int value)
        {
            Node newNode = new Node() { Value = value };
            if (head == null) 
                head = newNode;
            else
            {
                Node node = head;
                while (node.NextNode != null)
                {
                    node = node.NextNode;
                }

                node.NextNode = newNode;
                newNode.PrevNode = node;

                tail = newNode; 
            }
            count++;
        }

        public void AddNodeAfter(Node node, int value)
        {
            if (node == tail)
            {
                // если нужно вставить новый node после последнего, то воспользуемся готовым методом
                AddNode(value);
            }
            else
            {
                Node newNode = new Node() { Value = value };
                Node tmp = head;
                while (tmp != null)
                {
                    if (tmp.NextNode == node)
                    {
                        count++;
                        // Встраивание нового node в список
                        newNode.NextNode = node.NextNode;
                        newNode.PrevNode = node;
                        node.NextNode.PrevNode = newNode;
                        node.NextNode = newNode;
                        break;
                    }

                    tmp = tmp.NextNode;
                }
            }
        }

        public Node FindNode(int searchValue)
        {
            Node node = head;
            while (true)
            {
                if (node.Value == searchValue) return node;

                if (node.NextNode == null) break;
                node = node.NextNode;

            }

            return null;
        }

        public int GetCount() => count;
       

        public void RemoveNode(int index)
        {
            if (index >= 0 && index <= count)
            {
                Node node = head;
                for (int i = 0; i <= index; i++)
                {
                    if (node.NextNode != null)
                    {

                    }
                }
            }
        }

        void ILinkedList.RemoveNode(Node node)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            if (head != null)
            {
                Node node = head;
                string result ="Nodes: ";
                while(true)
                {
                    result += $"{node.Value} ";

                    if (node.NextNode == null) break;
                    node = node.NextNode;
                }
                return result;
            }
            else return "Пустой список";
        }

    }
}
