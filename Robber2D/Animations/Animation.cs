using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Robber2D
{
    class Animation
    {
        public List<AnimationFrame> allFrames;
        public AnimationFrame currentFrame;
        private double xOffset;
        int counter = 0;

        public Animation()
        {
            allFrames = new List<AnimationFrame>();
            xOffset = 0;
        }

        public void AddFrame(Rectangle rectangle)
        {
            AnimationFrame frame = new AnimationFrame()
            {
                SourceRectangle = rectangle
            };

            allFrames.Add(frame);
            currentFrame = allFrames[0];
        }

        public void Update(GameTime gameTime)
        {
            xOffset += currentFrame.SourceRectangle.Width * gameTime.ElapsedGameTime.Milliseconds / 50;
            if (xOffset >= currentFrame.SourceRectangle.Width)
            {
                counter++;
                if (counter >= allFrames.Count)
                {
                    counter = 0;
                }

                currentFrame = allFrames[counter];
                xOffset = 0;
            }
        }
    }
}