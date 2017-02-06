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


namespace WindowsGame1
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class GestionnaireDesManette : Microsoft.Xna.Framework.GameComponent
    {
        public int NbManetteMax { get; private set; }
        bool[] ManetteActive { get; set; }
        GameState gameState { get; set; }
        GamePadState ÉtatManette { get; set; }
        PlayerIndex[] NumJoueur { get; set; }
        bool Déconnection { get; set; }
        Color CouleurFond { get; set; }
        GraphicsDeviceManager graphics;
        GestionnaireDesManette uneManette;
        InputControllerManager GestionManette { get; set; }
        GamePadState AncienneTouche { get; set; }
        float ascension = 50;




        public GestionnaireDesManette(Game game, int nbManetteMax)
            : base(game)
        {
            NbManetteMax = nbManetteMax;
        }

        enum GameState
        {
            InputSetup = 0,
            Jeu,
            Déconecter
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            GestionManette = Game.Services.GetService(typeof(InputControllerManager)) as InputControllerManager;
            NumJoueur[0] = PlayerIndex.One;
            NumJoueur[1] = PlayerIndex.Two;

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
                GestionDesManette(NumJoueur[0]);
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
                    if (Déconnection)
                    {
                        CouleurFond = Color.Black;
                        gameState = GameState.Déconecter;
                    }
                    break;

                case GameState.Déconecter:
                    // If reconnected, continue to the game.
                    if (!Déconnection)
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
            Déconnection = false;
            for (int i = 0; i < NbManetteMax; i++)
            {
                if (ManetteActive[i] &&
                    !GestionManette.EstManetteActivée(NumJoueur[i]))
                {
                    Déconnection = true;
                }
            }
        }

        void GestionDesManette(PlayerIndex numJoueur)
        {
            GamePadState nouvelleTouche = GamePad.GetState(numJoueur);
            // Process input only if connected.
            if (GestionManette.EstManetteActivée(numJoueur))
            {
                // Increase vibration if the player is tapping the A button.
                // Subtract vibration otherwise, even if the player holds down A
                if (nouvelleTouche.Buttons.LeftStick == ButtonState.Pressed &&
                    AncienneTouche.Buttons.LeftStick == ButtonState.Released)
                {
                    //if( nouvellePosition > anciennePosition)
                    // {
                    //     Position.X += 1;
                    // }

                    //if( nouvellePosition < anciennePosition)
                    // {
                    //      Position.X -= 1;
                    // }

                }

                if(GestionManette.EstNouvelleTouche(numJoueur, Buttons.A))
                {
                    //float i = ascension;
                    //int descente = 0;
                    //while(i > 0)
                    //{
                    //    Position.Y += ascension;
                    //    ++descente;
                    //    ascension -= descente;
                    //}
                }

                AncienneTouche = nouvelleTouche;
            }
        }
    }
}
