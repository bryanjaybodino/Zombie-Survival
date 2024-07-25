using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Bullets
{
    public class Textures
    {
        public static class Bullets
        {
            public static class Pistol
            {
                public static Texture2D frames;
                public static void LoadContent(ContentManager content)
                {
                    frames = content.Load<Texture2D>($"Characters/Pistol/Bullet");
                }
            }

            public static class Rifle
            {
                public static Texture2D frames;
                public static void LoadContent(ContentManager content)
                {
                    frames = content.Load<Texture2D>($"Characters/Rifle/Bullet");
                }
            }

            public static class Shotgun
            {
                public static Texture2D frames;
                public static void LoadContent(ContentManager content)
                {
                    frames = content.Load<Texture2D>($"Characters/Shotgun/Bullet");
                }
            }
        }
    }
}
