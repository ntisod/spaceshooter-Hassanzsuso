using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SpaceShooter
{
    class Mine : Enemies
    {
        public Mine(Texture2D texture, float X, float Y) : base(texture, X, Y, 4f, 0.3f)
        {

        }

        public override void Update(GameWindow window)
        {
            position.X += speed.X;

            if(position.X > window.ClientBounds.Width - texture.Width || position.X < 0)
            {
                speed.X *= -1;
            }

           
            if (position.Y > window.ClientBounds.Height)
            {
                isAlive = false;
            }
        }
    }
}
