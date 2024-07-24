using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Zombie.Survival.Windows.Objects.YourCharcter
{
    internal class Player
    {
        private Texture2D[] _frames;
        private int _currentFrame;
        private double _frameTime;
        private double _elapsedTime;
        private Vector2 _imageScale;
        private SpriteBatch _spriteBatch;
        private Viewport _viewport;
        public Movements _movements;


        float movementSpeed = 200f; // Speed in pixels per second

        public Player(SpriteBatch spriteBatch, Viewport viewport)
        {
            _spriteBatch = spriteBatch;
            _viewport = viewport;
            _currentFrame = 0;
            _frameTime = 100; // Time per frame in milliseconds

        }

        public void LoadContent(ContentManager content)
        {
            // Load each frame of the GIF
            _frames = new Texture2D[]
            {
                content.Load<Texture2D>("YourCharacter/Frame1"),
                content.Load<Texture2D>("YourCharacter/Frame2"),
                content.Load<Texture2D>("YourCharacter/Frame3"),
                // Add more frames as needed
            };

            var frameWidth = _frames[0].Width;
            var frameHeight = _frames[0].Height;

            float width = (_viewport.Width / (2f * frameWidth));
            float height = (_viewport.Height / (2f * frameHeight));
            _imageScale = new Vector2(width / 2f, height / 2f);

            // Initialize Movements with the first frame for size calculations
            _movements = new Movements(
                new Vector2((_viewport.Width - frameWidth * _imageScale.X) / 2,
                            (_viewport.Height - frameHeight * _imageScale.Y) / 2),
                _imageScale,
                movementSpeed,
                _viewport,
                _frames[0] // Pass the texture frame for bounds checking
            );
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

            _movements.Update(gameTime);
            GameStartup._camera.Update(_movements.Position, _viewport.Width, _viewport.Height);
        }

        public void Draw(GameTime gameTime)
        {
            // Draw the current //frame 
            _spriteBatch.Draw(
                _frames[_currentFrame],
                _movements.Position,
                null,
                Color.White,
                0f,
                Vector2.Zero,
                _imageScale,
                SpriteEffects.None,
                0f
            );
  
        }
    }
}
