using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Zombie.Survival.Windows.Maps
{
    internal class Covid19
    {
        public Texture2D[] _frames;
        private int _currentFrame;
        private double _frameTime;
        private double _elapsedTime;
        private Vector2 _imagePosition;
        private SpriteBatch _spriteBatch;

        public Covid19(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _imagePosition = new Vector2(0, 0); // Set initial position of the image
            _currentFrame = 0;
            _frameTime = 100; // Time per frame in milliseconds
        }

        public void LoadContent(ContentManager content)
        {
            // Load each frame of the GIF
            _frames = new Texture2D[]
            {
                content.Load<Texture2D>("Maps/Covid19"),
                // Add more frames as needed
            };
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
        }

        public void Draw(GameTime gameTime)
        {
            // Draw the current frame
       
            _spriteBatch.Draw(_frames[_currentFrame], _imagePosition, Color.White);
       
        }
    }

}
