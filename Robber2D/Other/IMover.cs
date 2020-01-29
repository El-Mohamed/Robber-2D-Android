using Microsoft.Xna.Framework;

namespace Robber_2D
{
    interface IMover
    {
        Vector2 Speed { get; set; }
        void MoveRight();
        void MoveLeft();
        void Update(GameTime gameTime);
    }
}
