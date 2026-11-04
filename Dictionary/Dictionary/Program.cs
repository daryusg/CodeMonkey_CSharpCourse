namespace Dictionary
{

    internal class Program
    {
        //Dictionary
        //Note: Both Keys and Values can be of any type, but the keys must be unique.

        private enum ResourceType
        {
            Wood,
            Stone,
            Iron,
            Gold
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Dictionary<ResourceType, int> resourceTypeAmountDictionary = new Dictionary<ResourceType, int>(){
                //{ ResourceType.Wood, 10 },
                { ResourceType.Stone, 5 },
                { ResourceType.Iron, 3 },
                //{ ResourceType.Gold, 1 }
            };

            int x = 1;
            Console.WriteLine("Dictionary contents (Resource Types and Amounts):");
            Console.WriteLine();
            Console.WriteLine($"{x}. foreach (KeyValuePair<ResourceType, int> keyValuePair in resourceTypeAmountDictionary)");
            Console.WriteLine("\t{keyValuePair.Key}, {keyValuePair.Value}");
            foreach (KeyValuePair<ResourceType, int> keyValuePair in resourceTypeAmountDictionary)
            {
                Console.WriteLine($"{keyValuePair.Key}, {keyValuePair.Value}");
            }
            x++;
            Console.WriteLine();

            resourceTypeAmountDictionary[ResourceType.Wood] = 15; // Add or update the amount of Wood in the dictionary
            resourceTypeAmountDictionary[ResourceType.Gold] = 1; // Add or update the amount of Gold in the dictionary

            Console.WriteLine($"{x}. foreach (ResourceType resourceType in resourceTypeAmountDictionary.Keys)");
            Console.WriteLine("\t{resourceType}, {resourceTypeAmountDictionary[resourceType]}");
            foreach (ResourceType resourceType in resourceTypeAmountDictionary.Keys)
            {
                Console.WriteLine($"{resourceType}, {resourceTypeAmountDictionary[resourceType]}");
            }
            x++;
            Console.WriteLine();

            Console.WriteLine($"{x}. foreach (var resource in resourceTypeAmountDictionary)");
            Console.WriteLine("\t{resource.Key}, {resource.Value}");
            foreach (var resource in resourceTypeAmountDictionary)
            {
                Console.WriteLine($"{resource.Key}, {resource.Value}");
            }
            Console.WriteLine();
        }
    }
}
