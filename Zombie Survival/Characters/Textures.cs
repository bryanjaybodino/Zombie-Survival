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

        public class pistol_reload
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                // Load each frame of the GIF
                _frames = new Texture2D[]
                {
                content.Load<Texture2D>("Characters/Pistol Reload/1"),
                content.Load<Texture2D>("Characters/Pistol Reload/2"),
                content.Load<Texture2D>("Characters/Pistol Reload/3"),
                content.Load<Texture2D>("Characters/Pistol Reload/4"),
                content.Load<Texture2D>("Characters/Pistol Reload/5"),
                content.Load<Texture2D>("Characters/Pistol Reload/6"),
                content.Load<Texture2D>("Characters/Pistol Reload/7"),
                content.Load<Texture2D>("Characters/Pistol Reload/8"),
                content.Load<Texture2D>("Characters/Pistol Reload/9"),
                content.Load<Texture2D>("Characters/Pistol Reload/10"),
                content.Load<Texture2D>("Characters/Pistol Reload/11"),
                content.Load<Texture2D>("Characters/Pistol Reload/12"),
                content.Load<Texture2D>("Characters/Pistol Reload/13"),
                content.Load<Texture2D>("Characters/Pistol Reload/14"),
                content.Load<Texture2D>("Characters/Pistol Reload/15"),
                };
            }
        }




        public class rifle
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                // Load each frame of the GIF
                _frames = new Texture2D[]
                {
                content.Load<Texture2D>("Characters/Rifle/1"),
                content.Load<Texture2D>("Characters/Rifle/2"),
                content.Load<Texture2D>("Characters/Rifle/3"),
                content.Load<Texture2D>("Characters/Rifle/4"),
                content.Load<Texture2D>("Characters/Rifle/5"),
                content.Load<Texture2D>("Characters/Rifle/6"),
                content.Load<Texture2D>("Characters/Rifle/7"),
                content.Load<Texture2D>("Characters/Rifle/8"),
                content.Load<Texture2D>("Characters/Rifle/9"),
                content.Load<Texture2D>("Characters/Rifle/10"),
                content.Load<Texture2D>("Characters/Rifle/11"),
                content.Load<Texture2D>("Characters/Rifle/12"),
                content.Load<Texture2D>("Characters/Rifle/13"),
                content.Load<Texture2D>("Characters/Rifle/14"),
                content.Load<Texture2D>("Characters/Rifle/15"),
                content.Load<Texture2D>("Characters/Rifle/16"),
                content.Load<Texture2D>("Characters/Rifle/17"),
                content.Load<Texture2D>("Characters/Rifle/18"),
                content.Load<Texture2D>("Characters/Rifle/19"),
                content.Load<Texture2D>("Characters/Rifle/20"),
                };
            }
        }

        public class rifle_attack
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                // Load each frame of the GIF
                _frames = new Texture2D[]
                {
                content.Load<Texture2D>("Characters/Rifle Attack/1"),
                content.Load<Texture2D>("Characters/Rifle Attack/2"),
                content.Load<Texture2D>("Characters/Rifle Attack/3"),
                };
            }
        }

        public class rifle_reload
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                // Load each frame of the GIF
                _frames = new Texture2D[]
                {
                content.Load<Texture2D>("Characters/Rifle Reload/1"),
                content.Load<Texture2D>("Characters/Rifle Reload/2"),
                content.Load<Texture2D>("Characters/Rifle Reload/3"),
                content.Load<Texture2D>("Characters/Rifle Reload/4"),
                content.Load<Texture2D>("Characters/Rifle Reload/5"),
                content.Load<Texture2D>("Characters/Rifle Reload/6"),
                content.Load<Texture2D>("Characters/Rifle Reload/7"),
                content.Load<Texture2D>("Characters/Rifle Reload/8"),
                content.Load<Texture2D>("Characters/Rifle Reload/9"),
                content.Load<Texture2D>("Characters/Rifle Reload/10"),
                content.Load<Texture2D>("Characters/Rifle Reload/11"),
                content.Load<Texture2D>("Characters/Rifle Reload/12"),
                content.Load<Texture2D>("Characters/Rifle Reload/13"),
                content.Load<Texture2D>("Characters/Rifle Reload/14"),
                content.Load<Texture2D>("Characters/Rifle Reload/15"),
                content.Load<Texture2D>("Characters/Rifle Reload/16"),
                content.Load<Texture2D>("Characters/Rifle Reload/17"),
                content.Load<Texture2D>("Characters/Rifle Reload/18"),
                content.Load<Texture2D>("Characters/Rifle Reload/19"),
                content.Load<Texture2D>("Characters/Rifle Reload/20"),
                };
            }
        }



        public class knife
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                // Load each frame of the GIF
                _frames = new Texture2D[]
                {
                content.Load<Texture2D>("Characters/Knife/1"),
                content.Load<Texture2D>("Characters/Knife/2"),
                content.Load<Texture2D>("Characters/Knife/3"),
                content.Load<Texture2D>("Characters/Knife/4"),
                content.Load<Texture2D>("Characters/Knife/5"),
                content.Load<Texture2D>("Characters/Knife/6"),
                content.Load<Texture2D>("Characters/Knife/7"),
                content.Load<Texture2D>("Characters/Knife/8"),
                content.Load<Texture2D>("Characters/Knife/9"),
                content.Load<Texture2D>("Characters/Knife/10"),
                content.Load<Texture2D>("Characters/Knife/11"),
                content.Load<Texture2D>("Characters/Knife/12"),
                content.Load<Texture2D>("Characters/Knife/13"),
                content.Load<Texture2D>("Characters/Knife/14"),
                content.Load<Texture2D>("Characters/Knife/15"),
                content.Load<Texture2D>("Characters/Knife/16"),
                content.Load<Texture2D>("Characters/Knife/17"),
                content.Load<Texture2D>("Characters/Knife/18"),
                content.Load<Texture2D>("Characters/Knife/19"),
                content.Load<Texture2D>("Characters/Knife/20"),
                };
            }
        }



        public class knife_attack
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                // Load each frame of the GIF
                _frames = new Texture2D[]
                {
                content.Load<Texture2D>("Characters/Knife Attack/1"),
                content.Load<Texture2D>("Characters/Knife Attack/2"),
                content.Load<Texture2D>("Characters/Knife Attack/3"),
                content.Load<Texture2D>("Characters/Knife Attack/4"),
                content.Load<Texture2D>("Characters/Knife Attack/5"),
                content.Load<Texture2D>("Characters/Knife Attack/6"),
                content.Load<Texture2D>("Characters/Knife Attack/7"),
                content.Load<Texture2D>("Characters/Knife Attack/8"),
                content.Load<Texture2D>("Characters/Knife Attack/9"),
                content.Load<Texture2D>("Characters/Knife Attack/10"),
                content.Load<Texture2D>("Characters/Knife Attack/11"),
                content.Load<Texture2D>("Characters/Knife Attack/12"),
                content.Load<Texture2D>("Characters/Knife Attack/13"),
                content.Load<Texture2D>("Characters/Knife Attack/14"),
                content.Load<Texture2D>("Characters/Knife Attack/15"),
                };
            }
        }




        public class shotgun
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                // Load each frame of the GIF
                _frames = new Texture2D[]
                {
                content.Load<Texture2D>("Characters/Shotgun/1"),
                content.Load<Texture2D>("Characters/Shotgun/2"),
                content.Load<Texture2D>("Characters/Shotgun/3"),
                content.Load<Texture2D>("Characters/Shotgun/4"),
                content.Load<Texture2D>("Characters/Shotgun/5"),
                content.Load<Texture2D>("Characters/Shotgun/6"),
                content.Load<Texture2D>("Characters/Shotgun/7"),
                content.Load<Texture2D>("Characters/Shotgun/8"),
                content.Load<Texture2D>("Characters/Shotgun/9"),
                content.Load<Texture2D>("Characters/Shotgun/10"),
                content.Load<Texture2D>("Characters/Shotgun/11"),
                content.Load<Texture2D>("Characters/Shotgun/12"),
                content.Load<Texture2D>("Characters/Shotgun/13"),
                content.Load<Texture2D>("Characters/Shotgun/14"),
                content.Load<Texture2D>("Characters/Shotgun/15"),
                content.Load<Texture2D>("Characters/Shotgun/16"),
                content.Load<Texture2D>("Characters/Shotgun/17"),
                content.Load<Texture2D>("Characters/Shotgun/18"),
                content.Load<Texture2D>("Characters/Shotgun/19"),
                content.Load<Texture2D>("Characters/Shotgun/20"),
                };
            }
        }

        public class shotgun_attack
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                // Load each frame of the GIF
                _frames = new Texture2D[]
                {
                content.Load<Texture2D>("Characters/Shotgun Attack/1"),
                content.Load<Texture2D>("Characters/Shotgun Attack/2"),
                content.Load<Texture2D>("Characters/Shotgun Attack/3"),
                };
            }
        }

        public class shotgun_reload
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                // Load each frame of the GIF
                _frames = new Texture2D[]
                {
                content.Load<Texture2D>("Characters/Shotgun Reload/1"),
                content.Load<Texture2D>("Characters/Shotgun Reload/2"),
                content.Load<Texture2D>("Characters/Shotgun Reload/3"),
                content.Load<Texture2D>("Characters/Shotgun Reload/4"),
                content.Load<Texture2D>("Characters/Shotgun Reload/5"),
                content.Load<Texture2D>("Characters/Shotgun Reload/6"),
                content.Load<Texture2D>("Characters/Shotgun Reload/7"),
                content.Load<Texture2D>("Characters/Shotgun Reload/8"),
                content.Load<Texture2D>("Characters/Shotgun Reload/9"),
                content.Load<Texture2D>("Characters/Shotgun Reload/10"),
                content.Load<Texture2D>("Characters/Shotgun Reload/11"),
                content.Load<Texture2D>("Characters/Shotgun Reload/12"),
                content.Load<Texture2D>("Characters/Shotgun Reload/13"),
                content.Load<Texture2D>("Characters/Shotgun Reload/14"),
                content.Load<Texture2D>("Characters/Shotgun Reload/15"),
                content.Load<Texture2D>("Characters/Shotgun Reload/16"),
                content.Load<Texture2D>("Characters/Shotgun Reload/17"),
                content.Load<Texture2D>("Characters/Shotgun Reload/18"),
                content.Load<Texture2D>("Characters/Shotgun Reload/19"),
                content.Load<Texture2D>("Characters/Shotgun Reload/20"),
                };
            }
        }

    }
}
