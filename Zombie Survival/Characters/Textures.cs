using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Zombie_Survival.Characters
{
    public class Textures
    {
        // Define a generic method to load textures
        private static Texture2D[] LoadTextures(ContentManager content, string directoryPath, int numFrames)
        {
            Texture2D[] frames = new Texture2D[numFrames];
            for (int i = 0; i < numFrames; i++)
            {
                frames[i] = content.Load<Texture2D>($"{directoryPath}/{i + 1}");
            }
            return frames;
        }

        public class Pistol
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                _frames = LoadTextures(content, "Characters/Pistol", 20);
            }
        }

        public class PistolAttack
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                _frames = LoadTextures(content, "Characters/Pistol Attack", 3);
            }
        }

        public class PistolReload
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                _frames = LoadTextures(content, "Characters/Pistol Reload", 15);
            }
        }

        public class Rifle
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                _frames = LoadTextures(content, "Characters/Rifle", 20);
            }
        }

        public class RifleAttack
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                _frames = LoadTextures(content, "Characters/Rifle Attack", 3);
            }
        }

        public class RifleReload
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                _frames = LoadTextures(content, "Characters/Rifle Reload", 20);
            }
        }

        public class Knife
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                _frames = LoadTextures(content, "Characters/Knife", 20);
            }
        }

        public class KnifeAttack
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                _frames = LoadTextures(content, "Characters/Knife Attack", 15);
            }
        }

        public class Shotgun
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                _frames = LoadTextures(content, "Characters/Shotgun", 20);
            }
        }

        public class ShotgunAttack
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                _frames = LoadTextures(content, "Characters/Shotgun Attack", 3);
            }
        }

        public class ShotgunReload
        {
            public Texture2D[] _frames;
            public void LoadContent(ContentManager content)
            {
                _frames = LoadTextures(content, "Characters/Shotgun Reload", 20);
            }
        }
    }
}