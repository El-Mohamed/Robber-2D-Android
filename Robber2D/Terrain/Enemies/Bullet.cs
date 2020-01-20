﻿using Microsoft.Xna.Framework;

namespace Robber2D
{
    class Bullet : Block, IMover
    {
        public Vector2 Speed { get; set; }
        public int Damage;

        public Bullet(Sprite sprite, Rectangle collisionRectangle) : base(sprite, collisionRectangle)
        {
            Speed = new Vector2(15, 0);
            Damage = 10;
        }

        public void MoveRight()
        {
            SpriteImage.Position = new Vector2(SpriteImage.Position.X + Speed.X, SpriteImage.Position.Y);
        }

        public void MoveLeft()
        {
            SpriteImage.Position = new Vector2(SpriteImage.Position.X - Speed.X, SpriteImage.Position.Y);
        }

        public void Update(GameTime gameTime)
        {
            MoveLeft();
            CollisionRectangle = new Rectangle((int)SpriteImage.Position.X, (int)SpriteImage.Position.Y, SpriteImage.Texture1.Width, SpriteImage.Texture1.Height);
        }
    }
}
