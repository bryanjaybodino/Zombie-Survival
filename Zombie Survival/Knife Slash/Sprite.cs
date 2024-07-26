using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Zombie_Survival.Knife_Slash
{
    public class Sprite
    {
        private Texture2D[] _frames;
        private int _currentFrame;
        private double _frameTime;
        private double _elapsedTime;
        private Vector2 Position;
        private float Rotation;
        private Vector2 _scale;
        private bool isActive = false;

        public void Attack()
        {
            _currentFrame = 0;
            isActive = true;
        }
        public void Hide()
        {
            isActive = false;
        }

        public Sprite(Viewport viewport)
        {
            isActive = false;
            _scale = new Vector2(0.2f, 0.3f);
            Position = new Vector2(0, 0); // Set initial position of the image
            _currentFrame = 0;
            _frameTime = 100; // Time per frame in milliseconds
            _frames = Textures.Slash.frames;
        }

        public void Update(GameTime gameTime)
        {
            // Update animation frame
            _elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (_elapsedTime >= _frameTime)
            {
                _elapsedTime -= _frameTime;
                _currentFrame++;
                if (_currentFrame >= _frames.Length)
                {
                    _currentFrame = 0; // Loop back to the first frame
                }
            }


            // Set the rotation to the character's rotation
            Rotation = Characters.Movements.Rotation;

            // Calculate the offset based on the character's rotation
            Vector2 Offset = new Vector2(40, 30);
            Vector2 rotatedOffset = Vector2.Transform(Offset, Matrix.CreateRotationZ(Rotation));

            // Calculate the slash's position
            Position = Characters.Movements.Position + rotatedOffset;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            if (isActive)
            {
                Vector2 origin = new Vector2(_frames[_currentFrame].Width / 2, _frames[_currentFrame].Height / 2);
                _spriteBatch.Draw(
                    _frames[_currentFrame],
                    Position,
                    null,
                    Color.White,
                    Rotation,
                    origin, // Use the center of the frame as the origin
                    _scale,
                    SpriteEffects.FlipVertically,
                    0f
                );
            }
        }
    }
}
