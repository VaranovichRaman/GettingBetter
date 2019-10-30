using D_and_D_demo.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Model
{
    class Base
    {
        public static void LikeMain()
        {
            Program pro = new Program();
            Base baseX = new Base();

            Hero hero = new Hero();
            hero.CoordinateX = 4;
            hero.CoordinateY = 4;
            bool flag = true;
            string[,] map = new string[50, 50];
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    map[i, j] = " ";
                }
            }
            CreateRoom(3, 3, 5, 9, map);
            CreateRoom(2, 8, 7, 10, map);
            CreateRoom(4, 14, 6, 11, map);
            baseX.CreateHero(hero.CoordinateX, hero.CoordinateY, 0, 0, map, hero);
            CreateDoor(5, 8, map);
            CreateDoor(7, 14, map);
            CreateDoor(4, 22, map);
            CreateMonster(5, 5, map);
            CreateMonster(3, 14, map);
            CreateMonster(5, 22, map);
            CreateStairs(3, 22, map);
            ShowMap(map);

            while (flag)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Backspace:
                        flag = false;
                        break;
                    case ConsoleKey.A:
                        Console.Clear();
                        if (baseX.CreateHero(hero.CoordinateX, hero.CoordinateY - 1, hero.CoordinateX, hero.CoordinateY, map, hero))
                        {
                            hero.CoordinateY -= 1;
                        }
                        ShowMap(map);
                        break;
                    case ConsoleKey.D:
                        Console.Clear();
                        if (baseX.CreateHero(hero.CoordinateX, hero.CoordinateY + 1, hero.CoordinateX, hero.CoordinateY, map, hero))
                        {
                            hero.CoordinateY += 1;
                        }
                        ShowMap(map);
                        break;
                    case ConsoleKey.S:
                        Console.Clear();
                        if (baseX.CreateHero(hero.CoordinateX + 1, hero.CoordinateY, hero.CoordinateX, hero.CoordinateY, map, hero))
                        {
                            hero.CoordinateX += 1;
                        }
                        ShowMap(map);
                        break;
                    case ConsoleKey.W:
                        Console.Clear();
                        if (baseX.CreateHero(hero.CoordinateX - 1, hero.CoordinateY, hero.CoordinateX, hero.CoordinateY, map, hero))
                        {
                            hero.CoordinateX -= 1;
                        }
                        ShowMap(map);
                        break;
                    default:
                        break;
                }

            }

            Console.ReadLine();
        }
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
        public static void CreateRoom(int baseX, int baseY, int x, int y, string[,] map)
        {
            for (int i = baseX; i < baseX + x; i++)
            {
                for (int j = baseY; j < baseY + y; j++)
                {
                    if (i == baseX || i == (baseX + x) - 1 || j == baseY || j == (baseY + y) - 1)
                    {
                        map[i, j] = "0";
                    }
                    else
                    {
                        map[i, j] = ".";
                    }
                }
            }
        }
        public static void CreateDoor(int x, int y, string[,] map)
        {
            map[x, y] = "D";
        }
        public static void CreateMonster(int x, int y, string[,] map)
        {
            map[x, y] = "M";
        }
        public static void CreateStairs(int x, int y, string[,] map)
        {
            map[x, y] = "S";
        }
        public bool CreateHero(int x, int y, int baseX, int baseY, string[,] map, Hero hero)
        {
            string check = WallDoorMonsterStairsCheck(x, y, map, hero);
            if (check == "wall")
            {
                return false;
            }
            else if (check == "door")
            {
                return false;
            }
            else if (check == "stairs")
            {
                Console.Clear();
                for (int i = 0; i < 50; i++)
                {
                    for (int j = 0; j < 50; j++)
                    {
                        map[i, j] = " ";
                    }
                }
                map[x, y] = "S";
                map[x + 4, y + 4] = "H";
                hero.CoordinateX += 1;
                //MoveClear(baseX, baseY, map);
                CreateRoom(3, 3, 3, 3, map);
                CreateRoom(2, 2, 7, 7, map);
                CreateRoom(5, 5, 5, 5, map);
                map[x, y + 1] = "0";
                map[x, y + 1] = "0";
                map[x, y - 1] = "0";
                map[x - 1, y + 1] = "0";
                map[x - 1, y - 1] = "0";
                map[x - 1, y] = "0";
                return true;
            }
            else
            {
                map[x, y] = "H";
                MoveClear(baseX, baseY, map);
                return true;
            }
        }
        public void MoveClear(int x, int y, string[,] map)
        {
            map[x, y] = ".";
        }
        public static void ShowMap(string[,] map)
        {
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (j < 25)
                    {
                        Console.Write(map[i, j]);
                    }
                    else
                    {
                        Console.WriteLine(map[i, j]);
                    }

                }
            }

        }
    }
}
