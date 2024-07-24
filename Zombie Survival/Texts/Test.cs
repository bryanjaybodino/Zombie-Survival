using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Texts
{
    internal class Test
    {
        private SpriteFont messageFont;
        private SpriteBatch _spriteBatch;
        public Test(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }


        public void LoadContent(ContentManager content)
        {
            messageFont = content.Load<SpriteFont>("Maps/File");
        }

        public void Draw(GameTime gameTime)
        {

            _spriteBatch.DrawString(messageFont,"", new Microsoft.Xna.Framework.Vector2(0, 0), Color.White);



        }
    }
}
