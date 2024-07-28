using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival
{
    internal class GameScreen
    {
        public static bool GameOver
        {
            get
            {
                if (Characters.Movements.HealhtBar <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
