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
        Texture2D imagen;
        Vector2 PosicionFotograma = new Vector2(350, 250);
        byte r, g, b;
        bool Direccion_Horizontal;
        bool Direccion_Vertical;

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
            imagen = Content.Load<Texture2D>("Balon4");

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
            if (PosicionFotograma.X >= 590)
            {
                Direccion_Horizontal = false;
                r += 40;
                g += 70;
                b += 10;
            }
            else if (PosicionFotograma.X <= 0)
            {
                Direccion_Horizontal = true;
                r += 10;
                g += 40;
                b += 70;
            }
            if (Direccion_Horizontal == true)
            {
                PosicionFotograma.X += 5;
            }

            else if (Direccion_Horizontal == false)
            {
                PosicionFotograma.X -= 5;
            }

            //Movemos vertical
            if (PosicionFotograma.Y >= 280)
            {
                Direccion_Vertical = false;
                r += 80;
                g += 60;
                b += 10;
            }
            else if (PosicionFotograma.Y <= 0)
            {
                Direccion_Vertical = true;
                r += 100;
                g += 90;
                b += 50;
            }
            if (Direccion_Vertical == true)
            {
                PosicionFotograma.Y += 5;
            }

            else if (Direccion_Vertical == false)
            {
                PosicionFotograma.Y -= 5;
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
            spriteBatch.Draw(imagen, PosicionFotograma, Color.White);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
