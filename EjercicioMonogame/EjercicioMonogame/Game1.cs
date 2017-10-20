using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EjercicioMonogame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D balon, ronaldo,GameOver;
        Rectangle PosicionBalon = new Rectangle(0,0,100,100);
        Rectangle Posicionronaldo = new Rectangle(350, 365, 100, 115);
        Rectangle PosicionGameOver = new Rectangle(150, 90, 500, 300);
        byte r, g, b;
        bool Direccion_Horizontal;
        bool Direccion_Vertical;
        bool Choque;

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
            // TODO: Add your initialization logic here
            r = 0;
            g = 0;
            b = 0;
            Direccion_Horizontal = true;
            Direccion_Vertical = true;
            Choque = false;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            balon = Content.Load<Texture2D>("Balon4");
            ronaldo = Content.Load<Texture2D>("Ronaldo");
            GameOver = Content.Load<Texture2D>("Game Over");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //Movemos Horizontal
            if (PosicionBalon.X >= 700)
            {
                Direccion_Horizontal = false;
                r += 40;
                g += 70;
                b += 10;
            }
            else if (PosicionBalon.X <= 0)
            {
                Direccion_Horizontal = true;
                r += 10;
                g += 40;
                b += 70;
            }
            if (Direccion_Horizontal == true)
            {
                PosicionBalon.X += 5;
            }

            else if (Direccion_Horizontal == false)
            {
                PosicionBalon.X -= 5;
            }

            //Movemos vertical
            if (PosicionBalon.Y >= 380)
            {
                Direccion_Vertical = false;
                r += 80;
                g += 60;
                b += 10;
            }
            else if (PosicionBalon.Y <= 0)
            {
                Direccion_Vertical = true;
                r += 100;
                g += 90;
                b += 50;
            }
            if (Direccion_Vertical == true)
            {
                PosicionBalon.Y += 5;
            }

            else if (Direccion_Vertical == false)
            {
                PosicionBalon.Y -= 5;
            }

            //Movimiento por teclado
            if (Posicionronaldo.X >= 700)
            {

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Posicionronaldo.X += 5;
            }

            if (Posicionronaldo.X <=0)
            {
                Posicionronaldo.X += 0;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Posicionronaldo.X -= 5;
            }

            //Colisión del balón y el jugador
            if (PosicionBalon.Intersects(Posicionronaldo))
            {
                Choque = true;
            }

            if (Choque == true)
            {
                r = 0;
                g = 0;
                b = 0;
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Color miColor = new Color(r, g, b);
            GraphicsDevice.Clear(miColor);
            spriteBatch.Begin();
            if ( Choque == false)
            {
                spriteBatch.Draw(ronaldo, Posicionronaldo, Color.White);
                spriteBatch.Draw(balon, PosicionBalon, Color.White);
            }
            else if (Choque == true)
            {
                spriteBatch.Draw(GameOver, PosicionGameOver, Color.White);
            }
            

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
