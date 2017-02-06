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
    public class InputManager : Microsoft.Xna.Framework.GameComponent
    {
        Keys[] AnciennesTouches { get; set; }
        Keys[] NouvellesTouches { get; set; }
        MouseState AncienClic { get; set; }
        MouseState NouveauClic { get; set; }
        KeyboardState ÉtatClavier { get; set; }
        MouseState ÉtatSouris { get; set; }

        public InputManager(Game game)
         : base(game)
      { }

        public override void Initialize()
        {
            AnciennesTouches = new Keys[0];
            NouvellesTouches = new Keys[0];
            AncienClic = new MouseState();
            NouveauClic = new MouseState();
        }

        public override void Update(GameTime gameTime)
        {
            AnciennesTouches = NouvellesTouches;
            AncienClic = NouveauClic;
            ÉtatClavier = Keyboard.GetState();
            ÉtatSouris = Mouse.GetState();
            NouvellesTouches = ÉtatClavier.GetPressedKeys();
            ÉtatSouris = Mouse.GetState();
            NouveauClic = Mouse.GetState();
        }

        public bool EstSourisActive
        {
            get { return Game.IsMouseVisible == true; }
        }
        public bool EstClavierActivé
        {
            get { return NouvellesTouches.Length > 0; }
        }


        public bool EstAncienClicDroit(Buttons clic)
        {
            return AncienClic.RightButton == ButtonState.Released;
        }
        public bool EstNouveauClicDroit(Buttons clic)
        {
            return NouveauClic.RightButton == ButtonState.Released && AncienClic.RightButton == ButtonState.Released;
        }
        public bool EstAncienClicGauche(Buttons clic)
        {
            return AncienClic.LeftButton == ButtonState.Released;
        }
        public bool EstNouveauClicGauche(Buttons clic)
        {
            return NouveauClic.LeftButton == ButtonState.Released && AncienClic.LeftButton == ButtonState.Released;
        }
        public Point GetPositionSouris()
        {
            return new Point(ÉtatSouris.X, ÉtatSouris.Y);
        }

        public bool EstEnfoncée(Keys touche)
        {
            return ÉtatClavier.IsKeyDown(touche);
        }

        public bool EstNouvelleTouche(Keys touche)
        {
            int nbTouches = AnciennesTouches.Length;
            bool estNouvelleTouche = ÉtatClavier.IsKeyDown(touche);
            int i = 0;
            while (i < nbTouches && estNouvelleTouche)
            {
                estNouvelleTouche = AnciennesTouches[i] != touche;
                ++i;
            }
            return estNouvelleTouche;
        }
    }
}
