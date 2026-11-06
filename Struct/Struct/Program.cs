namespace Struct
{
    //Struct
    //Note: Can be used for small data structures that have value semantics. Structs are value types and are stored on the stack, which can lead to better performance in certain scenarios.
    //However, they have some limitations compared to classes, such as not supporting inheritance and having a default constructor that cannot be defined by the user (prior to C# 9.0).

    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerStruct playerStruct1 = new PlayerStruct();
            playerStruct1.a = 1;
            PlayerClass playerClass1 = new PlayerClass();
            playerClass1.a = 1;

            TestFunctionStruct(playerStruct1);
            TestFunctionClass(playerClass1);

            Console.WriteLine($"playerStruct1.a: {playerStruct1.a}");
            Console.WriteLine($"playerClass1.a: {playerClass1.a}");
            //----------------------------------------------------------------------
            //PlayerStruct playerStruct2;
            //Console.WriteLine($"Struct2: {playerStruct2.a}"); // This will cause a compile error because the struct is not initialized
            PlayerStruct playerStruct2 = default;
            Console.WriteLine($"playerStruct2: {playerStruct2}\tplayerStruct2.a: {playerStruct2.a}");
            playerStruct2.a = 3;
            Console.WriteLine($"playerStruct2.a: {playerStruct2.a}");

            PlayerClass playerClass2 = default;
            //Console.WriteLine($"playerClass2: {playerClass2}\tplayerClass2.a: {playerClass2.a}"); //playerClass2 was null.
            Console.WriteLine($"playerClass2: {playerClass2}");
            //playerClass2.a = 3; //playerClass2 was null.
            //Console.WriteLine($"playerClass2.a: {playerClass2.a}");
            //----------------------------------------------------------------------
            PlayerStruct playerStruct3 = new PlayerStruct()
            {
                a = 5
            };
            Console.WriteLine($"playerStruct3.a: {playerStruct3.a}");
        }

        private static void TestFunctionStruct(PlayerStruct playerStruct)
        {
            playerStruct.a = 2;
        }

        private static void TestFunctionClass(PlayerClass playerClass)
        {
            playerClass.a = 2;
        }

        public class PlayerClass //reference type
        {
            public int a;
        }

        public struct PlayerStruct //value type
        {
            public int a;

            public PlayerStruct() //prior to version 9, you must define a constructor for a struct that takes parameters, and it must assign values to all fields of the struct. In version 9 and later, you can use parameterless constructors in structs. 
            {
            }
        }
        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        public class UnitClass : BaseClass
        {
            public int b;
        }

        public class BaseClass
        {
            public int a;
        }

        //public struct UnitStruct : BaseStruct //CS0527
        //public struct UnitStruct : BaseClass //CS0527
        //Note: This can be worked around by using interfaces, but it is not possible to inherit from a struct or class directly.
        public struct UnitStruct
        {
            public int b;
        }

        public struct BaseStruct
        {
            public int a;
        }
    }
}

