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
    
 
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class InputControllerManager : Microsoft.Xna.Framework.GameComponent
    {
        int JoueurMax { get; set; }
        bool[] ManetteActive { get; set; }
        PlayerIndex[] NumJoueur { get; set; }
        bool Déconnection { get; set; }
        Color CouleurFond { get; set; }
        GestionnaireDesManette uneManette;

        public InputControllerManager(Game game)
            : base(game)
        {
        }


        public override void Initialize()
        {
            JoueurMax = uneManette.NbManetteMax;
            NumJoueur[0] = PlayerIndex.One;
            NumJoueur[1] = PlayerIndex.Two;
            Déconnection = false;
            base.Initialize();
        }



        public override void Update(GameTime gameTime)
        {
        }
           

        public bool EstManetteActivée(PlayerIndex numManette)
        {
            GamePadState ÉtatManette = GamePad.GetState(numManette);
            return ÉtatManette.IsConnected;
        }

        public bool EstNouvelleTouche(PlayerIndex numManette, Buttons touche)
        {
            GamePadState ÉtatManette = GamePad.GetState(numManette);
            return ÉtatManette.IsButtonDown(touche) && ÉtatManette.IsButtonUp(touche);
        }

        public bool EstToucheEnfoncée(PlayerIndex numManette, Buttons touche)
        {
            GamePadState ÉtatManette = GamePad.GetState(numManette);
            return ÉtatManette.IsButtonDown(touche);
        }


    }
}
