using D_and_D_demo.Model;
using Dungeon;
using Dungeon.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_and_D_demo.Actions
{
    class FightClub
    {
        CreatureFromFileReader creature = new CreatureFromFileReader();
        
        Random diceRandom = new Random();
        public void RandomFight()
        {
            Hero hero = CreateHero.HeroCreation(); 
            Creature creatureFighter = creature.CreateCreatureList().ElementAt(
                diceRandom.Next(0, creature.CreateCreatureList().Count));
            Console.WriteLine($"\nThe greatest battle {hero.HeroName} VS {creatureFighter.CreatureName} begins now!\n");
            Console.WriteLine($"\nHP1: {hero.HeroHitPoints}, HP2: {creatureFighter.CreatureHitPoints}.\n");
            while (hero.HeroHitPoints > 0 && creatureFighter.CreatureHitPoints > 0)
            {
                var attackOfhero = diceRandom.Next(1, 20) + hero.HeroAttackMod;
                Console.WriteLine($"\n{hero.HeroName} attack: {attackOfhero}, " +
                       $"{creatureFighter.CreatureName} armore: {creatureFighter.CreatureArmor}.\n");
                if (attackOfhero >= creatureFighter.CreatureArmor)
                {
                    var heroDemage = (hero.HeroWeapon.Demage.NumberOfDices *
                             diceRandom.Next(1, (int)hero.HeroWeapon.Demage.SizeOfDice) +
                             hero.HeroWeapon.DemageMod);
                    creatureFighter.CreatureHitPoints -= heroDemage;
                    Console.WriteLine($"\n{hero.HeroName} dealt {heroDemage} points of damage.\n");
                }
                else
                {
                    Console.WriteLine($"\n{hero.HeroName} MISS!!!\n");
                }
                var attackOfcreatureFighter = diceRandom.Next(1, 20) + creatureFighter.CreatureAttackMod;
                Console.WriteLine($"\n{creatureFighter.CreatureName} attack: {attackOfcreatureFighter}, " +
                       $"{hero.HeroName} armore: {hero.HeroArmor}.\n");
                if (attackOfcreatureFighter >= hero.HeroArmor)
                {
                    var creatureDemage = (creatureFighter.CreatureWeapon.Demage.NumberOfDices *
                         diceRandom.Next(1, (int)creatureFighter.CreatureWeapon.Demage.SizeOfDice) +
                         creatureFighter.CreatureWeapon.DemageMod);
                    hero.HeroHitPoints -= creatureDemage;
                    Console.WriteLine($"\n{creatureFighter.CreatureName} dealt {creatureDemage} points of damage.\n");

                }
                else
                {
                    Console.WriteLine($"\n{creatureFighter.CreatureName} MISS!!!\n");
                }

                Console.WriteLine($"\nAfter this round: {hero.HeroName} has {hero.HeroHitPoints} HP | " +
                    $"{creatureFighter.CreatureName} has {creatureFighter.CreatureHitPoints} HP.\n");
                Console.ReadLine();
                if (hero.HeroHitPoints <= 0)
                {
                    Console.WriteLine($"\n{creatureFighter.CreatureName} WIN!!!\n");
                }
                else if (creatureFighter.CreatureHitPoints <= 0)
                {
                    Console.WriteLine($"\n{hero.HeroName} WIN!!!\n");
                }
            }
        }       
    }
}
