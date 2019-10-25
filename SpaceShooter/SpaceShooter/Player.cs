using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceShooter {

    class Player : PhysicalObject
    {
        public List<Bullet> bullets;
        Texture2D bulletTexture;
        double timeSinceLastBullet = 0;

        int points = 0;
        public float angle = 0;

        public int Points { get { return points; } set { points = value; } }
      
        


    public Player(Texture2D texture, float X, float Y, float SpeedX, float SpeedY, Texture2D bulletTexture) : base(texture, X, Y, SpeedX, SpeedY)
    {

            bullets = new List<Bullet>();
            this.bulletTexture = bulletTexture;

        this.position.X = X;
        this.position.Y = Y;
        this.speed.X = SpeedX;
        this.speed.Y = SpeedY;
        this.texture = texture;
    }

        public void Reset(float X, float Y, float SpeedX, float SpeedY)
        {
            position.X = X;
            position.Y = Y;
            speed.X = SpeedX;
            speed.Y = SpeedY;

            bullets.Clear();
            timeSinceLastBullet = 0;
            points = 0;
            isAlive = true;


        }

        public void Update(GameWindow window, GameTime gameTime) //byt till litet w
    {
            KeyboardState KeyboardState = Keyboard.GetState();

            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                IsAlive = false;
            }

            if (KeyboardState.IsKeyDown(Keys.Right) || KeyboardState.IsKeyDown(Keys.D))
            {


                position.X += speed.X;

            }
            if (KeyboardState.IsKeyDown(Keys.Up) || KeyboardState.IsKeyDown(Keys.W))
            {


                position.Y -= speed.Y;

            }
            if (KeyboardState.IsKeyDown(Keys.Left) || KeyboardState.IsKeyDown(Keys.A))
            {

                position.X -= speed.X;

            }
            if (KeyboardState.IsKeyDown(Keys.Down) || KeyboardState.IsKeyDown(Keys.S))
            {

                position.Y += speed.Y;

            }
            /* Får objektet att studsa tillbaka
            if (position.X > window.ClientBounds.Width - gfx.Width || position.X < 0)
            {
                speed.X *= -1;
            }
            if (position.Y > window.ClientBounds.Height - gfx.Height || position.Y < 0)
            {
                speed.Y *= -1;
            }
            */
            if (position.X <= window.ClientBounds.Width - texture.Width && position.X >= 0)
            {
                if (KeyboardState.IsKeyDown(Keys.Right) || KeyboardState.IsKeyDown(Keys.D))
                {
                    position.X += speed.X;
                }
                if (KeyboardState.IsKeyDown(Keys.Left) || KeyboardState.IsKeyDown(Keys.A))
                {
                    position.X -= speed.X;
                }

            }
        if (position.Y <= window.ClientBounds.Height - texture.Height && position.Y >= 0)
        {
            if (KeyboardState.IsKeyDown(Keys.Up) || KeyboardState.IsKeyDown(Keys.W))
            {
                position.Y -= speed.Y;
            }
            if (KeyboardState.IsKeyDown(Keys.Down) || KeyboardState.IsKeyDown(Keys.S))
            {
                position.Y += speed.Y;
            }



        }
        if (position.X < 0)
            position.X = 0;

        if (position.X > window.ClientBounds.Width - texture.Width)
            position.X = window.ClientBounds.Width - texture.Width;

        if (position.Y < 0)
            position.Y = 0;

        if (position.Y > window.ClientBounds.Height - texture.Height)
        {
            position.Y = window.ClientBounds.Height - texture.Height;
        }

        if(KeyboardState.IsKeyDown(Keys.Space))
            {
                if(gameTime.TotalGameTime.TotalMilliseconds > timeSinceLastBullet + 200)
                {
                    Bullet temp = new Bullet(bulletTexture, position.X + texture.Width / 2, position.Y);
                    bullets.Add(temp);
                    timeSinceLastBullet = gameTime.TotalGameTime.TotalMilliseconds;

                    
                }
            }
            foreach (Bullet b in bullets.ToList())
            {
                b.Update();
                if (!b.IsAlive)
                    bullets.Remove(b);
            }
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.Draw(texture, position, Color.White);
            foreach (Bullet b in bullets)
            {
                b.Draw(spriteBatch);
            }
        }
       
}

}

