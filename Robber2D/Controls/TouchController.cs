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

                foreach (TouchLocation touch in touchCollection)
                {

                    if (touch.State == TouchLocationState.Moved)
                    {
                        if (touch.Position.X < 250)
                        {
                            Output.Left = true;
                        }

                        if (touch.Position.X >= 250 && touch.Position.X < 500)
                        {
                            Output.Right = true;
                        }


                        if (touch.Position.X > 900)
                        {
                            Output.Jump = true;
                        }
                    }
                }
            }
        }
    }
}
