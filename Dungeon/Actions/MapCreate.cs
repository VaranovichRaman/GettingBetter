using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Actions
{
    class MapCreate
    {
        Check check = new Check();

        //Hero hero = new Hero();
        public static string[,] Map()
        {
            string[,] map = new string[50, 50];
            return map;
        }
        public string[,] FloorCreate(Hero hero)
        {
            var map = Map(); 
            FillMap(map);
            CreateRoom(3, 3, 5, 9, map);
            CreateRoom(2, 8, 7, 10, map);
            CreateRoom(5, 14, 7, 12, map);
            CreateHeroMark(hero.CoordinateX, hero.CoordinateY, 0, 0, map, hero.KeyAvailability, hero);
            CreateDoorMark(5, 8, map);
            CreateMonsterMark(5, 5, map);
            ShowMap(map);
            return map;
        }
        public void FillMap(string[,] map)
        {
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    map[i, j] = " ";
                }
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
        public static void CreateDoorMark(int x, int y, string[,] map)
        {
            map[x, y] = "D";
        }
        public static void CreateMonsterMark(int x, int y, string[,] map)
        {
            map[x, y] = "M";
        }
        public bool CreateHeroMark(int x, int y, int baseX, int baseY, string[,] map, bool key, Hero hero)
        {
            string checkObj = check.WallDoorMonsterStairsCheck(x, y, map, hero);
            if (checkObj == "wall")
            {
                return false;
            }
            else if (checkObj == "door")
            {
                return false;
            }
            else if (checkObj == "stairs")
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
                HeroMoveClear(baseX, baseY, map);
                return true;
            }
        }
        public void HeroMoveClear(int x, int y, string[,] map)
        {
            map[x, y] = ".";
        }
        public void ShowMap(string[,] map)
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
