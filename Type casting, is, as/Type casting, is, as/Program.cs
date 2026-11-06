using System.Runtime.CompilerServices;

namespace Type_casting__is__as
{
    //Type_casting, is, as

    internal class Program
    {
        static void Main(string[] args)
        {
            IAttackable attackable = new Player();
            IAttackable attackableEnemy = new Enemy();

            Console.WriteLine(attackable.GetType());

            if (attackable.GetType() == typeof(Player))
                Console.WriteLine("attackable is Player");

            if (attackable.GetType() == typeof(IAttackable)) //doesn't run as true because it doesn't check if it implements the interface, it checks if it's the exact type of the interface
                Console.WriteLine("attackable is IAttackable");

            if (attackable.GetType().IsInterface) //...however can use attackable.GetType().IsInterface to check if it's an interface
                //ALSO see .IsInstanceOfType, .IsSubclassOf, .IsAssignableTo, .IsAssignableFrom
                Console.WriteLine("attackable is interface");

            //attackable.PlayerSayHello(); //CS1061 'IAttackable' does not contain a definition for 'PlayerSayHello' and no accessible extension method 'PlayerSayHello' accepting a first argument of type 'IAttackable' could be found (are you missing a using directive or an assembly reference?)
            if (attackable is Player player)
                player.PlayerSayHello("player");
            //or
            if (attackable is Player)
            {
                Console.WriteLine("attackable is Player");
                //attackablePlayer.PlayerSayHello(); //CS1061 'IAttackable' does not contain a definition for 'PlayerSayHello' and no accessible extension method 'PlayerSayHello' accepting a first argument of type 'IAttackable' could be found (are you missing a using directive or an assembly reference?)
                Player player1 = attackable as Player; //cast to Player
                player1.PlayerSayHello("player1");
                Player player2 = (Player)attackable; //cast to Player)
                player2.PlayerSayHello("player2");
            }

            if (attackable is IAttackable)
            {
                Console.WriteLine("attackable is IAttackable");
            }

            if (new Player() is IAttackable)
            {
                Console.WriteLine("new Player() is IAttackable");
            }

            if (new Player() is Unit)
            {
                Console.WriteLine("new Player() is Unit");
            }

            //-------------------------------------------------------

            Player player3 = new Player();
            Enemy enemy3 = new Enemy();

            //Player testPlayer = (Player)enemy3; //CS0030 Cannot convert type 'Type_casting__is__as.Program.Enemy' to 'Type_casting__is__as.Program.Player'
            //Player testPlayer = (Player)attackableEnemy; //runtime error: System.InvalidCastException: Unable to cast object of type 'Type_casting__is__as.Program+Enemy' to type 'Type_casting__is__as.Program+Player'.
            Player testPlayer = attackableEnemy as Player;
            Console.WriteLine(testPlayer == null ? "testPlayer is null" : "testPlayer is not null"); //displays "testPlayer is null"
            //IMPORTANT: the "as" operator will return null if the cast fails, while a direct cast will throw an exception.

            int i = 2;
            float f = (float)i; // Correct way to cast an integer to a float
            //float f = i as float; //CS0077 The 'as' operator must be used with a reference type or nullable type ('float' is a non-nullable value type)
            Console.WriteLine($"i: {i}, f: {f}");

            //boxing and unboxing
            int a = 5;
            object obj = a;
            int b = (int)obj; // Correct way to cast an object back to an integer

            //to come in Events:
            //EventHandler uses object as the sender parameter, so you can use the "as" operator to cast it to the appropriate type in the event handler.
        }

        private static void AttackObject(IAttackable attackable)
        {
            attackable.Damage();
        }

        void MyFunction() //defaults to private
        {
            int a = 2;
            Console.WriteLine("a:{0}", a);
            Console.WriteLine($"a:{a}");
        }

        public class Player : Unit, IAttackable, IMovable, IHasInventory
        {
            public int health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public void MyFunction()
            {
                Console.WriteLine("MyFunction");
            }
            public void Damage()
            {
                Console.WriteLine("Player damage");
            }

            public void PlayerSayHello(string name)
            {
                Console.WriteLine($"Hello, I'm {name}");
            }

            public override void Attack()
            {
                Console.WriteLine("Player attack");
            }
        }
        public class Enemy : Unit, IAttackable, IMovable
        {
            public int health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public override void Attack()
            {
                Console.WriteLine("Enemy attack");
            }

            public void MyFunction()
            {
                Console.WriteLine("MyFunction");
            }
            //public void Damage()
            //{
            //    Console.WriteLine("Enemy damage");
            //}
        }

        public interface IAttackable
        {
            //must be public
            //private void MyFunction(); //CS0501 must declare a body because it is not marked abstract, extern, or partial

            //public int health; //CS0525 interfaces cannot contain instance fields
            public int health { get; set; }

            void MyFunction(); //defaults to public

            public void Damage() //default
            {
                Console.WriteLine("Default damage");
            }

            public void Heal() //Note: extra method + code added in the interface this won't break the existing code but it will be available to any class that implements the interface.
            {
                Console.WriteLine("Default heal");
            }
        }

        public interface IMovable
        {
            public void Move()
            {
                Console.WriteLine("Default move");
            }
        }

        public interface IHasInventory
        {
            public void OpenInventory()
            {
                Console.WriteLine("Default open inventory");
            }
        }

        public abstract class Unit
        //public class Unit
        {
            //public float speed;
            protected float speed; //<---accessible by this class and derived classes

            public virtual void Move()
            {
                speed = 5;
                Console.WriteLine("Move Unit");
                //MovePlayer(); //does not exist in the current context
            }

            public abstract void Attack();
        }
    }
}
