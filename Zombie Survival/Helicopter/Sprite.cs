using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Helicopter
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
            _frames = Textures.HealthKit.frames;
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

            Random random = new Random();
            int supX = random.Next(250, Maps.Textures.Covid19.frames[0].Width - 250);
            int supY = random.Next(250, Maps.Textures.Covid19.frames[0].Height - 250);


            Globals.RectangleImage.Draw(_spriteBatch, Helicopter.Textures.HealthKit.frames, 50f, 50f, supX, supY, false);
        }
    }
}
