using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon.Actions
{
    class Start
    {
        CreateHero hero = new CreateHero();
        //MapCreate map = new MapCreate();
        Controls controls = new Controls();
        Check check = new Check();
        public void StartOn()
        {
            Hero h = CreateHero.HeroCreation();
            MapCreate m = new MapCreate();
            var map = m.FloorCreate(h);
            controls.ControlButtons(h,map);



        }
    }
}
