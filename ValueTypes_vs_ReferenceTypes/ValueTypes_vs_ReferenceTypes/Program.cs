namespace ValueTypes_vs_ReferenceTypes
{
    //Value Types vs ReferenceTypes

    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.a = 7;
            MyClass myClass2 = myClass;
            myClass2.a = 5;
            Console.WriteLine("Value of myClass.a: " + myClass.a);
            Console.WriteLine("Value of myClass2.a: " + myClass2.a);
            Console.WriteLine("----------------------------------------------------------------------");

            int a = 7;
            int b = a;
            b = 5;
            Console.WriteLine("Value of a: " + a);
            Console.WriteLine("Value of b: " + b);
            Console.WriteLine("----------------------------------------------------------------------");

            MyStruct myStruct = new MyStruct();
            myStruct.a = 7;
            MyStruct myStruct2 = myStruct;
            myStruct2.a = 5;
            Console.WriteLine("Value of myStruct.a: " + myStruct.a);
            Console.WriteLine("Value of myStruct2.a: " + myStruct2.a);
            Console.WriteLine("----------------------------------------------------------------------");

            MyClass myClass3 = new MyClass();
            myClass3.a = 7;
            MyStruct myStruct3 = new MyStruct();
            myStruct3.a = 7;

            MyFunction(myClass3, myStruct3);

            Console.WriteLine("Value of myClass3.a: " + myClass3.a);
            Console.WriteLine("Value of myStruct3.a: " + myStruct3.a);
            Console.WriteLine("----------------------------------------------------------------------");

            int c = 7;
            int[] intArray = new int[] { 7 };
            MyFunction2(c, intArray);
            Console.WriteLine("Value of c: " + c);
            Console.WriteLine("Value of intArray[0]: " + intArray[0]);
            Console.WriteLine("----------------------------------------------------------------------");
        }

        private static void MyFunction2(int a, int[] intArray)
        {
            a = 5;
            intArray[0] = 5; //<---reference type, so the value of the original array will be changed
        }

        private static void MyFunction(MyClass myClass, MyStruct myStruct)
        {
            myClass.a = 5; //<---reference type, so the value of the original array will be changed
            myStruct.a = 5;
        }

        private class MyClass
        {
            public int a;
        }

        private struct MyStruct
        {
            public int a;
        }
    }
}
