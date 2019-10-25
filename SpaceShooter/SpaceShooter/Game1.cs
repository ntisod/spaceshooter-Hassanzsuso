using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceShooter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 


    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
  


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            GameElements.currentState = GameElements.State.Menu;
            GameElements.Initalize();
            base.Initialize();

            
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            GameElements.LoadContent(Content, Window);
           
            
        }


        protected override void UnloadContent()
        {

        }


        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
               this.Exit();
            
            switch(GameElements.currentState)
            {
                case GameElements.State.Run:
                    GameElements.currentState = GameElements.RunUpdate(Content, Window, gameTime);
                    break;

                case GameElements.State.Highscore:
                    GameElements.currentState = GameElements.HighScoreUpdate();
                    break;

                case GameElements.State.Quit:
                    this.Exit();
                    break;

                default: GameElements.currentState = GameElements.MenuUpdate();
                    break;

            }


           
            base.Update(gameTime);

        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);
            GraphicsDevice.Clear(Color.DarkGreen);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            switch(GameElements.currentState)
            {
                case GameElements.State.Run: GameElements.RunDraw(spriteBatch);
                    break;

                case GameElements.State.Highscore: GameElements.HighScoreDraw(spriteBatch);
                    break;

                case GameElements.State.Quit:
                    this.Exit();
                    break;
    
                default: GameElements.MenuDraw(spriteBatch);
                    break;
            }
            
           
                spriteBatch.End();


                base.Draw(gameTime);
            }
        }
    }

