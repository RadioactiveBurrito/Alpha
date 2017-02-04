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

//Partie à Jacob.
namespace Personnage
{
    public class Personnage : Microsoft.Xna.Framework.DrawableGameComponent
    {
        const float INTERVAL_NORMAL_MAJ = 1f / 60f;

        int Vie { get; set; } // Pourcentage
        int VitesseDeplacement { get; set; }
        float Intervalle_StunAnimation { get; set; }
        float MaxJump { get; set; }
        float Poids { get; set; }
        float TempsÉcouléMAJ { get; set; }
        Vector3 Position { get; set; }

        public Personnage(Game game, int vitesse,float maxJump, float poids, Vector3 position)
            : base(game)
        {
            VitesseDeplacement = vitesse;
            MaxJump = maxJump;
            Poids = poids;
            Position = position;
        }

        public override void Initialize()
        {
            Vie = 0;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            float tempsÉcoulé = (float)gameTime.ElapsedGameTime.TotalSeconds;
            TempsÉcouléMAJ += tempsÉcoulé;
            Intervalle_StunAnimation -= tempsÉcoulé;

            if (TempsÉcouléMAJ >= INTERVAL_NORMAL_MAJ)
            {
                if (Intervalle_StunAnimation <= 0)
                {
                    // Gerer Deplacement (on ne veut pas bouger si l'animation d'une attaque se fait)
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
    }
}
