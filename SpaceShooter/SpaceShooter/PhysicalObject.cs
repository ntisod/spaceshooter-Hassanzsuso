using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    abstract class PhysicalObject : MovingObject
    {
        protected bool isAlive = true;

        public PhysicalObject(Texture2D texture, float X, float Y, float SpeedX, float SpeedY) : base(texture, X, Y, SpeedX, SpeedY)
        {    
        }

        public bool CheckCollision(PhysicalObject other)
        {
            Rectangle myRect = new Rectangle(Convert.ToInt32(X), Convert.ToInt32(Y), Convert.ToInt32(Width), Convert.ToInt32(Height));
            Rectangle otherRect = new Rectangle(Convert.ToInt32(other.X), Convert.ToInt32(other.Y), Convert.ToInt32(other.X), Convert.ToInt32(other.Width));
            return myRect.Intersects(otherRect);
        }


        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }


    }
}
