using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyFirstGame
{
    public class AlienScout : Enemy
    {
        /// Constructor for the Alien Scout.
        public AlienScout(Texture2D texture, Vector2 startPosition): base("Alien Scout", 50, 2.0f, texture, startPosition)
        {
            // "Alien Scout", 50 HP, 2.0f speed
            // HP value from level description [cite: 109, 41]
        }

        /// <summary>
        /// Defines the AI and movement for the Alien Scout.
        /// This implementation makes it move straight down.
        /// </summary>
        public override void Update(GameTime gameTime, Player player)
        {
            // Move straight down the screen
            Vector2 newPosition = new Vector2(Position.X, Position.Y + speed);
            Position = newPosition;

            // Deactivate if it goes off the bottom of the screen
            // (Assumes Update is called from GameManager which has GraphicsDevice)
            // A better way is to pass GraphicsDevice viewport height in.
            // For now, we'll just move.
        }
    }
}