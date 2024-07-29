using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Survival.Globals
{
    public class MouseInput
    {

        public static Vector2 transformedMousePosition;
        public static Vector2 actualMousePosition;
        public static void Update(Matrix cameraTransform)
        {
            // Get the mouse position in screen coordinates
            Vector2 MousePosition = Mouse.GetState().Position.ToVector2();
            actualMousePosition = MousePosition;

            // Transform mouse position to world coordinates
            transformedMousePosition = Vector2.Transform(MousePosition, Matrix.Invert(cameraTransform));

        }
    }
}
