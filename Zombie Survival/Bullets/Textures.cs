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
        public class Bullets
        {
            public class Pistol
            {
                public static Texture2D _frames;
                public static void LoadContent(ContentManager content)
                {
                    _frames = content.Load<Texture2D>($"Characters/Pistol/Bullet");
                }
            }
        }
    }
}
