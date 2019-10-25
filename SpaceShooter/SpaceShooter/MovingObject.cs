    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

namespace SpaceShooter

{
   abstract class MovingObject : GameObject
    {
        protected Vector2 speed;

        public MovingObject(Texture2D texture, float X, float Y, float SpeedX, float SpeedY) : base(texture,X,Y)
        {
            this.speed.X = SpeedX;
               this.speed.Y = SpeedY;

        }

    }
}

