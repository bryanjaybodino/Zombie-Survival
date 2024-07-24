using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Characters
{
    public class Textures
    {
        public class pistol
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                // Load each frame of the GIF
                _frames = new Texture2D[]
                {
                content.Load<Texture2D>("Characters/Pistol/1"),
                content.Load<Texture2D>("Characters/Pistol/2"),
                content.Load<Texture2D>("Characters/Pistol/3"),
                content.Load<Texture2D>("Characters/Pistol/4"),
                content.Load<Texture2D>("Characters/Pistol/5"),
                content.Load<Texture2D>("Characters/Pistol/6"),
                content.Load<Texture2D>("Characters/Pistol/7"),
                content.Load<Texture2D>("Characters/Pistol/8"),
                content.Load<Texture2D>("Characters/Pistol/9"),
                content.Load<Texture2D>("Characters/Pistol/10"),
                content.Load<Texture2D>("Characters/Pistol/11"),
                content.Load<Texture2D>("Characters/Pistol/12"),
                content.Load<Texture2D>("Characters/Pistol/13"),
                content.Load<Texture2D>("Characters/Pistol/14"),
                content.Load<Texture2D>("Characters/Pistol/15"),
                content.Load<Texture2D>("Characters/Pistol/16"),
                content.Load<Texture2D>("Characters/Pistol/17"),
                content.Load<Texture2D>("Characters/Pistol/18"),
                content.Load<Texture2D>("Characters/Pistol/19"),
                content.Load<Texture2D>("Characters/Pistol/20"),
                };
            }
        }
        public class pistol_attack
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                // Load each frame of the GIF
                _frames = new Texture2D[]
                {
                content.Load<Texture2D>("Characters/Pistol Attack/1"),
                content.Load<Texture2D>("Characters/Pistol Attack/2"),
                content.Load<Texture2D>("Characters/Pistol Attack/3"),
                };
            }
        }

    }
}
