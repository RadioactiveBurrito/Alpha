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

    public class Map : PrimitiveDeBase
    {

        const int NB_TRIANGLE_SURFACE = 2;
        const int NB_TRIANGLE_BASE = 8;
        const int NB_SOMMETS_LIST = 3;
        const int coeff_Surface = 2;
        const int coeff_Base = 4;
        const int hauteur = 15;

        float Largeur { get; set; }
        float Longueur { get; set; }
        Vector3 Origine { get; set; }
        Vector3[] PtsSommets { get; set; }
        VertexPositionColor[] Sommets { get; set; }
        VertexPositionColor[] SommetsBase { get; set; }
        BasicEffect EffetDeBase { get; set; }


        public Map(Game game, float homothetie, Vector3 rotationInitiale, Vector3 position)
           : base(game, homothetie, rotationInitiale, position)
        {
            Origine = position;
        }

        public override void Initialize()
        {
            Longueur = 100f;
            Largeur = 50;
            InitialiserPtsSommets();
            InitialiserSommets();
            Game.Components.Add(new Plaquette(this.Game, 1, Vector3.Zero, new Vector3(Origine.X - Longueur / 4, Origine.Y + hauteur, Origine.Z)));
            Game.Components.Add(new Plaquette(this.Game, 1, Vector3.Zero, new Vector3(Origine.X + Longueur / 4, Origine.Y + hauteur, Origine.Z)));

            base.Initialize();
        }
        void InitialiserPtsSommets()
        {
            // Pas besoin de faire le coter arriere car la camera va juste voir lavant et peu etre les coter
            PtsSommets = new Vector3[(NB_TRIANGLE_SURFACE + NB_TRIANGLE_BASE) * NB_SOMMETS_LIST];

            //Plaque Du dessus
            PtsSommets[0] = new Vector3(Origine.X - Longueur / coeff_Surface, Origine.Y, Origine.Z - Largeur / coeff_Surface);
            PtsSommets[1] = new Vector3(Origine.X + Longueur / coeff_Surface, Origine.Y, Origine.Z + Largeur / coeff_Surface);
            PtsSommets[2] = new Vector3(Origine.X - Longueur / coeff_Surface, Origine.Y, Origine.Z + Largeur / coeff_Surface);
            PtsSommets[3] = PtsSommets[0];
            PtsSommets[4] = new Vector3(Origine.X + Longueur / coeff_Surface, Origine.Y, Origine.Z - Largeur / coeff_Surface);
            PtsSommets[5] = PtsSommets[1];

            //Plaque du dessous
            PtsSommets[6] = new Vector3(Origine.X - Longueur / coeff_Base, Origine.Y - hauteur, Origine.Z - Largeur / coeff_Base);
            PtsSommets[7] = new Vector3(Origine.X - Longueur / coeff_Base, Origine.Y - hauteur, Origine.Z + Largeur / coeff_Base);
            PtsSommets[8] = new Vector3(Origine.X + Longueur / coeff_Base, Origine.Y - hauteur, Origine.Z + Largeur / coeff_Base);
            PtsSommets[9] = PtsSommets[6];
            PtsSommets[10] = PtsSommets[8];
            PtsSommets[11] = new Vector3(Origine.X + Longueur / 3, Origine.Y - hauteur, Origine.Z - Largeur / 3);

            //Coter Face
            PtsSommets[12] = PtsSommets[7];
            PtsSommets[13] = PtsSommets[2];
            PtsSommets[14] = PtsSommets[8];
            PtsSommets[15] = PtsSommets[2];
            PtsSommets[16] = PtsSommets[1];
            PtsSommets[17] = PtsSommets[8];

            //Coter Droit
            PtsSommets[18] = PtsSommets[1];
            PtsSommets[19] = PtsSommets[11];
            PtsSommets[20] = PtsSommets[8];
            PtsSommets[21] = PtsSommets[4];
            PtsSommets[22] = PtsSommets[11];
            PtsSommets[23] = PtsSommets[1];

            //Coter Gauche
            PtsSommets[24] = PtsSommets[2];
            PtsSommets[25] = PtsSommets[7];
            PtsSommets[26] = PtsSommets[6];
            PtsSommets[27] = PtsSommets[2];
            PtsSommets[28] = PtsSommets[6];
            PtsSommets[29] = PtsSommets[0];


        }
        protected override void InitialiserSommets()
        {
            Sommets = new VertexPositionColor[NB_TRIANGLE_SURFACE * NB_SOMMETS_LIST];
            SommetsBase = new VertexPositionColor[NB_TRIANGLE_BASE * NB_SOMMETS_LIST];
            for (int i = 0; i < PtsSommets.Length; ++i)
            {
                if (i > Sommets.Length - 1) // est rendu a la base                
                    SommetsBase[i - Sommets.Length] = new VertexPositionColor(PtsSommets[i], Color.SaddleBrown);
                else
                    Sommets[i] = new VertexPositionColor(PtsSommets[i], Color.ForestGreen);
            }
        }
        protected override void LoadContent()
        {
            base.LoadContent();
            EffetDeBase = new BasicEffect(GraphicsDevice);
        }

        public override void Draw(GameTime gameTime)
        {
            EffetDeBase.World = GetMonde();
            EffetDeBase.View = Cam�raJeu.Vue;
            EffetDeBase.Projection = Cam�raJeu.Projection;
            EffetDeBase.VertexColorEnabled = true;

            RasterizerState ancien�tat = GraphicsDevice.RasterizerState;
            RasterizerState �tat = new RasterizerState();
            �tat.CullMode = CullMode.CullCounterClockwiseFace;
            �tat.FillMode = GraphicsDevice.RasterizerState.FillMode;
            GraphicsDevice.RasterizerState = �tat;

            foreach (EffectPass passeEffet in EffetDeBase.CurrentTechnique.Passes)
            {
                passeEffet.Apply();
                GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, Sommets, 0, NB_TRIANGLE_SURFACE);
                GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, SommetsBase, 0, NB_TRIANGLE_BASE);
            }
            GraphicsDevice.RasterizerState = ancien�tat;

        }
        public Vector3 GetNormal()
        {
            // retourne l'interrvalle en x de la hauteur de la surface
            return new Vector3(Origine.X - Longueur / coeff_Surface, Origine.X + Longueur / coeff_Surface, Origine.Y);
        }


    }
}
