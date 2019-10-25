using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace SpaceShooter
{
    class GameObject
    {
        protected Texture2D texture;
        protected Vector2 position;

        public GameObject(Texture2D texture, float X, float Y)
        {
            this.texture = texture;
            this.position.X = X;
            this.position.Y = Y;


        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(texture, position, Color.White);
           
        }


        public float X { get { return position.X; } }
        public float Y { get { return position.Y; } }
        public float Width { get { return texture.Width; } }
        public float Height { get { return texture.Height; } }
    }
}

