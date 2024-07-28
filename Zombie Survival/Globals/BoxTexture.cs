using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Globals
{
    public class BoxTexture
    {
        public static void Draw(SpriteBatch spriteBatch, int width, int height, Color color, Vector2 position)
        {
            var sizePosition = new Rectangle((int)position.X, (int)position.Y, width, height);
            Texture2D whiteTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            whiteTexture.SetData(new[] { Color.White });
            spriteBatch.Draw(whiteTexture, sizePosition, color * 1f);
        }
    }
}
