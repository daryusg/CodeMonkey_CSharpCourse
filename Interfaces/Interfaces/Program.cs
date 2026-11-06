namespace Interfaces
{
    //Interfaces

    //Note: An interface is a contract that defines a set of methods and properties that a class must implement. It cannot contain fields or implementation details.
    //They allow for polymorphism and can be used to define common behavior across different classes.

    internal class Program
    {
        static void Main(string[] args)
        {
            IAttackable attackablePlayer = new Player();
            IAttackable attackableEnemy = new Enemy();

            attackablePlayer.Damage();
            attackableEnemy.Damage();

            AttackObject(new Player());
            AttackObject(new Enemy());
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

        public class Player : IAttackable, IMovable, IHasInventory
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
        }
        public class Enemy : IAttackable, IMovable
        {
            public int health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
    }
}
