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

        public static class Pistol
        {
            public static Texture2D[] frames;
            public static void LoadContent(ContentManager content)
            {
                frames = LoadTextures(content, "Characters/Pistol", 20);
            }
        }

        public static class PistolAttack
        {
            public static Texture2D[] frames;
            public static void LoadContent(ContentManager content)
            {
                frames = LoadTextures(content, "Characters/Pistol Attack", 3);
            }
        }

        public static class PistolReload
        {
            public static Texture2D[] frames;
            public static void LoadContent(ContentManager content)
            {
                frames = LoadTextures(content, "Characters/Pistol Reload", 15);
            }
        }

        public static class Rifle
        {
            public static Texture2D[] frames;
            public static void LoadContent(ContentManager content)
            {
                frames = LoadTextures(content, "Characters/Rifle", 20);
            }
        }

        public static class RifleAttack
        {
            public static Texture2D[] frames;
            public static void LoadContent(ContentManager content)
            {
                frames = LoadTextures(content, "Characters/Rifle Attack", 3);
            }
        }

        public static class RifleReload
        {
            public static Texture2D[] frames;
            public static void LoadContent(ContentManager content)
            {
                frames = LoadTextures(content, "Characters/Rifle Reload", 20);
            }
        }

        public static class Knife
        {
            public static Texture2D[] frames;
            public static void LoadContent(ContentManager content)
            {
                frames = LoadTextures(content, "Characters/Knife", 20);
            }
        }

        public static class KnifeAttack
        {
            public static Texture2D[] frames;
            public static void LoadContent(ContentManager content)
            {
                frames = LoadTextures(content, "Characters/Knife Attack", 15);
            }
        }

        public static class Shotgun
        {
            public static Texture2D[] frames;
            public static void LoadContent(ContentManager content)
            {
                frames = LoadTextures(content, "Characters/Shotgun", 20);
            }
        }

        public static class ShotgunAttack
        {
            public static Texture2D[] frames;
            public static void LoadContent(ContentManager content)
            {
                frames = LoadTextures(content, "Characters/Shotgun Attack", 3);
            }
        }

        public static class ShotgunReload
        {
            public static Texture2D[] frames;
            public static void LoadContent(ContentManager content)
            {
                frames = LoadTextures(content, "Characters/Shotgun Reload", 20);
            }
        }
    }
}