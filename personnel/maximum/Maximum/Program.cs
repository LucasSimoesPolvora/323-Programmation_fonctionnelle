using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 4 players
            List<Player> players = new List<Player>()
            {
                new Player("Joe", 32),
                new Player("Jack", 30),
                new Player("William", 37),
                new Player("Averell", 25)
            };

            // Initialize search
            /*Player elder = players.First();
            int biggestAge = elder.Age;

            // search
            foreach (Player p in players)
            {
                if (p.Age > biggestAge) // memorize new elder
                {
                    elder = p;
                    biggestAge = p.Age; // for future loops
                }
            }*/

            // Sans linq
            /*Player p1 = players[0].Age > players[1].Age ? players[0] : players[1];
            Player p2 = players[2].Age > players[3].Age ? players[2] : players[3];
            Player elder = p1.Age > p2.Age ? p1 : p2;*/

            // Avec linq
            Player elder = players.Aggregate((current, next) => current.Age > next.Age ? current : next);

            Console.WriteLine($"Le plus agé est {elder.Name} qui a {elder.Age} ans");

            Console.ReadKey();
        }

        public class Player
        {
            private readonly string _name;
            private readonly int _age;

            public Player(string name, int age)
            {
                _name = name;
                _age = age;
            }

            public string Name => _name;

            public int Age => _age;
        }
    }
}

