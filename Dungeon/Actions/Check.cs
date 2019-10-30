using D_and_D_demo.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Actions
{
    class Check
    {
        public string WallDoorMonsterStairsCheck(int x, int y, string[,] map, Hero hero)
        {
            if (map[x, y] == "0")
            {
                return "wall";
            }
            else if (map[x, y] == "D")
            {
                if (hero.KeyAvailability == false)
                {
                    return "door";
                }
                else
                {
                    hero.KeyAvailability = false;
                    return " ";
                }
            }
            else if (map[x, y] == "M")
            {
                FightClub club = new FightClub();
                club.RandomFight();
                //club.ChoosenCreturesFight();    
                hero.KeyAvailability = true;
                Console.WriteLine($"Now you have a key!");
                Console.ReadLine();

                return " ";
            }
            else if (map[x, y] == "S")
            {
                return "stairs";
            }
            else
            {
                return " ";
            }


        }
        public string WallCheck(int x, int y, string[,] map)
        {
            if (map[x, y] == "0")
            {
                return "wall";
            }         
            else
            {
                return " ";
            }
        }
        public string DoorCheck(int x, int y, string[,] map, bool key)
        {
            if (map[x, y] == "D")
            {
                return "door";
            }
            else
            {
                return " ";
            }
        }
        public string MonsterCheck(int x, int y, string[,] map, bool key)
        {
            if (map[x, y] == "M")
            {
                FightClub club = new FightClub();
                club.RandomFight();
                //club.ChoosenCreturesFight();
                key = true;
                Console.WriteLine($"Now you have a key!");
                Console.ReadLine();

                return " ";
            }
            else
            {
                return " ";
            }
        }
    }
    
}
