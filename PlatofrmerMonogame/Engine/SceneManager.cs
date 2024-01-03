using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;

using System.Xml.Serialization;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Xml;

namespace Engine
{
    public class SceneManager
    {
        Scene currentScene;

        public SceneManager() {

            currentScene = new Scene("default");
        }

        public Scene GetCurrentScene()
        {
            return currentScene;
        }

        public void Update()
        {
            if (currentScene != null)
            {
                currentScene.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (currentScene != null)
            {
                currentScene.Draw(spriteBatch);
            }
        }

        public void SaveCurrentScene()
        {
            string path = Configuration.ScenesPath + currentScene.Name + ".xml";

            XmlSerializer x = new XmlSerializer(currentScene.GetType());

            using (FileStream fs = File.Create(path))
            {
                x.Serialize(fs, currentScene);
            }
        }

        public void LoadScene(string sceneName)
        {
            string path = Configuration.ScenesPath + sceneName + ".xml";

            if (!File.Exists(path)) {
                return;
            }

            XmlSerializer x = new XmlSerializer(currentScene.GetType());

            using (Stream fs = new FileStream(path, FileMode.Open))
            {
                currentScene = (Scene)x.Deserialize(fs);
            }

        }
    }
}
