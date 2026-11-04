using System.Collections;

namespace OtherCollections
{
    //Other Collections
    internal class Program
    {
        static void Main(string[] args)
        {
            //Stack - First In Last Out (FILO) collection
            Console.WriteLine("Stack - First In Last Out (FILO) collection");
            Stack<string> nameStack = new Stack<string>();
            nameStack.Push("Code Monkey");
            nameStack.Push("Iron Man");
            nameStack.Push("Spider Man");

            Console.WriteLine(nameStack.Pop()); // Spider Man
            Console.WriteLine(nameStack.Peek()); // Iron Man
            //TryPop tries to get the value from the stack and returns true if it was successful, otherwise false
            nameStack.TryPop(out string name_pop); //note: i changed to name_pop to stop later "name" conflict. the out variable is declared in the method call
            Console.WriteLine(name_pop); // Iron Man

            Console.WriteLine();

            //Queue - First In First Out (FIFO) collection
            Console.WriteLine("Queue - First In First Out (FIFO) collection");
            Queue<string> nameQueue = new Queue<string>();
            nameQueue.Enqueue("Code Monkey");
            nameQueue.Enqueue("Iron Man");
            nameQueue.Enqueue("Spider Man");

            Console.WriteLine(nameQueue.Dequeue()); // Code Monkey
            Console.WriteLine(nameQueue.Peek()); // Iron Man

            Console.WriteLine();

            //HashSet - Unordered collection of unique elements
            Console.WriteLine("HashSet - Unordered collection of unique elements");
            HashSet<string> nameHashSet1 = new HashSet<string>();
            nameHashSet1.Add("Code Monkey");
            nameHashSet1.Add("Code Monkey");
            nameHashSet1.Add("Code Monkey");
            nameHashSet1.Add("Iron Man");
            nameHashSet1.Add("Spider Man");
            foreach (string name in nameHashSet1)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine($"Count: {nameHashSet1.Count}"); // 3, because duplicates are not allowed
            Console.WriteLine();

            HashSet<string> nameHashSet2 = new HashSet<string>();
            nameHashSet2.Add("Code Monkey 2");
            nameHashSet2.Add("Code Monkey 2");
            nameHashSet2.Add("Code Monkey 2");
            nameHashSet2.Add("Iron Man 2");
            nameHashSet2.Add("Spider Man 2");
            //
            //
            nameHashSet1.UnionWith(nameHashSet2);
            foreach (string name in nameHashSet1)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine($"Count: {nameHashSet1.Count}"); // 6, because duplicates are not allowed
            Console.WriteLine();

            Console.WriteLine();

            //SortedSet - Sorted collection of unique elements
            //SortedList - Sorted collection of key-value pairs
            Console.WriteLine("SortedList - Sorted collection of key-value pairs");
            SortedList<int, string> sortedList = new SortedList<int, string>();
            sortedList.Add(3, "Value3");
            sortedList.Add(2, "Value2");
            sortedList.Add(6, "Value6");
            sortedList.Add(5, "Value5");
            sortedList.Add(4, "Value4");
            sortedList.Add(1, "Value1");
            foreach(var item in sortedList)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            Console.WriteLine();

            //SortedDictionary - Sorted collection of key-value pairs
            Console.WriteLine("SortedDictionary - Sorted collection of key-value pairs");
            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
            sortedDictionary.Add("Key3", "Value3");
            sortedDictionary.Add("Key2", "Value2");
            sortedDictionary.Add("Key6", "Value6");
            sortedDictionary.Add("Key5", "Value5");
            sortedDictionary.Add("Key4", "Value4");
            sortedDictionary.Add("Key1", "Value1");
            foreach(var item in sortedDictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
