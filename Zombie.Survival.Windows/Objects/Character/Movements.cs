using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Zombie.Survival.Windows.Objects.YourCharcter
{
    internal class Movements
    {
        private Vector2 _position;
        private Vector2 _scale;
        private float _movementSpeed; // Speed of movement
        private Viewport _viewport;
        private Texture2D _frame;

        public Movements(Vector2 initialPosition, Vector2 scale, float movementSpeed, Viewport viewport, Texture2D frame)
        {
            _position = initialPosition;
            _scale = scale;
            _movementSpeed = movementSpeed;
            _viewport = viewport;
            _frame = frame;
        }

        public Vector2 Position => _position;

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 movement = Vector2.Zero;

            if (keyboardState.IsKeyDown(Keys.A))
            {
                movement.X -= _movementSpeed * deltaTime;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                movement.X += _movementSpeed * deltaTime;
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                movement.Y -= _movementSpeed * deltaTime;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                movement.Y += _movementSpeed * deltaTime;
            }

            // Update the position
            _position += movement;

            // Ensure the character stays within viewport bounds
            var frameWidth = _frame.Width * _scale.X;
            var frameHeight = _frame.Height * _scale.Y;

            _position.X = MathHelper.Clamp(_position.X, 0, _viewport.Width - frameWidth);
            _position.Y = MathHelper.Clamp(_position.Y, 0, _viewport.Height - frameHeight);

            System.Diagnostics.Debug.WriteLine($"Movement x: " + _position.X);
            System.Diagnostics.Debug.WriteLine($"Movement y: " + _position.Y);
        }
    }
}
