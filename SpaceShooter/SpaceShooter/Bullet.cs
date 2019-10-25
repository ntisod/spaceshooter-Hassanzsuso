using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    class Bullet :PhysicalObject
    {
        public Bullet(Texture2D texture, float X, float Y) : base(texture, X, Y, 0f, 10f)
        {
            

        }

        public void Update()
        {
            position.Y -= speed.Y;

            if (position.Y < 0)
            {
                isAlive = false;
            }
        }
    }
}
