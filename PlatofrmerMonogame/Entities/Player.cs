using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Engine
{
    [Serializable]
    public class Player : Entity
    {
        public int test = 0;
        public Player() { }

        public override void Update()
        {
            bounds.X += 1;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawRectangle(bounds, Color.DarkOliveGreen);
        }

        public override void EditorDraw(SpriteBatch spriteBatch)
        {
            //base.EditorDraw(spriteBatch);
            //spriteBatch.DrawRectangle(new RectangleF(X, Y, 16, 16), Color.AliceBlue);
        }

    }
}
