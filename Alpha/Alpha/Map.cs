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
        // Adder List des #NORMAL#
        // Plaquette et base.
        const int NB_TRIANGLE = 2;
        const int NB_SOMMETS_LIST = 3;

        float Largeur { get; set; }
        float Longueur { get; set; }
        Vector3 Origine { get; set; }
        Vector3[] PtsSommets { get; set; }
        VertexPositionColor[] Sommets { get; set; }

        BasicEffect EffetDeBase { get; set; }


        public Map(Game game, float homothetie, Vector3 rotationInitiale, Vector3 position)
           : base(game, homothetie, rotationInitiale, position) { }

        public override void Initialize()
        {
            Longueur = 200f;
            Largeur = 100f;
            Origine = Vector3.Zero;
            InitialiserPtsSommets();
            InitialiserSommets();

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
        protected override void InitialiserSommets()
        {
            Sommets = new VertexPositionColor[PtsSommets.Length];
            for (int i = 0; i < Sommets.Length; ++i)
            {
                Sommets[i] = new VertexPositionColor(PtsSommets[i], Color.Gray);
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
            EffetDeBase.View = CamÈraJeu.Vue;
            EffetDeBase.Projection = CamÈraJeu.Projection;
            EffetDeBase.VertexColorEnabled = true;

            RasterizerState ancien…tat = GraphicsDevice.RasterizerState;
            RasterizerState Ètat = new RasterizerState();
            Ètat.CullMode = CullMode.CullCounterClockwiseFace;
            Ètat.FillMode = GraphicsDevice.RasterizerState.FillMode;
            GraphicsDevice.RasterizerState = Ètat;

            foreach (EffectPass passeEffet in EffetDeBase.CurrentTechnique.Passes)
            {
                passeEffet.Apply();
                GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, Sommets, 0, NB_TRIANGLE);
            }
            GraphicsDevice.RasterizerState = ancien…tat;

        }


    }
}