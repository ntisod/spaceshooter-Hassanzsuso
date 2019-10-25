using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    class BackgroundSprite : GameObject
    {

        public BackgroundSprite(Texture2D texture, float X, float Y) : base(texture, X, Y)
        { 

        }

        public void Update(GameWindow window)
        {
            position.Y += 2f;

            if(position.Y > window.ClientBounds.Height)
            {
                position.Y = position.Y - nrBackgroundsY * texture.Height;
            }

           }
    }
    
}
