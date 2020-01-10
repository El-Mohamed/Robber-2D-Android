using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Robber2D
{
    class Sprite
    {
        public int NumberOfSprites;
        public Texture2D Texture1;
        public Vector2 Position;

        public Sprite(Texture2D texture, int numberOfSprites, Vector2 position)
        {
            NumberOfSprites = numberOfSprites;
            Texture1 = texture;
            Position = position;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture1, Position, Color.White);
        }
    }
}
