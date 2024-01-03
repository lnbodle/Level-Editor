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
    public class Test : Entity
    {
        public Test() { }

        public override void Update()
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.DrawRectangle(new RectangleF(X, Y, 16, 16), Color.AliceBlue);
        }

        public override void EditorDraw(SpriteBatch spriteBatch)
        {
            base.EditorDraw(spriteBatch);
            //spriteBatch.DrawRectangle(new RectangleF(X, Y, 16, 16), Color.AliceBlue);
        }

    }
}
