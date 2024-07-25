using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Characters
{
    public class Movements
    {

        private static float _movementSpeed = 200f;
        public static float Rotation = 0f;
        public static Vector2 Position;
        public static void Update(GameTime gameTime, Texture2D texture)
        {
            //Get mouse state
            ////MouseState mouseState = Mouse.GetState();

            ////// Calculate direction to the mouse
            ////Vector2 direction = new Vector2(mouseState.X, mouseState.Y) - Movements.Position;
            ////float angle = (float)Math.Atan2(direction.Y, direction.X);

            ////// Update the angle if needed (e.g., for a rotating sprite)
            ////Movements.Rotation = angle;

            // Update camera and other movements if needed


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

            // Rotate Base on the Movement
            if (movement != Vector2.Zero)
            {
                Rotation = (float)Math.Atan2(movement.Y, movement.X);
            }
            // Update the position
            Position += movement;


            Rectangle moveArea = new Rectangle(150, 150, Maps.Textures.Covid19.frames[0].Width, Maps.Textures.Covid19.frames[0].Height);
            Position.X = MathHelper.Clamp(Position.X, moveArea.Left, moveArea.Right - (texture.Width + 50));
            Position.Y = MathHelper.Clamp(Position.Y, moveArea.Top, moveArea.Bottom - texture.Height - 100);


            System.Diagnostics.Debug.WriteLine($"Movement x: " + Position.X);
            System.Diagnostics.Debug.WriteLine($"Movement y: " + Position.Y);
        }
    }
}
