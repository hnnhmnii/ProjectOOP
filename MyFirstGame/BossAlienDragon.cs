using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyFirstGame
{
    public class BossAlienDragon : Enemy
    {
        // Boss-specific attributes from your design
        private int phases;   
        private string weakSpots;
        
        // Timer for attacks
        private double attackTimer;

        // Constructor
        public BossAlienDragon(Texture2D texture, Vector2 startPosition)
            : base("Alien Dragon", 5000, 1.0f, texture, startPosition)
        {
            this.phases = 3;
            this.weakSpots = "Glowing Core";
            this.attackTimer = 0;
        }

        /// <summary>
        /// Boss-specific AI, movement, and attack logic.
        /// </summary>
        public override void Update(GameTime gameTime, Player player)
        {
            // Simple movement (e.g., move side-to-side)
            Position = new Vector2(Position.X + (float)System.Math.Sin(gameTime.TotalGameTime.TotalSeconds) * 2, Position.Y);

            // Update attack timer
            attackTimer += gameTime.ElapsedGameTime.TotalSeconds;

            // Attack every 2 seconds
            if (attackTimer > 2.0)
            {
                if (this.hp < 1000) // If low health, use special
                {
                    SpecialAttack(player);
                }
                else
                {
                    // Regular attack (e.g., spawn projectiles)
                    // (Logic to spawn projectiles would go here)
                }
                attackTimer = 0; // Reset timer
            }
        }

        /// <summary>
        /// Boss-specific special attack.
        /// </summary>
        public void SpecialAttack(Player player)
        {
            // Logic for a devastating attack, e.g., a laser beam
            // (Spawns a different type of projectile)
        }

        /// <summary>
        /// Logic to change behavior when HP is low.
        /// </summary>
        public void ChangePhase()
        {
            this.phases--;
            this.speed *= 1.5f; // Example: gets faster

            System.Diagnostics.Debug.WriteLine($"{this.Name} is enraged! Target its {this.weakSpots}!");
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);

            // Check if it's time to change phase
            if (this.phases == 3 && this.hp <= 3000)
            {
                ChangePhase();
            }
            else if (this.phases == 2 && this.hp <= 1000)
            {
                ChangePhase();
            }
        }
    }
}