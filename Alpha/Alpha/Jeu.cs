using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Alpha
{

    public class Jeu : Microsoft.Xna.Framework.Game
    {
        #region Propriétés, constantes et initialisation.
        public const float INTERVALLE_STANDARD = 1f / 60;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private bool JeuEnPause { get; set; }
        //Menu {boutons}



        public Jeu()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);


        }

        private void InitialiserCarte()
        {

        }
        private void InitialiserEntitées()
        {

        }
        #endregion

        #region Méthodes en lien avec la boucle de jeu.
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
        private void GérerClavier()
        {

        }
        private void GérerCollisions()
        {

        }
        private void GérerCaméra()
        {

        }
        private void GérerMenu()
        {

        }
        #endregion
    }
}
