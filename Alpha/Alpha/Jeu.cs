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
{//Partie � Ludo.
    public class Jeu : Microsoft.Xna.Framework.Game
    {
        #region Propri�t�s, constantes et initialisation.
        public const float INTERVALLE_STANDARD = 1f / 60;
        public const float ACC�L�RATION_GRAVITATIONNELLE = 9.8f;
        public Vector3 VECTEUR_ACC�L�RATION_GRAVITATIONNELLE = ACC�L�RATION_GRAVITATIONNELLE*(Vector3.Down);

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        InputManager GestionInput { get; set; }
        InputControllerManager GestionManette { get; set; }
        List<Personnage> ListeDesPersonnages { get; set; }
        private bool JeuEnPause { get; set; }
        //Menu {boutons}



        public Jeu()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            GestionInput = new InputManager(this);
            Services.AddService(typeof(InputManager), GestionInput);

            GestionManette = new InputControllerManager(this);
            Services.AddService(typeof(InputControllerManager), GestionManette);


            base.Initialize();
        }


        // A recoder avec l'interface(menu)
        // Utiliser comme test pour le momment
        // Si ta un prob vien voir marco au rak a bicyk!!!
        void Cr�ationPersonnage()
        {
            Personnage unPersonnage = new Personnage(this, 1, 1, 1, new Vector3(0, 0, 0));
            ListeDesPersonnages.Add(unPersonnage);
            Services.AddService(typeof(List<Personnage>), ListeDesPersonnages);
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);


        }
        private void InitialiserCarte()
        {

        }
        private void InitialiserEntit�es()
        {

        }
        #endregion

        #region M�thodes en lien avec la boucle de jeu.
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
        private void G�rerManette()
        {

        }
        private void G�rerCollisions()
        {

        }
        private void G�rerCam�ra()
        {

        }
        private void G�rerMenu()
        {

        }
        private void NettoyerListeComposants()
        {

        }
        #endregion
    }
}
