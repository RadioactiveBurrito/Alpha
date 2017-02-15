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
        #region Propriétés, constantes et initialisation.
        //Données propres au personnage, qui sont constantes et entièrement déterminées à l'initialisation.
        int Vie { get; set; } //Indiquée en pourçentage.
        float VitesseDéplacementGaucheDroite { get; set; } //Le scalaire par défaut des déplacements gauche/droite.
        float VitesseDéplacementSaut { get; set; } //Le scalaire par défaut du déplacement vers le haut.
        float HauteurMaximaleSaut { get; set; } //Le scalaire représentant la longueur maximale du vecteur normal à la surface d'où le personnage saute.
        float Masse { get; set; } //Le scalaire représentant la masse du personnage qui sera utilisée lors des calculs vectoriels de collisions.
        Texture2D FeuilleDeSprite { get; set; } //Redéfinir le rectangle de collision selon le découpage de cette feuille sprite.


        //Données propres au personnages, qui seront variables.
        Vector3 Position { get; set; }
        Vector3 VecteurVitesse { get; set; }
        Vector3 VecteurQuantitéeDeMouvement { get; set; }
        Rectangle RectangleDeCollision { get; set; }
        int CptSaut { get; set; }


        float Intervalle_StunAnimation { get; set; }
        float TempsÉcouléDepuisMAJ { get; set; }
        

        public Personnage(Game game, float vitesseDéplacementGaucheDroite, float hauteurMaximaleSaut, float masse, Vector3 position)
            : base(game)
        {
            VitesseDéplacementGaucheDroite = vitesseDéplacementGaucheDroite;
            HauteurMaximaleSaut = hauteurMaximaleSaut;
            VitesseDéplacementSaut = (float)Math.Sqrt(2*Jeu.ACCÉLÉRATION_GRAVITATIONNELLE*HauteurMaximaleSaut);
            Masse = masse;
            Position = position;
        }
        public override void Initialize()
        {
            VecteurVitesse = Vector3.Zero;
            VecteurQuantitéeDeMouvement = Vector3.Zero;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();
        }
        #endregion

        #region Boucle de jeu.
        public override void Update(GameTime gameTime)
        {
            float tempsÉcoulé = (float)gameTime.ElapsedGameTime.TotalSeconds;
            TempsÉcouléDepuisMAJ += tempsÉcoulé;
            Intervalle_StunAnimation -= tempsÉcoulé;

            if (TempsÉcouléDepuisMAJ >= Jeu.INTERVALLE_STANDARD)
            {
                if (Intervalle_StunAnimation <= 0)
                {
                    // Gérer Déplacement (on ne veut pas bouger si l'animation d'une attaque se fait)
                    GérerContrôles();
                    GérerDéplacements();
                }
                // animation sera fait par la classe PersonnageAnimé
                // Input a faire avec ControllerManager
            }
            base.Update(gameTime);
        }



        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
        private void GérerContrôles()
        {
            if(false)//Aller à droite. Le vecteur "droite" se définira par la position de la carte. 
            {
                VecteurVitesse += Vector3.Right*VitesseDéplacementGaucheDroite;//PROBLÈMES POUR GAUCHE DROITE, COMMENT GÉRER?!
                VecteurQuantitéeDeMouvement = VecteurVitesse * Masse;
            }
            if (false)//Aller à gauche. Le vecteur "gauche" se définira par la position de la carte. 
            {
                VecteurVitesse += Vector3.Left * VitesseDéplacementGaucheDroite;
                VecteurQuantitéeDeMouvement = VecteurVitesse * Masse;//PROBLÈMES POUR GAUCHE DROITE, COMMENT GÉRER?!
            }
            if (false)//Sauter ou double saut (si le cas est échéant). Le vecteur "haut" se définira par la position de la carte. 
            {
                VecteurVitesse += Vector3.Up * VitesseDéplacementSaut;
                VecteurQuantitéeDeMouvement = VecteurVitesse * Masse;
            }
            if(false)//Attaque corps à corps
            {

            }
            if(false)//Lancer de projectile (s'il y a lieu).
            {

            }
        }
        private void GérerDéplacements()
        {

        }
        public void EncaisserDégâts()
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
