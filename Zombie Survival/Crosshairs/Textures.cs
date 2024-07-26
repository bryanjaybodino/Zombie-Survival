using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Crosshairs
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

        public static class Green
        {
            public static Texture2D[] frames;
            public static void LoadContent(ContentManager content)
            {
                frames = LoadTextures(content, "Crosshairs/Green", 1);
            }
        }
    }
}
