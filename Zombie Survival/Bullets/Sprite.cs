using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Bullets
{
    public class Sprite
    {

        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }
        public float Speed { get; set; }
        public float Rotation { get; set; }
        public bool IsActive { get; set; }
        private Texture2D _frames;
        public float Scale { get; set; } // Add a Scale property

       
        public Sprite(Texture2D texture, Vector2 position, Vector2 direction, float speed,float rotation)
        {
            this._frames = texture;
            Position = position;
            Direction = direction;
            Speed = speed;
            IsActive = true;
            Scale = .05f;
            Rotation = rotation;
        }

        public void Update(GameTime gameTime)
        {
            Position += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Check if bullet goes off-screen (example condition)
            //if (Position.X < 0 || Position.X > 800 || Position.Y < 0 || Position.Y > 600) // Adjust screen bounds as needed
            //{
            //    IsActive = false;
            //}
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_frames, Position, null, Color.White, Rotation, Vector2.Zero, Scale, SpriteEffects.None, 0f);
        }
    }

}
