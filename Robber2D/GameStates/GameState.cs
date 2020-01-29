using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Robber_2D;

namespace Robber_2D
{
    public abstract class GameState : IGameState
    {
        public ContentManager contentManager;
        public GraphicsDevice graphicsDevice;
        public Game1 game;

        public GameState(ContentManager contentManager, GraphicsDevice graphicsDevice, Game1 game)
        {
            this.graphicsDevice = graphicsDevice;
            this.contentManager = contentManager;
            this.game = game;
        }

        public abstract void Initialize();
        public abstract void LoadContent();
        public abstract void UnloadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
