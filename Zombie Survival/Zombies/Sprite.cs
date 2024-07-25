using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace Zombie_Survival.Zombies
{
    public class Sprite
    {
        private Texture2D[] _frames;
        private int _currentFrame;
        private double _frameTime;
        private double _elapsedTime;
        private Vector2 _imagePosition;
        private Vector2 _scale;
        private float _rotation;
        private float _movementSpeed;
        private float _minDistance; // Minimum distance to maintain from the character

        public Sprite(Viewport viewport)
        {
            _imagePosition = new Vector2(0, 0); // Set initial position of the image
            _currentFrame = 0;
            _frameTime = 50; // Time per frame in milliseconds
            _frames = Textures.Macho.frames;
            _scale = new Vector2(.5f, .5f); // Initialize scale to 0.5
            _rotation = 0f; // Initialize rotation to 0
            _movementSpeed = 100f; // Initialize movement speed (pixels per second)
            _minDistance = 80f; // Minimum distance to maintain from the character (adjust as needed)
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
            FollowCharacter(gameTime);
        }

        private void FollowCharacter(GameTime gameTime)
        {
            Vector2 characterPosition = Characters.Movements.Position;
            Vector2 direction = characterPosition - _imagePosition;
            float distance = direction.Length();

            if (distance > _minDistance)
            {
                direction.Normalize(); // Get the direction as a unit vector
                _imagePosition += direction * _movementSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                // Calculate rotation angle
                _rotation = (float)Math.Atan2(direction.Y, direction.X);
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                _frames[_currentFrame],
                _imagePosition,
                null,
                Color.White,
                _rotation,
                new Vector2(_frames[_currentFrame].Width / 2, _frames[_currentFrame].Height / 2),
                _scale,
                SpriteEffects.None,
                0f
            );
        }
    }
}
