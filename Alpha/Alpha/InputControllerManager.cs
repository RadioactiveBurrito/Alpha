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
    public class InputControllerManager : Microsoft.Xna.Framework.GameComponent
    {
        public int NbManetteMax { get; private set; }
        int JoueurMax { get; set; }
        bool[] ManetteActive { get; set; }
        PlayerIndex NumJoueur { get; set; }
        bool D�connection { get; set; }
        Color CouleurFond { get; set; }
        GameState gameState { get; set; }
        GamePadState Ancien�tatManette { get; set; }

        GamePadState �tatManette { get; set; }
        GestionnaireDesManette uneManette;

        public InputControllerManager(Game game)
            : base(game)
        {
        }


        public override void Initialize()
        {
            JoueurMax = uneManette.NbManetteMax;
            D�connection = false;
            base.Initialize();
        }

        enum GameState
        {
            InputSetup = 0,
            Jeu,
            D�conecter
        }

        public override void Update(GameTime gameTime)
        {
            Ancien�tatManette = �tatManette;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==
               ButtonState.Pressed)
                Game.Exit();

            TestConnectionManette();
            

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
                    EstManetteActiv�e(NumJoueur))
                {
                    D�connection = true;
                }
            }
        }


        public bool EstManetteActiv�e(PlayerIndex numManette)
        {
            �tatManette = GamePad.GetState(numManette);
            return �tatManette.IsConnected;
        }

        public bool EstNouvelleTouche(PlayerIndex numManette, Buttons touche)
        {
            �tatManette = GamePad.GetState(numManette);
            return �tatManette.IsButtonDown(touche) && Ancien�tatManette.IsButtonUp(touche);
        }

        public bool EstToucheEnfonc�e(PlayerIndex numManette, Buttons touche)
        {
            �tatManette = GamePad.GetState(numManette);
            return �tatManette.IsButtonDown(touche);
        }


    }
}
