using System;
using System.Xml.Serialization;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Engine
{
    [XmlInclude(typeof(Test))]
    [XmlInclude(typeof(Player))]
    [Serializable]
    public class Entity
    {
        public Rectangle bounds;
        public bool guiShow = false;

        public Entity() { }

        public Entity(Rectangle _bounds)
        {
            bounds = _bounds;
        }

        public virtual void Update(){}
        public virtual void Draw(SpriteBatch spriteBatch) {}

        public virtual void EditorDraw(SpriteBatch spriteBatch)
        {
            Color green = Color.Green;
            green.A = 125;
            spriteBatch.FillRectangle(bounds, green);
        }

        public void ToggleGuiShow()
        {
            guiShow = !guiShow;
        }

        public virtual void Gui()
        {
            if (!guiShow)
                return;

            ImGui.Begin(this.GetHashCode().ToString(), ref guiShow);
                ImGui.InputInt("X", ref bounds.X, 0, 100);
                ImGui.InputInt("Y", ref bounds.Y, 0, 100);
                ImGui.InputInt("WIDTH", ref bounds.Width, 0, 100);
                ImGui.InputInt("HEIGHT", ref bounds.Height, 0, 100);
            ImGui.End();
        }
    }
}
