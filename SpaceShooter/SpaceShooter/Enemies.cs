using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
   abstract class Enemies : PhysicalObject
    {
         
        
        public Enemies(Texture2D texture, float X, float Y, float speedX, float speedY) : base(texture, X, Y, speedX, speedY) 
        {

        }

        public abstract void Update(GameWindow window);
           

       


   
    }


}


