using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.UI_Elements
{
    public static class Textures
    {
        private static Texture2D[] LoadTextures(ContentManager content, string directoryPath, int numFrames)
        {
            Texture2D[] frames = new Texture2D[numFrames];
            for (int i = 0; i < numFrames; i++)
            {
                frames[i] = content.Load<Texture2D>($"{directoryPath}");
            }
            return frames;
        }

        public static class Heart
        {
            public static Texture2D[] frames;
            public static void LoadContent(ContentManager content)
            {
                frames = LoadTextures(content, "UI Elements/Heart", 1);
            }
        }

        public static class Helicopter
        {
            public static Texture2D[] frames;
            public static void LoadContent(ContentManager content)
            {
                frames = LoadTextures(content, "UI Elements/Helicopter", 1);
            }
        }

        public static class Clock
        {
            public static Texture2D[] frames;
            public static void LoadContent(ContentManager content)
            {
                frames = LoadTextures(content, "UI Elements/Clock", 1);
            }
        }
        public static class Bullet
        {
            public static Texture2D[] frames;
            public static void LoadContent(ContentManager content)
            {
                frames = LoadTextures(content, "UI Elements/Bullet", 1);
            }
        }
        public static class Cash
        {
            public static Texture2D[] frames;
            public static void LoadContent(ContentManager content)
            {
                frames = LoadTextures(content, "UI Elements/Cash", 1);
            }
        }
        public static class Skull
        {
            public static Texture2D[] frames;
            public static void LoadContent(ContentManager content)
            {
                frames = LoadTextures(content, "UI Elements/Skull", 1);
            }
        }

        public static class MouseCursor
        {
            public static Texture2D[] frames;
            public static void LoadContent(ContentManager content)
            {
                frames = LoadTextures(content, "UI Elements/Mouse Cursor", 1);
            }
        }



        public class GameOver
        {
            public static class Screen
            {
                public static Texture2D[] frames;
                public static void LoadContent(ContentManager content)
                {
                    frames = LoadTextures(content, "UI Elements/Game Over/Screen", 1);
                }
            }
            public static class Back
            {
                public static Texture2D[] frames;
                public static void LoadContent(ContentManager content)
                {
                    frames = LoadTextures(content, "UI Elements/Game Over/Back", 1);
                }
            }
            public static class PlayAgain
            {
                public static Texture2D[] frames;
                public static void LoadContent(ContentManager content)
                {
                    frames = LoadTextures(content, "UI Elements/Game Over/Play Again", 1);
                }
            }
        }





        public class Menu
        {
            public static class Screen
            {
                public static Texture2D[] frames;
                public static void LoadContent(ContentManager content)
                {
                    frames = LoadTextures(content, "UI Elements/Menu/Screen", 1);
                }
            }
            public static class Play
            {
                public static Texture2D[] frames;
                public static void LoadContent(ContentManager content)
                {
                    frames = LoadTextures(content, "UI Elements/Menu/Play", 1);
                }
            }
            public static class ZombieSurvival
            {
                public static Texture2D[] frames;
                public static void LoadContent(ContentManager content)
                {
                    frames = LoadTextures(content, "UI Elements/Menu/Zombie Survival", 1);
                }
            }
            public static class Exit
            {
                public static Texture2D[] frames;
                public static void LoadContent(ContentManager content)
                {
                    frames = LoadTextures(content, "UI Elements/Menu/Exit", 1);
                }
            }
            public static class Instruction
            {
                public static Texture2D[] frames;
                public static void LoadContent(ContentManager content)
                {
                    frames = LoadTextures(content, "UI Elements/Menu/Instruction", 1);
                }
            }
        }

        public class Instruction
        {
            public static class Screen
            {
                public static Texture2D[] frames;
                public static void LoadContent(ContentManager content)
                {
                    frames = LoadTextures(content, "UI Elements/Instruction/Screen", 1);
                }
            }
            public static class Back
            {
                public static Texture2D[] frames;
                public static void LoadContent(ContentManager content)
                {
                    frames = LoadTextures(content, "UI Elements/Instruction/Back", 1);
                }
            }
        }
    }
}
