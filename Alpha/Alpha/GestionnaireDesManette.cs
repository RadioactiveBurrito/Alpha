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
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class GestionnaireDesManette : Microsoft.Xna.Framework.GameComponent
    {
        Vector3 GAUCHE = new Vector3(-1f, 0, 0);
        Vector3 DROITE = new Vector3(1f, 0, 0);


        public int NbManetteMax { get; private set; }
        bool[] ManetteActive { get; set; }
        GameState gameState { get; set; }
        GamePadState �tatManette { get; set; }
        PlayerIndex NumJoueur { get; set; }
        bool D�connection { get; set; }
        Color CouleurFond { get; set; }
        GraphicsDeviceManager graphics;
        GestionnaireDesManette uneManette;
        InputControllerManager GestionManette { get; set; }
        GamePadState AncienneTouche { get; set; }
        GamePadState nouvelleTouche { get; set; }
        Vector2 nouvellePosition { get; set; }
        Vector2 anciennePosition { get; set; }
        float ascension = 50;
        List<Personnage> listeDesPersonnages { get; set; }




        public GestionnaireDesManette(Game game, int nbManetteMax)
            : base(game)
        {
            NbManetteMax = nbManetteMax;
        }

        enum GameState
        {
            InputSetup = 0,
            Jeu,
            D�conecter
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            GestionManette = Game.Services.GetService(typeof(InputControllerManager)) as InputControllerManager;
            listeDesPersonnages = Game.Services.GetService(typeof(List<Personnage>)) as List<Personnage>;
           

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>

        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==
                ButtonState.Pressed)
                Game.Exit();

            TestConnectionManette();
            for (int i = 0; i < NbManetteMax; i++)
            {
                GestionDesManette();
            }

            switch (gameState)
            {
                case GameState.InputSetup:
                    // Allow players to join the game, 
                    // and determine active controllers.
                    // In this example, there is only one player.
                    ManetteActive[0] = true;

                    // When ready, proceed to the game.
                    gameState = GameState.Jeu;
                    break;

                case GameState.Jeu:
                    // If disconnected, go to the disconnect loop.
                    if (D�connection)
                    {
                        CouleurFond = Color.Black;
                        gameState = GameState.D�conecter;
                    }
                    break;

                case GameState.D�conecter:
                    // If reconnected, continue to the game.
                    if (!D�connection)
                    {
                        CouleurFond = Color.CornflowerBlue;
                        gameState = GameState.Jeu;
                    }
                    // Otherwise, pause the game and display a message.
                    break;
            }
            base.Update(gameTime);
        }

        void TestConnectionManette()
        {
            D�connection = false;
            for (int i = 0; i < NbManetteMax; i++)
            {
                if (ManetteActive[i] &&
                    !GestionManette.EstManetteActiv�e(NumJoueur))
                {
                    D�connection = true;
                }
            }
        }

        void GestionDesManette()
        {
            nouvelleTouche = GamePad.GetState(NumJoueur);
            if (GestionManette.EstManetteActiv�e(NumJoueur))
            {
                G�rerD�placement();
                G�rerAction();
               

                AncienneTouche = nouvelleTouche;
            }

        }

        void G�rerD�placement()
        {
            nouvellePosition = nouvelleTouche.ThumbSticks.Left;
            G�rerD�placementHorizontale();
            anciennePosition = nouvellePosition;

        }

       

        void G�rerD�placementHorizontale()
        {
            if (nouvellePosition.X == 1.0f)
            {
                listeDesPersonnages[Convert.ToInt32(NumJoueur.ToString())].ModifierPosition(DROITE);
            }

            if (nouvellePosition.X == -1.0f)
            {
                listeDesPersonnages[Convert.ToInt32(NumJoueur.ToString())].ModifierPosition(GAUCHE);
            }
        }

        void G�rerAction()
        {
            Sauter();
            Coup1();
        }

        void Sauter()
        {
            if (GestionManette.EstNouvelleTouche(NumJoueur, Buttons.A))
            {
                float i = ascension;
                Vector3 monter = new Vector3(0, 20f, 0);
                int descente = 0;
                while (i > 0)
                {
                    listeDesPersonnages[Convert.ToInt32(NumJoueur.ToString())-1].ModifierPosition(monter);
                    ++descente;
                    monter.Y -= descente;
                }
            }
        }

        void Coup1()
        {
            if (GestionManette.EstNouvelleTouche(NumJoueur, Buttons.X))
            {
                Coup1Gauche(NumJoueur);
                Coup1Droit(NumJoueur);

            }
            
        }

        void Coup1Gauche(PlayerIndex numJoueur)
        {
            
        }

        void Coup1Droit(PlayerIndex numJoueur)
        {
            
        }

        void Coup2(PlayerIndex numJoueur)
        {
            if (GestionManette.EstNouvelleTouche(numJoueur, Buttons.B))
            {
                Coup2Gauche(numJoueur);
                Coup2Droit(numJoueur);

            }

        }

        void Coup2Gauche(PlayerIndex numJoueur)
        {

        }

        void Coup2Droit(PlayerIndex numJoueur)
        {

        }
    }
}
