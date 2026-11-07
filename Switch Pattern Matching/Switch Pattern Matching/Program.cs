namespace Switch_Pattern_Matching
{
    //Switch Pattern Matching

    internal class Program
    {
        static void Main(string[] args)
        {
            IAttackable attackable = new Player(){
                health = 66
            };
            //IAttackable attackable = new Enemy();
            //IAttackable attackable = new RedBarrel();

            Console.WriteLine(attackable.GetType());

            if (attackable is Player)
            {
            }
            if (attackable is Enemy)
            {
            }
            if (attackable is RedBarrel)
            {
            }

            switch (attackable)
            {
                case Player player when player.health > 50:
                    player.PlayerSayHello("Player. Health > 50");
                    break;

                case Player player:
                    player.PlayerSayHello("Player");
                    break;

                case Enemy enemy:
                    Console.WriteLine("Enemy");
                    break;

                case RedBarrel redBarrel:
                    Console.WriteLine("RedBarrel");
                    break;

                default:
                    Console.WriteLine("Default");
                    break;
            }
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
            public int health { get; set; }

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

        public class RedBarrel : IAttackable
        {
            public int health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public void MyFunction()
            {
                Console.WriteLine("MyFunction");
            }

            public void Damage()
            {
                Console.WriteLine("RedBarrel damage");
            }
        }

        public interface IAttackable
        {
            //must be public
            //public int health; //CS0525 interfaces cannot contain instance fields
            public int health { get; set; }

            //private void MyFunction(); //CS0501 must declare a body because it is not marked abstract, extern, or partial
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
