using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zombie.Survival.Windows.Objects
{
    public class Camera
    {
        public Matrix transform;

        public void Update(Vector2 targetPosition, float viewportWidth, float viewportHeight)
        {
            Vector2 center = new Vector2(targetPosition.X + (viewportWidth / 2) - 440, targetPosition.Y + (viewportHeight / 2) - 280);
            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));
        }
    }
}
