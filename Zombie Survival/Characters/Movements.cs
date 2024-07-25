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

        public static void Update(GameTime gameTime, Texture2D texture)
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
            Position += movement;

            // Ensure the position is clamped within the move area
            Rectangle moveArea = new Rectangle(150, 150, Maps.Textures.Covid19.frames[0].Width, Maps.Textures.Covid19.frames[0].Height);
            Position.X = MathHelper.Clamp(Position.X, moveArea.Left, moveArea.Right - (texture.Width + 50));
            Position.Y = MathHelper.Clamp(Position.Y, moveArea.Top, moveArea.Bottom - texture.Height - 100);


            // Rotate Base on the Movement
            if (movement != Vector2.Zero)
            {
                Rotation = (float)Math.Atan2(movement.Y, movement.X);
            }



            ////// Get mouse state
            ////MouseState mouseState = Mouse.GetState();
            ////Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);

            ////// Adjust mouse position to be relative to character
            ////Vector2 characterCenter = Position + new Vector2(texture.Width / 2, texture.Height / 2);
            ////Vector2 direction = mousePosition - characterCenter;

            ////// Calculate rotation angle
            ////if (direction != Vector2.Zero)
            ////{
            ////    direction.Normalize(); // Ensure direction is a unit vector
            ////    Rotation = (float)Math.Atan2(direction.Y, direction.X);
            ////}
            ///



            // Debug output to verify calculations
            System.Diagnostics.Debug.WriteLine($"Rotation: {Rotation}");
            System.Diagnostics.Debug.WriteLine($"Character Position: {Position}");
        }
    }
}
