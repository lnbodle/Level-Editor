using System;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    [Serializable]
    public class Scene
    {
        public EntityManager EntityManager { get; set; }
        public string Name;

        public Scene() {
            EntityManager = new EntityManager();
        }
        public Scene(string _name)
        {
            EntityManager = new EntityManager();
            Name = _name;
        }

        public void Update()
        {
            EntityManager.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            EntityManager.Draw(spriteBatch);
        }
    }
}
