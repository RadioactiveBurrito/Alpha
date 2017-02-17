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
    public class Personnage : Microsoft.Xna.Framework.DrawableGameComponent
    {
        #region Propri�t�s, constantes et initialisation.
        //Donn�es propres au personnage, qui sont constantes et enti�rement d�termin�es � l'initialisation.
        int Vie { get; set; } //Indiqu�e en pour�entage.
        float VitesseD�placementGaucheDroite { get; set; } //Le scalaire par d�faut des d�placements gauche/droite.
        float VitesseD�placementSaut { get; set; } //Le scalaire par d�faut du d�placement vers le haut.
        float HauteurMaximaleSaut { get; set; } //Le scalaire repr�sentant la longueur maximale du vecteur normal � la surface d'o� le personnage saute.
        float Masse { get; set; } //Le scalaire repr�sentant la masse du personnage qui sera utilis�e lors des calculs vectoriels de collisions.
        PlayerIndex NumeroManette { get; set; }


        //Donn�es propres au personnages, qui seront variables.
        protected Vector3 Position { get; set; }
        Vector3 VecteurQuantit�eDeMouvement { get; set; }
        Rectangle RectangleDeCollision { get; set; }
        InputControllerManager GestionManette { get; set; }
        int CptSaut { get; set; }
       bool EstDansLesAir { get; set; }

        float Intervalle_StunAnimation { get; set; }
        float Temps�coul�DepuisMAJ { get; set; }
        

        public Personnage(Game game, float vitesseD�placementGaucheDroite, float hauteurMaximaleSaut, float masse, Vector3 position, PlayerIndex numeroManette)
            : base(game)
        {
            VitesseD�placementGaucheDroite = vitesseD�placementGaucheDroite;
            HauteurMaximaleSaut = hauteurMaximaleSaut;
            VitesseD�placementSaut = (float)Math.Sqrt(2*Jeu.ACC�L�RATION_GRAVITATIONNELLE*HauteurMaximaleSaut);
            Masse = masse;
            Position = position;
            NumeroManette = numeroManette;
        }
        public override void Initialize()
        {
            VecteurQuantit�eDeMouvement = Vector3.Zero;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            GestionManette = Game.Services.GetService(typeof(InputControllerManager)) as InputControllerManager;
            base.LoadContent();
        }
        #endregion

        #region Boucle de jeu.
        public override void Update(GameTime gameTime)
        {
            float temps�coul� = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Temps�coul�DepuisMAJ += temps�coul�;
            Intervalle_StunAnimation -= temps�coul�;

            if (Temps�coul�DepuisMAJ >= Jeu.INTERVALLE_STANDARD)
            {
                if (Intervalle_StunAnimation <= 0)
                {
                    // G�rer D�placement (on ne veut pas bouger si l'animation d'une attaque se fait)
                    G�rerContr�les();
                    G�rerD�placements();
                }
                // animation sera fait par la classe PersonnageAnim�
                // Input a faire avec ControllerManager
            }
            base.Update(gameTime);
        }



        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
        private void G�rerContr�les()
        {
            Vector3 positionInitiale = Position;

            if (GestionManette.EstNouvelleTouche(NumeroManette, Buttons.LeftThumbstickRight))//Aller � droite. Le vecteur "droite" se d�finira par la position de la carte. 
            {
                Position += Vector3.Right*VitesseD�placementGaucheDroite;//PROBL�MES POUR GAUCHE DROITE, COMMENT G�RER?!
                VecteurQuantit�eDeMouvement = (Position - positionInitiale) * Masse;
            }
            if (GestionManette.EstNouvelleTouche(NumeroManette, Buttons.LeftThumbstickLeft))//Aller � gauche. Le vecteur "gauche" se d�finira par la position de la carte. 
            {
                Position += Vector3.Left * VitesseD�placementGaucheDroite;
                VecteurQuantit�eDeMouvement = (Position - positionInitiale) * Masse;//PROBL�MES POUR GAUCHE DROITE, COMMENT G�RER?!
            }
            if (GestionManette.EstNouvelleTouche(NumeroManette, Buttons.A))//Sauter ou double saut (si le cas est �ch�ant). Le vecteur "haut" se d�finira par la position de la carte. 
            {
                Position += Vector3.Up * VitesseD�placementSaut;
                VecteurQuantit�eDeMouvement = (Position - positionInitiale) * Masse;
            }
            if(GestionManette.EstNouvelleTouche(NumeroManette, Buttons.X))//Attaque corps � corps
            {

            }
            if(GestionManette.EstNouvelleTouche(NumeroManette, Buttons.Y))//Lancer de projectile (s'il y a lieu).
            {

            }
        }
        private void G�rerD�placements()
        {

        }
        public void EncaisserD�g�ts()
        {

        }
        public void ModifierPosition(Vector3 bouger)
        {
            Position += bouger;
        }
        public bool EstEnCollision()
        {
            return false;
        }
        #endregion
    }
}
