using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Blood_Effects
{
    public class Sprite
    {
        private Texture2D[] _frames;
        private int _currentFrame;
        private double _frameTime;
        private double _elapsedTime;
        private Vector2 _imagePosition;
        private float _Rotation;
        public Sprite(float X, float Y, float Rotation)
        {
            _Rotation = Rotation;
            _imagePosition = new Vector2(X + 40, Y); // Set initial position of the image
            _currentFrame = 0;
            _frameTime = 20; // Time per frame in milliseconds
            _frames = Textures.KillZombie.frames;
        }

        public void Update(GameTime gameTime, List<Sprite> bloods)
        {
            // Update animation frame
            _elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (_elapsedTime >= _frameTime)
            {
                _elapsedTime -= _frameTime;
                _currentFrame++;
                if (_currentFrame >= _frames.Length)
                {
                    // _currentFrame = 0; // Loop back to the first frame
                    bloods.Remove(this);
                }
            }
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            Vector2 origin = new Vector2(_frames[_currentFrame].Width / 2, _frames[_currentFrame].Height / 2);
            _spriteBatch.Draw(
                _frames[_currentFrame],
                _imagePosition,
                null,
                Color.White,
                _Rotation,
                origin, // Use the center of the frame as the origin
                1f,
                SpriteEffects.None,
                0f
            );

        }
    }
}
