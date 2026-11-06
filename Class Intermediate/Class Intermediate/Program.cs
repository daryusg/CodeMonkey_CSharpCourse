using System.Runtime.CompilerServices;
using static Class_Intermediate.Program;

namespace Class_Intermediate
{
    //Class Intermediate

    internal class Program
    {
        private static Player playerTest;

        static void Main(string[] args)
        {
            //Unit unit = new Unit(); //CS0144 Cannot create an instance of the abstract class or interface 'Unit'
            Unit unit = new Player("testing2");
            Player player = new Player("testing");
            Enemy enemy = new Enemy("Green Goblin 1");
            //unit.Move();
            enemy.Move();
            player.Move();

            Console.WriteLine(player); //testing
            Console.WriteLine(enemy); //without ToString override: Class_Intermediate.Program+Enemy

            //Player player2 = enemy; //CS0266 Cannot implicitly convert type 'Class_Intermediate.Program.Enemy' to 'Class_Intermediate.Program.Player'. An explicit conversion exists (are you missing a cast?)
            //Unit unit2 = unit;
            Unit unit2 = player;
            //unit2 = player;
            player.MovePlayer();
            //unit2.MovePlayer(); //CS1061 'Unit' does not contain a definition for 'MovePlayer' and no accessible extension method 'MovePlayer' accepting a first argument of type 'Unit' could be found (are you missing a using directive or an assembly reference?)
            unit2 = enemy;
            unit2.Move(); //Move Enemy
            //unit2.speed = 3.0f; //CS0122 'Unit.speed' is inaccessible due to its protection level

            List<Unit> unitList = new List<Unit>
            {
                unit,
                player,
                enemy
            };

            MyFunction();
            GC.Collect();
            MyFunction2();
            MyFunction3();
        }

        private static void MyFunction()
        {
            Player player = new Player("Iron Man 2");
            Enemy enemy = new Enemy("Green Goblin 2");
            player.Move();
            enemy.Move();
        }

        private static void MyFunction2()
        {
            Unit unit = new Player("Spiderman 1");
            unit.Move();
        }

        private static void MyFunction3()
        {
            Program.playerTest = new Player("Spiderman 2");
            Program.playerTest.Move();
        }

        public class Player : Unit
        {
            private string playerName;

            public Player(string playerName)
            {
                this.playerName = playerName;
                speed = 5.0f;
            }

            ~Player()
            {
                Console.WriteLine("Player Destructor");
            }

            public void MovePlayer()
            {
                Console.WriteLine("Move Player");
            }

            public override void Move()
            {
                Console.WriteLine("Move " + playerName);
            }

            public override string ToString()
            {
                return $"Player: {playerName}";
            }

            public override void Attack()
            {
                throw new NotImplementedException();
            }
        }


        //ToInvestigate: composition vs inheritance

        //public class EnemyMeleeBoss : EnemyMelee //CS0509 'EnemyMeleeBoss': cannot derive from sealed type 'EnemyMelee'
        //{
        //    public EnemyMeleeBoss()
        //    {
        //        speed = 1.0f;
        //    }
        //    public override void Move()
        //    {
        //        Console.WriteLine("Move Enemy Melee Boss");
        //    }
        //}

        public sealed class EnemyMelee : Enemy
        {
            string enemyMeleeName;

            public EnemyMelee(string enemyMeleeName) : base(enemyMeleeName)
            {
                this.enemyMeleeName = enemyMeleeName;
                speed = 2.0f;
            }
            public override void Move()
            {
                Console.WriteLine("Move " + enemyMeleeName);
            }
        }

        public class Enemy : Unit
        {
            string enemyName;

            public Enemy(string enemyName)
            {
                this.enemyName = enemyName;
                speed = 3.0f;
            }
            ~Enemy()
            {
                Console.WriteLine("Enemy Destructor");
            }

            public override void Attack()
            {
                throw new NotImplementedException();
            }

            public override void Move()
            {
                Console.WriteLine("Move " + enemyName);
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