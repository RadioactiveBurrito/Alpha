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
    public class PersonnageAnimé : Personnage
    {
        Vector2 NbImages { get; set; }
        int DeltaX { get; set; }
        int DeltaY { get; set; }
        Rectangle RectangleSource { get; set; }
        protected int MargeGauche { get; set; }
        protected int MargeDroite { get; set; }
        protected int MargeHaut { get; set; }
        protected int MargeBas { get; set; }
        protected SpriteBatch GestionSprite { get; set; }
        protected Texture2D FeuilleDeSprite { get; set; } //Redéfinir le rectangle de collision selon le découpage de cette feuille sprite.
        float Intervalle_StunAnimation { get; set; }
        float TempsÉcouléDepuisMAJ { get; set; }



        public PersonnageAnimé(Game game, float vitesseDéplacementGaucheDroite, float hauteurMaximaleSaut, float masse, Vector3 position, Texture2D feuilleDeSprite, Vector2 nbImages, PlayerIndex numeroManette)
           : base(game, vitesseDéplacementGaucheDroite, hauteurMaximaleSaut, masse, position, numeroManette)
        {
            NbImages = nbImages;
            FeuilleDeSprite = feuilleDeSprite;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            CalculerMarges();
            RectangleSource = new Rectangle(0, 0, DeltaX, DeltaY);
        }

        public override void Update(GameTime gameTime)
        {
            Vector3 anciennePosition = Position;
            base.Update(gameTime);
            Vector3 nouvellePosition = Position;
            GérerPosition(anciennePosition, nouvellePosition);
        }

        void CalculerMarges()
        {
            DeltaX = FeuilleDeSprite.Width / (int)NbImages.X;
            DeltaY = FeuilleDeSprite.Height / (int)NbImages.Y;
            MargeDroite = Game.Window.ClientBounds.Width - DeltaX;
            MargeBas = Game.Window.ClientBounds.Height - DeltaY;
        }


        private void GérerPosition(Vector3 anciennePosition, Vector3 nouvellePosition)
        {
            Vector3 différenceDéplacement = Vector3.Subtract(nouvellePosition, anciennePosition);
            int orientation = -1;

            if (différenceDéplacement.X != 0)
            {
                orientation = différenceDéplacement.X < 0 ? 0 : 2;
            }
            if (différenceDéplacement.Y != 0 || (différenceDéplacement.Y != 0 && différenceDéplacement.X != 0))
            {
                orientation = différenceDéplacement.Y < 0 ? 3 : 1;
            }

            CréerRectangle(orientation);
        }

        protected void ActiverCoup1()
        {

        }

        protected void ActiverCoup2()
        {

        }

        protected void ActiverSaut()
        {

        }

        private void CréerRectangle(int NbDeltaY)
        {
            if (0 <= NbDeltaY)
            {
                RectangleSource = new Rectangle((RectangleSource.X + DeltaX) % FeuilleDeSprite.Width, NbDeltaY * DeltaY, DeltaX, DeltaY);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            GestionSprite.Draw(FeuilleDeSprite, Position, RectangleSource, Color.White);
        }
    }
}

