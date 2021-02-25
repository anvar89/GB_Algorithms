using System;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 1. Требуется реализовать класс двусвязного списка и операции вставки, удаления и поиска элемента в нём в соответствии с интерфейсом.");

            NodeList list = new NodeList();

            
            for (int i = 100; i < 105; i++)
            {
                list.AddNode(i);
            }
            testNodeList(list.ToString(), "100 101 102 103 104", "Тест: проверка метода добавления элемента в конец");

            list.AddNodeAfter(list.FindNode(102), 1000);
            testNodeList(list.ToString(), "100 101 102 1000 103 104", "Тест: проверка метода добавления элемента после указанного элемента");

            testNodeList(list.FindNode(1000).Value.ToString(), "1000", "Тест: поиска метода по значению");

            list.RemoveNode(5);
            testNodeList(list.ToString(), "100 101 102 1000 103", "Тест: удаление элемента по индексу");

            list.RemoveNode(list.FindNode(1000));
            testNodeList(list.ToString(), "100 101 102 103", "Тест: удаление указанного элемента");

            Console.ReadKey();
        }

        static void testNodeList(string output, string expectedOutput, string testText)
        {
            Console.WriteLine(testText);
            Console.WriteLine($"Ожидаемый вывод: {expectedOutput}");
            Console.WriteLine($"Реальный вывод: {output}");
            Console.WriteLine(output == expectedOutput ? "Тест пройден" : "Тест не пройден");
            Console.WriteLine();
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
                //Node node = head;
                //while (node.NextNode != null)
                //{
                //    node = node.NextNode;
                //}

                //node.NextNode = newNode;
                //newNode.PrevNode = node;
                //tail = newNode;

                if (tail != null)
                {
                    tail.NextNode = newNode;
                    newNode.PrevNode = tail;
                    tail = newNode;
                }
                else
                {
                    tail = newNode;
                    tail.PrevNode = head;
                    head.NextNode = tail;

                }
                
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
            if (index >= 0 && index < count)
            {
                int i = 0;
                Node node = head;

                do
                {
                    if (index == i)
                    {
                        RemoveNode(node);
                        break;
                    }
                    else
                    {
                        i++;
                        node = node.NextNode;
                    }
                }
                while (node != null);
            }
        }

        public void RemoveNode(Node node)
        {
            if (node == tail)
            {
                tail = node.PrevNode;
                tail.NextNode = null;
            }
            else
            {
                node.PrevNode.NextNode = node.NextNode;
                node.NextNode.PrevNode = node.PrevNode;
            }
            count--;
        }

        public override string ToString()
        {
            if (head != null)
            {
                Node node = head;
                string result = "";
                while(true)
                {
                    if (node != null)
                    {
                        result += $"{node.Value} ";
                        node = node.NextNode;
                    }
                    else return result.Trim();
                }
            }
            else return "Пустой список";
        }
    }

    
}
