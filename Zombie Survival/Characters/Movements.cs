using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;

namespace Zombie_Survival.Characters
{
    public class Movements
    {
        private static float _movementSpeed = 200f;
        public static float Rotation = 0f;
        public static Vector2 Position;

        public static void Update(GameTime gameTime, Texture2D texture, Matrix cameraTransform)
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

            /////// Rotate Base on the Movement 
            //if (movement != Vector2.Zero)
            //{
            //    Rotation = (float)Math.Atan2(movement.Y, movement.X);
            //}



            // Update the position
            Position += movement;

            // Ensure the position is clamped within the move area
            Rectangle moveArea = new Rectangle(150, 150, Maps.Textures.Covid19.frames[0].Width, Maps.Textures.Covid19.frames[0].Height);
            Position.X = MathHelper.Clamp(Position.X, moveArea.Left, moveArea.Right - (texture.Width + 50));
            Position.Y = MathHelper.Clamp(Position.Y, moveArea.Top, moveArea.Bottom - texture.Height - 100);

            // Get the mouse position in screen coordinates
            Vector2 MousePosition = Mouse.GetState().Position.ToVector2();

            // Transform mouse position to world coordinates
            Vector2 transformedMousePosition = Vector2.Transform(MousePosition, Matrix.Invert(cameraTransform));

            // Calculate the direction from the character to the mouse
            var direction = transformedMousePosition - Position;
            direction.Normalize();
            Rotation = (float)Math.Atan2(direction.Y, direction.X);

            // Debug output to verify calculations
            System.Diagnostics.Debug.WriteLine($"Rotation: {Rotation}");
            System.Diagnostics.Debug.WriteLine($"Character Position: {Position}");
        }
    }
}
