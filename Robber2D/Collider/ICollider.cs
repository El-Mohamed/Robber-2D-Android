using Microsoft.Xna.Framework;

namespace Robber2D
{
    interface ICollider
    {
        Rectangle CollisionRectangle { get; set; }
    }
}
