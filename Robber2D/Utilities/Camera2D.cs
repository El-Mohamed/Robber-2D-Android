using Microsoft.Xna.Framework;

namespace Robber2D
{
    class Camera2D
    {
        static public Matrix Transform;

        static public void Follow(Player player)
        {
            var position = Matrix.CreateTranslation(
               -player.SpriteSheet.Position.X - (player.CollisionRectangle.Height / 2),
               -player.SpriteSheet.Position.Y - (player.CollisionRectangle.Height / 2),
               0);

            var offset = Matrix.CreateTranslation(
                Game1.ScreenWidth / 2,
                Game1.ScreenHeight / 2,
                0);

            Transform = position * offset;
        }
    }
}

