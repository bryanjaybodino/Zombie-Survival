using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Globals
{
    public class CircleTexture
    {
        public static void Draw(SpriteBatch spriteBatch, int radius, Color color, Vector2 position)
        {
            int diameter = radius * 2;
            Texture2D texture = new Texture2D(spriteBatch.GraphicsDevice, diameter, diameter);

            Color[] colorData = new Color[diameter * diameter];
            float radiiSquared = radius * radius;

            for (int y = 0; y < diameter; y++)
            {
                for (int x = 0; x < diameter; x++)
                {
                    int index = y * diameter + x;
                    Vector2 Position = new Vector2(x - radius, y - radius);
                    if (Position.LengthSquared() <= radiiSquared)
                    {
                        colorData[index] = color;
                    }
                    else
                    {
                        colorData[index] = Color.Transparent;
                    }
                }
            }

            texture.SetData(colorData);

            spriteBatch.Draw(texture, position, color);

        }
    }
}
