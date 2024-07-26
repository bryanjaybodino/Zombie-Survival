using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace Zombie_Survival.Bullets
{
    public class Sprite
    {
        private Vector2 Position { get; set; }
        private Vector2 Direction { get; set; }
        private float Speed { get; set; }
        private float Rotation { get; set; }
        public bool IsActive { get; set; }
        public Texture2D _frames;
        private float Scale { get; set; }
        private float MaxDistance { get; set; }


        public Rectangle BoundingBox
        {
            get
            {
                float scaleFactor = 0.4f; // Adjust this factor as needed
                int width = (int)(_frames.Width * Scale * scaleFactor);
                int height = (int)(_frames.Height * Scale * scaleFactor);
                int x = (int)(Position.X - (width / 2));
                int y = (int)(Position.Y - (height / 2));
                return new Rectangle(x, y, width, height);
            }
        }



        public Sprite(Texture2D texture, Vector2 position, Vector2 direction, float speed, float rotation, float scale, float maxDistance)
        {
            this._frames = texture;
            Position = position;
            Direction = direction;
            Speed = speed;
            IsActive = true;
            Scale = scale;
            Rotation = rotation;
            MaxDistance = maxDistance;
        }

        public void Update(GameTime gameTime)
        {
            Position += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Check if the bullet goes off-screen (example condition)
            if (Vector2.Distance(Position, Characters.Movements.Position) > MaxDistance)
            {
                IsActive = false;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            if (IsActive)
            {
                _spriteBatch.Draw(_frames, Position, null, Color.White, Rotation, Vector2.Zero, Scale, SpriteEffects.None, 0f);

                // Draw the bounding box for debugging
                //Rectangle boundingBox = BoundingBox;
                //Texture2D whiteTexture = new Texture2D(_spriteBatch.GraphicsDevice, 1, 1);
                //whiteTexture.SetData(new[] { Color.White });
                //_spriteBatch.Draw(whiteTexture, boundingBox, Color.Red * 0.5f);
            }
        }

    }
}
