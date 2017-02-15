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
{// Partit Jack
    public class Map : Microsoft.Xna.Framework.DrawableGameComponent
    {
        const int NB_TRIANGLE = 2;
        const int NB_SOMMETS_LIST = 3;
        
        float Largeur { get; set; }
        float Longueur { get; set; }
        Vector3 Origine { get; set; }
        Vector3[] PtsSommets { get; set; }
        VertexPositionColor[] Sommets { get; set; }


        public Map(Game game,float longueur, float largeur ) 
           : base(game)      {       }
       
        public override void Initialize()
        {
            Longueur = 200f;
            Largeur = 100f;
            Origine = Vector3.Zero;
            InitialiserPtsSommets();
            InitialiserPtsSommets();

            base.Initialize();
        }
        void InitialiserPtsSommets()
        {
            PtsSommets = new Vector3[NB_TRIANGLE * NB_SOMMETS_LIST];
            PtsSommets[0] = new Vector3(Origine.X - Longueur / 2, Origine.Y, Origine.Z - Largeur);
            PtsSommets[1] = new Vector3(Origine.X + Longueur / 2, Origine.Y, Origine.Z + Largeur);
            PtsSommets[2] = new Vector3(Origine.X - Longueur / 2, Origine.Y, Origine.Z + Largeur);

            PtsSommets[3] = PtsSommets[0];
            PtsSommets[4] = new Vector3(Origine.X + Longueur / 2, Origine.Y, Origine.Z - Largeur);
            PtsSommets[5] = PtsSommets[1];

        }
        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
