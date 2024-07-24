//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Zombie_Survival.Globals
//{
//    public class Camera
//    {
//        public static Matrix transform;
//        public static void Update(Vector2 targetPosition, Texture2D targetSize, Viewport viewport)
//        {
//            var screenWidth = (viewport.Width / 2) + 100;
//            var screenHeight = (viewport.Height / 2) + 50;
//            Vector2 center = new Vector2(targetPosition.X + (targetSize.Width / 2) - screenWidth, targetPosition.Y + (targetSize.Height / 2) - screenHeight);
//            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));
//        }
//    }
//}



using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zombie_Survival.Globals
{
    public class Camera
    {
      
        public static Matrix Transform { get; private set; }
        public static void Update(Rectangle gameArea, Vector2 targetPosition, Viewport viewport)
        {
            // Calculate the camera's center position
            Vector2 halfViewport = new Vector2(viewport.Width / 2, viewport.Height / 2);
            Vector2 cameraPosition = targetPosition - halfViewport;

            // Clamp the camera position to the game area
            cameraPosition.X = MathHelper.Clamp(cameraPosition.X, gameArea.Left, gameArea.Right - viewport.Width);
            cameraPosition.Y = MathHelper.Clamp(cameraPosition.Y, gameArea.Top, gameArea.Bottom - viewport.Height);

            // Create the transform matrix
            Transform = Matrix.CreateTranslation(-cameraPosition.X, -cameraPosition.Y, 0);
        }
    }
}
