using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Actions
{
    class Controls
    {
        //Hero hero = new Hero();
        MapCreate mapObj = new MapCreate();
        public void ControlButtons(Hero hero, string[,] map)
        {
            bool flag = true;
            while (flag)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Backspace:
                        flag = false;
                        break;
                    case ConsoleKey.A:
                        Console.Clear();
                        if (mapObj.CreateHeroMark(hero.CoordinateX, hero.CoordinateY - 1, hero.CoordinateX, hero.CoordinateY, map, hero.KeyAvailability,hero))
                        {
                            hero.CoordinateY -= 1;
                        }
                        mapObj.ShowMap(map);
                        break;
                    case ConsoleKey.D:
                        Console.Clear();
                        if (mapObj.CreateHeroMark(hero.CoordinateX, hero.CoordinateY + 1, hero.CoordinateX, hero.CoordinateY, map, hero.KeyAvailability,hero))
                        {
                            hero.CoordinateY += 1;
                        }
                        mapObj.ShowMap(map);
                        break;
                    case ConsoleKey.S:
                        Console.Clear();
                        if (mapObj.CreateHeroMark(hero.CoordinateX + 1, hero.CoordinateY, hero.CoordinateX, hero.CoordinateY, map, hero.KeyAvailability,hero))
                        {
                            hero.CoordinateX += 1;
                        }
                        mapObj.ShowMap(map);
                        break;
                    case ConsoleKey.W:
                        Console.Clear();
                        if (mapObj.CreateHeroMark(hero.CoordinateX - 1, hero.CoordinateY, hero.CoordinateX, hero.CoordinateY, map, hero.KeyAvailability,hero))
                        {
                            hero.CoordinateX -= 1;
                        }
                        mapObj.ShowMap(map);
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
