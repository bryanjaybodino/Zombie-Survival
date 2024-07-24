using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Numerics;
using Zombie.Survival.Windows.Objects.YourCharcter;

namespace Zombie.Survival.Windows.Objects.Maps
{
    internal class Message 
    {
        private SpriteFont messageFont;
        private SpriteBatch _spriteBatch;
        private Player _player;

        public Message(SpriteBatch spriteBatch,Player player)
        {
            _spriteBatch = spriteBatch;
            _player = player;
        }


            public void LoadContent(ContentManager content) { 
            messageFont = content.Load<SpriteFont>("Maps/File");
        }

        public void Draw(GameTime gameTime)
        {
         
            _spriteBatch.DrawString(messageFont, _player._movements.Position.X.ToString(), new Microsoft.Xna.Framework.Vector2(0, 0), Color.White);
          

    
        }
    }
}
