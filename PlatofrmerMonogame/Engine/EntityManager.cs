using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class EntityManager
    {
        public List<Entity> entities { get; set; }

        [XmlIgnore]
        public bool isUpdating = false;

        public EntityManager()
        {
            entities = [];
        }

        public void ToggleIsUpdating()
        {
            isUpdating = !isUpdating;
        }

        public void Update()
        {
            if (!isUpdating)
            {
                return;
            }

            foreach (Entity entity in entities) {
                entity.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Entity entity in entities)
            {
                entity.Draw(spriteBatch);
                entity.EditorDraw(spriteBatch);
            }
        }
    }
}
