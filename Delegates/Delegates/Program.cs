using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Delegates
{
    //Delegates

    internal class Program
    {
        private delegate void AttackDelegate();
        private delegate int MyDelegate(string str);

        private static AttackDelegate attackAction;
        private static Action myAction1; //Action is a built-in delegate that takes no parameters and returns void. essentially the same as AttackDelegate
        private static Action<int> myAction2;

        private static Func<string, int> myFunc1;

        static void Main(string[] args)
        {
            attackAction = MeleeAttack;
            attackAction();
            Console.WriteLine("(the above is) melee attack");

            attackAction = RangedAttack;
            attackAction();
            Console.WriteLine("(the above is) ranged attack");

            attackAction = MeleeAttack;
            attackAction += RangedAttack;
            attackAction();
            Console.WriteLine("(the above is) melee attack + ranged attack");

            attackAction -= MeleeAttack;
            attackAction();
            Console.WriteLine("(the above is) - melee attack");
            Console.WriteLine();
            Console.WriteLine();

            myAction1 = MeleeAttack;
            myAction2 = MyTestAction;

            myAction1();
            myAction2(99);

            //MyDelegate myDelegate = MeleeAttack1; //CS0123 no overload for 'MeleeAttack' matches delegate 'MyDelegate'
            MyDelegate myDelegate = MyTestFunction;

            myFunc1 = MyTestFunction;
            Console.WriteLine(myFunc1("testing"));

            //--------------------------------------------------------------------------------
            //Note:
            //the following does the same as eg myAction3 = MeleeAttack
            //Action myAction1 = () => Console.WriteLine("Melee Attack");
            //or
            Action myAction3 = () =>
            {
                Console.WriteLine("Melee Attack");
            };

            //the following does the same as eg myAction4 = MyTestAction
            //Action<int> myAction4 = (int i) =>
            Action<int> myAction4 = (i) =>
            {
                Console.WriteLine("MyTestAction: " + i);
            };

            myAction3();
            myAction4(66);
            //--------------------------------------------------------------------------------
            //the following does the same as eg myFunc2 = MyTestFunction
            Func<string, int> myFunc2 = (myString) => 
            {
                Console.WriteLine("MyTestFunction: " + myString);
                return myString.Length;
            };

            myFunc2("testing2");
            //--------------------------------------------------------------------------------
            Func<int, bool> myFunc3 = (i) =>
            {
                return i > 5 ? true :false;
            };
            Console.WriteLine(myFunc3(3));
            Console.WriteLine(myFunc3(6));
            //--------------------------------------------------------------------------------
            Func<int, bool> myFunc4 = (i) => false;
            Console.WriteLine(myFunc4(3));
            Console.WriteLine(myFunc4(6));
        }

        private static void MeleeAttack()
        {
            Console.WriteLine("Melee Attack");
        }

        private static void RangedAttack()
        {
            Console.WriteLine("Ranged Attack");
        }

        private static int MyTestFunction(string myString) //doesn't have to have the same name as the delegate but must have the same signature
        {
            Console.WriteLine("MyTestFunction: " + myString);
            return myString.Length;
        }

        private static void MyTestAction(int i)
        {
            Console.WriteLine("MyTestAction: " + i);
        }
    }
}
