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

namespace AtelierXNA
{//Partie à Ludo.
    public class Jeu : Microsoft.Xna.Framework.Game
    {
        #region Propriétés, constantes et initialisation.
        public const float INTERVALLE_STANDARD = 1f / 60;
        public const float ACCÉLÉRATION_GRAVITATIONNELLE = 9.8f;
        public Vector3 VECTEUR_ACCÉLÉRATION_GRAVITATIONNELLE = ACCÉLÉRATION_GRAVITATIONNELLE*(Vector3.Down);

        GraphicsDeviceManager PériphériqueGraphique { get; set; }
        RessourcesManager<Texture2D> GestionnaireDeTextures { get; set; }
        SpriteBatch GestionSprites { get; set; }
        InputManager GestionInput { get; set; }//À DES FINS DE TESTS SEULEMENTS
        InputControllerManager GestionManette { get; set; }
        List<Personnage> ListeDesPersonnages { get; set; }
        Caméra CaméraJeu { get; set; }
        private bool JeuEnPause { get; set; }
        //Menu {boutons}



        public Jeu()
        {
            PériphériqueGraphique = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            GestionInput = new InputManager(this);
            GestionManette = new InputControllerManager(this);
            CaméraJeu = new CaméraSubjective(this, Vector3.Zero, Vector3.Zero, Vector3.Up, INTERVALLE_STANDARD);
            GestionSprites = new SpriteBatch(GraphicsDevice);
            GestionnaireDeTextures = new RessourcesManager<Texture2D>(this,"Textures");


            Services.AddService(typeof(InputManager), GestionInput);
            Services.AddService(typeof(GraphicsDeviceManager),PériphériqueGraphique);
            Services.AddService(typeof(InputControllerManager), GestionManette);
            Services.AddService(typeof(RessourcesManager<Texture2D>), GestionnaireDeTextures);
            Services.AddService(typeof(Caméra), CaméraJeu);

            Map carteDuJeu = new Map(this, 1, Vector3.Zero, Vector3.Zero);

            Components.Add(carteDuJeu);

            base.Initialize();
        }


        // A recoder avec l'interface(menu)
        // Utiliser comme test pour le momment
        // Si ta un prob vien voir marco au rak a bicyk!!!
        void CréationPersonnage()
        {
            Personnage unPersonnage = new Personnage(this, 1, 1, 1, new Vector3(0, 0, 0), PlayerIndex.One);
            ListeDesPersonnages.Add(unPersonnage);
            Services.AddService(typeof(List<Personnage>), ListeDesPersonnages);
        }


        protected override void LoadContent()
        {

           


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
        private void GérerManette()
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
        private void NettoyerListeComposants()
        {

        }
        #endregion
    }
}
