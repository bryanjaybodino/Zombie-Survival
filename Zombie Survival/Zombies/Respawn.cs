using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Zombies
{
    internal class Respawn
    {

        private static double kills { get; set; } = 0;

        public static void AddKill()
        {
            kills++;
        }
        public static double TotalKills()
        {
            return kills;
        }

        public static void Start(List<Zombies.Sprite> zombies)
        {

            // Define map dimensions
            int mapWidth = Maps.Textures.Covid19.frames[0].Width;  // Replace with your map's actual width
            int mapHeight = Maps.Textures.Covid19.frames[0].Height; // Replace with your map's actual height
            int buffer = 100;    // Distance beyond the map where zombies can respawn

            float newX;
            float newY;
            Random random = new Random();
            // Generate random positions outside the map
            if (random.Next(2) == 0)  // Randomly decide if respawn on x or y edge
            {
                // Respawn on x edge
                newX = random.Next(0, 2) == 0 ? -buffer : mapWidth + buffer;
                newY = random.Next(-buffer, mapHeight + buffer);
            }
            else
            {
                // Respawn on y edge
                newX = random.Next(-buffer, mapWidth + buffer);
                newY = random.Next(0, 2) == 0 ? -buffer : mapHeight + buffer;
            }

            Vector2 NewPosition = new Vector2(newX, newY);
            zombies.Add(new Zombies.Sprite(NewPosition));
        }
    }
}
