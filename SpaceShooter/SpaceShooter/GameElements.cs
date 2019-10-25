using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter
{
    static class GameElements
    {
        static Texture2D menuSprite;
        static Vector2 menuPos;
        static Player player;
        static Menu menu;
        static List<Enemies> enemies;
        static List<GoldCoin> goldCoins;
        static PrintText printText;
        static Texture2D goldCoinSprite;
        static Background background;
            

        public enum State {Menu, Run, Highscore, Quit };
        public static State currentState;

        public static void Initalize()
        {
            goldCoins = new List<GoldCoin>();
        }

        public static void LoadContent(ContentManager content, GameWindow window)
        {
            background = new Background(content.Load<Texture2D>("sprites/background"), window);
            menu = new Menu((int)State.Menu);
            //menu.AddItem(content.Load<Texture2D>("menu/start"),(int)State.Run);
            //menu.AddItem(content.Load<Texture2D>("menu/highscore"), (int)State.Highscore);
            //menu.AddItem(content.Load<Texture2D>("menu/exit"), (int)State.Quit);
            
            
            menuSprite = content.Load<Texture2D>("zamypic");
            menuPos.X = window.ClientBounds.Width / 2 - menuSprite.Width / 2;
            menuPos.Y = window.ClientBounds.Height / 2 - menuSprite.Height / 2;
            player = new Player(content.Load<Texture2D>("hamburger"), 380, 400, 4.5f, 6.5f, content.Load<Texture2D>("Laxbullet"));

            enemies = new List<Enemies>();
            Random random = new Random();

            //amount of enemies
            for (int i = 0; i < 10; i++)
            {
                Texture2D tmpSprite = content.Load<Texture2D>("LaxMineEnemy");
                int rndX = random.Next(0, window.ClientBounds.Width - tmpSprite.Width);
                int rndY = random.Next(0, window.ClientBounds.Height / 2);
                Mine temp = new Mine(tmpSprite, rndX, rndY);
                enemies.Add(temp);

            }
            for (int i = 0; i < 15; i++)
            {
                Texture2D tmpSprite = content.Load<Texture2D>("Laxtripod");
                int rndX = random.Next(0, window.ClientBounds.Width - tmpSprite.Width);
                int rndY = random.Next(0, window.ClientBounds.Height / 2);
                Tripod temp = new Tripod(tmpSprite, rndX, rndY);
                enemies.Add(temp);


            }

            printText = new PrintText(content.Load<SpriteFont>("Spritefont"));
            goldCoinSprite = content.Load<Texture2D>("coin");
        }

        private static void Reset(GameWindow window, ContentManager content)
        {
            player.Reset(380, 400, 4f, 6f);

            enemies.Clear();
            Random random = new Random();
            Texture2D tmpSprite = content.Load<Texture2D>("LaxMineEnemy");
            for(int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - tmpSprite.Width);
                int rndY = random.Next(0, window.ClientBounds.Height/2);
                Mine temp = new Mine(tmpSprite, rndX, rndY);
                enemies.Add(temp);
            }

            tmpSprite = content.Load<Texture2D>("laxtripod");
            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - tmpSprite.Width);
                int rndY = random.Next(0, window.ClientBounds.Height / 2);
                Tripod temp = new Tripod(tmpSprite, rndX, rndY);
                enemies.Add(temp);
            }


        }

            public static State MenuUpdate()
        {
            

            KeyboardState KeyboardState = Keyboard.GetState();

            if (KeyboardState.IsKeyDown(Keys.S))
            {
                return State.Run;
            }
            if (KeyboardState.IsKeyDown(Keys.H))
            {
                return State.Highscore;
            }
            if (KeyboardState.IsKeyDown(Keys.Q)) 
            {
                return State.Quit;
            }


            return State.Menu;
        }

        public static void MenuDraw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);
            spriteBatch.Draw(menuSprite, menuPos, Color.White);
        }

        public static State RunUpdate(ContentManager content, GameWindow window, GameTime gameTime)
        {

            player.Update(window, gameTime);

            if(!player.IsAlive)
            {
                Reset(window, content);
                return State.Menu;
            }

           

            foreach (Enemies e in enemies)
            {
                e.Update(window);
            }



            foreach (Enemies e in enemies.ToList())
            {
                foreach (Bullet b in player.bullets)
                {
                    if (e.CheckCollision(b))
                    {
                        e.IsAlive = false;
                        b.IsAlive = false;
                        player.Points++;

                    }
                }

                if (e.IsAlive)
                {
                    if (e.CheckCollision(player))


                        e.Update(window);
                }

                else
                    enemies.Remove(e);

            }
            Random random = new Random();
            int newCoin = random.Next(1, 200);
            if (newCoin == 1)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - goldCoinSprite.Width);
                int rndY = random.Next(0, window.ClientBounds.Height - goldCoinSprite.Height);
                goldCoins.Add(new GoldCoin(goldCoinSprite, rndX, rndY, gameTime));

                foreach (GoldCoin gc in goldCoins.ToList())
                {
                    if (gc.IsAlive)
                    {
                        gc.Update(gameTime);

                        if (gc.CheckCollision(player))
                        {
                            goldCoins.Remove(gc);
                            player.Points++;
                        }

                    }
                    else
                        goldCoins.Remove(gc);
                }
            }

            if (!player.IsAlive)
                return State.Menu;
            return State.Run;
        }

        public static void RunDraw(SpriteBatch spriteBatch)
        {


            player.Draw(spriteBatch);

            foreach (Enemies e in enemies)
                e.Draw(spriteBatch);
            printText.Print("Enemies Left : " + enemies.Count, spriteBatch, 0, 0);

            foreach (GoldCoin gc in goldCoins)
                gc.Draw(spriteBatch);
            printText.Print("Points Obtained : " + player.Points, spriteBatch, 0, 20);


        }

           
        public static State HighScoreUpdate()
        {

            KeyboardState KeyboardState = Keyboard.GetState();

            if (KeyboardState.IsKeyDown(Keys.Escape))
                return State.Menu;
            return State.Highscore;
        }

        public static void HighScoreDraw(SpriteBatch spriteBatch)
        {

        }
    }
}
