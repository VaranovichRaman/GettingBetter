using D_and_D_demo.Actions;
using Dungeon.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Start start = new Start();
            start.StartOn();

            Console.ReadLine();

        }
    }
}
