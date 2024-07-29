


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zombie_Survival.Globals
{
    public class Camera
    {

        public static Vector2 cameraPosition;
        public static Matrix Transform { get;  set; }
        public static void Update(Rectangle gameArea, Vector2 targetPosition, Viewport viewport)
        {
            // Calculate the camera's center position
            Vector2 halfViewport = new Vector2(viewport.Width / 2, viewport.Height / 2);
            cameraPosition = targetPosition - halfViewport;

            // Clamp the camera position to the game area
            cameraPosition.X = MathHelper.Clamp(cameraPosition.X, gameArea.Left, gameArea.Right - viewport.Width);
            cameraPosition.Y = MathHelper.Clamp(cameraPosition.Y, gameArea.Top, gameArea.Bottom - viewport.Height);

            // Create the transform matrix
            Transform = Matrix.CreateTranslation(-cameraPosition.X, -cameraPosition.Y, 0);

        }
    }
}
