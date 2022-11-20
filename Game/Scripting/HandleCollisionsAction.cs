using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;
        private string loser = "";

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandlePlayerCollisions(cast);
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("Player One");
            Actor head = snake.GetHead();
            List<Actor> body = snake.GetBody();

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                    loser = "Player One";
                }
            }

            Snake secondSnake = (Snake)cast.GetFirstActor("Player Two");
            Actor headTwo = secondSnake.GetHead();
            List<Actor> bodyTwo = secondSnake.GetBody();

            foreach (Actor segment in bodyTwo)
            {
                if (segment.GetPosition().Equals(headTwo.GetPosition()))
                {
                    isGameOver = true;
                    loser = "Player Two";
                }
            }
        }

        private void HandlePlayerCollisions(Cast cast){
            Snake snake = (Snake)cast.GetFirstActor("Player One");
            Snake secondSnake = (Snake)cast.GetFirstActor("Player Two");
            Actor head = snake.GetHead();
            Actor headTwo = secondSnake.GetHead();
            List<Actor> body = snake.GetBody();
            List<Actor> bodyTwo = secondSnake.GetBody();

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(headTwo.GetPosition()))
                {
                    isGameOver = true;
                    loser = "Player Two";
                }
            }
            
            foreach (Actor segment in bodyTwo)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                    loser = "Player One";
                }
            }
        }

       
        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Snake snake = (Snake)cast.GetFirstActor(loser);
                List<Actor> segments = snake.GetSegments();
                

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText($"{loser} Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
                }
                
            }
        }

        public bool Stop(){
            bool stop = false;

            if (isGameOver == true){
                stop = true;
            }
            return stop;
        }

    }
}