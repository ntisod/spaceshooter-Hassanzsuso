using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace SpaceShooter
{
    class Tripod : Enemies
    {
        public Tripod(Texture2D texture, float X, float Y) : base(texture, X, Y, 0f, 2f)
        {

        }

        public override void Update(GameWindow window)
        {
            position.Y += speed.Y;

            if (position.Y > window.ClientBounds.Height)
            {
                isAlive = false;

            }
        }
    }
}
