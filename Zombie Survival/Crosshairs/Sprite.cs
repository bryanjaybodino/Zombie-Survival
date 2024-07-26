using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Zombie_Survival.Crosshairs
{
    public class Sprite
    {
        private Texture2D[] _frames;
        private int _currentFrame;
        private double _frameTime;
        private double _elapsedTime;
        private float _rotation;
        private float _scale;
        private Vector2 _imagePosition;

        public Sprite(Viewport viewport)
        {
            _imagePosition = new Vector2(0, 0); // Set initial position of the image
            _currentFrame = 0;
            _frameTime = 100; // Time per frame in milliseconds
            _frames = Textures.Green.frames;
            _rotation = 0f;
            _scale = .1f;
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
              _imagePosition = new Vector2(Globals.MouseInput.transformedMousePosition.X, Globals.MouseInput.transformedMousePosition.Y);
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
