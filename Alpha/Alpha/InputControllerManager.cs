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
        bool D�connection { get; set; }
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
            D�connection = false;
            base.Initialize();
        }



        public override void Update(GameTime gameTime)
        {
        }
           

        public bool EstManetteActiv�e(PlayerIndex numManette)
        {
            GamePadState �tatManette = GamePad.GetState(numManette);
            return �tatManette.IsConnected;
        }

        public bool EstNouvelleTouche(PlayerIndex numManette, Buttons touche)
        {
            GamePadState �tatManette = GamePad.GetState(numManette);
            return �tatManette.IsButtonDown(touche) && �tatManette.IsButtonUp(touche);
        }

        public bool EstToucheEnfonc�e(PlayerIndex numManette, Buttons touche)
        {
            GamePadState �tatManette = GamePad.GetState(numManette);
            return �tatManette.IsButtonDown(touche);
        }


    }
}
