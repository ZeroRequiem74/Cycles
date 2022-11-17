using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the snake.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService keyboardService;
        private Point oneDirection = new Point(Constants.CELL_SIZE, 0);

        private Point twoDirection = new Point(Constants.CELL_SIZE, 0);


        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // left
            if (keyboardService.IsKeyDown("a"))
            {
                oneDirection = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (keyboardService.IsKeyDown("d"))
            {
                oneDirection = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("w"))
            {
                oneDirection = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("s"))
            {
                oneDirection = new Point(0, Constants.CELL_SIZE);
            }

            // left
            if (keyboardService.IsKeyDown("l"))
            {
                twoDirection = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (keyboardService.IsKeyDown("j"))
            {
                twoDirection = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("i"))
            {
                twoDirection = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("k"))
            {
                twoDirection = new Point(0, Constants.CELL_SIZE);
            }



            Snake snake = (Snake)cast.GetFirstActor("PlayerOne");
            Snake secondSnake = (Snake)cast.GetFirstActor("PlayerTwo");
            snake.TurnHead(oneDirection);
            secondSnake.TurnHead(twoDirection);

        }
    }
}