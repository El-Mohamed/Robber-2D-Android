using Microsoft.Xna.Framework.Input.Touch;

namespace Robber2D
{
    internal class Controller
    {
        public bool Up, Down, Left, Right, Space, D;

        static public bool isPressed()
        {
            TouchCollection touchCollection = TouchPanel.GetState();
            if (touchCollection.Count > 0)
            {
                return true;
            }
            return false;
        }

        public void Update()
        {

            TouchCollection touchCollection = TouchPanel.GetState();

            if (touchCollection.Count > 0)
            {
                Up = false;
                Down = false;
                Left = false;
                Right = false;
                D = false;
                Space = false;

                foreach (TouchLocation touch in touchCollection)
                {

                    if (touch.State == TouchLocationState.Moved )
                    {
                        if (touch.Position.X < 250)
                        {
                            Left = true;
                        }

                        if (touch.Position.X >= 250 && touch.Position.X < 500)
                        {
                            Right = true;
                        }


                        if (touch.Position.X > 900)
                        {
                            Space = true;
                        }
                    }
                }   
            }
        }
    }
}
