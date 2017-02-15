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
        int JoueurMax { get; set; }
        bool[] ManetteActive { get; set; }
        PlayerIndex[] NumJoueur { get; set; }
        bool DÈconnection { get; set; }
        Color CouleurFond { get; set; }
        GamePadState Ancien…tatManette { get; set; }

        GamePadState …tatManette { get; set; }
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
            DÈconnection = false;
            base.Initialize();
        }



        public override void Update(GameTime gameTime)
        {
            Ancien…tatManette = …tatManette;

        }


        public bool EstManetteActivÈe(PlayerIndex numManette)
        {
            …tatManette = GamePad.GetState(numManette);
            return …tatManette.IsConnected;
        }

        public bool EstNouvelleTouche(PlayerIndex numManette, Buttons touche)
        {
            …tatManette = GamePad.GetState(numManette);
            return …tatManette.IsButtonDown(touche) && Ancien…tatManette.IsButtonUp(touche);
        }

        public bool EstToucheEnfoncÈe(PlayerIndex numManette, Buttons touche)
        {
            …tatManette = GamePad.GetState(numManette);
            return …tatManette.IsButtonDown(touche);
        }


    }
}
