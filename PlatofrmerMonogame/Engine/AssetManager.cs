using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public static class AssetManager
    {
        public static Dictionary<string, SpriteFont> fonts;
        public static ContentManager contentManager;
        public static void Load(ContentManager _contentManager)
        {
            fonts = new Dictionary<string, SpriteFont>();
            contentManager = _contentManager;
            LoadFonts();
        }

        static void LoadFonts()
        {
            SpriteFont font = contentManager.Load<SpriteFont>("EditorFont");
            fonts.Add("EditorFont", font);
        }

        public static SpriteFont GetFont(string name)
        {
            SpriteFont font;
            fonts.TryGetValue(name,out font);
            return font;
        }
    }
}
