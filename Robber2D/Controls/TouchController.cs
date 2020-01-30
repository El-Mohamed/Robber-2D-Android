using Microsoft.Xna.Framework.Input.Touch;

namespace Robber_2D
{
    class TouchController : IController
    {
        public Output Output { get ; set ; }

        public TouchController(Output output)
        {
            Output = output;
        }

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
                Output.Up = false;
                Output.Down = false;
                Output.Left = false;
                Output.Right = false;
                Output.Drink = false;
                Output.Jump = false;
                Output.Shoot = false;

                foreach (TouchLocation touch in touchCollection)
                {

                    if (touch.State == TouchLocationState.Moved)
                    {
                        if (touch.Position.X < 300)
                        {
                            Output.Left = true;
                        }

                        if (touch.Position.X >= 300 && touch.Position.X < 600)
                        {
                            Output.Right = true;
                        }

                        if (touch.Position.X > 900 && touch.Position.X < 1100)
                        {
                            Output.Drink = true;
                        }

                        if (touch.Position.X > 1300 && touch.Position.X < 1650)
                        {
                            Output.Shoot = true;
                        }

                        if (touch.Position.X >= 1650)
                        {
                            Output.Jump = true;
                        }
                    }
                }
            }
        }
    }
}
