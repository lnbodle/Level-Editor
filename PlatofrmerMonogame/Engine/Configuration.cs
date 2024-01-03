using System;
using System.Collections.Generic;
using System.IO;

namespace Engine
{
    public static class Configuration
    {
        public static string ScenesPath;
        public static string EntitiesPath;
        public static string Namespace;

        public static void Init()
        {
            ScenesPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Content/Scenes/";
            EntitiesPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Entities/";
            Namespace = "Engine.";
        }

        public static List<string> GetScenesFiles()
        {
            List<string> files = [];
            foreach (string fileName in Directory.GetFiles(ScenesPath))
            {
                files.Add(Path.GetFileNameWithoutExtension(fileName));
            }
            return files;
        }

        public static List<Type> GetEntitiesTypes()
        {
            List<Type> entitiesTypes = [];
            foreach (string fileName in Directory.GetFiles(EntitiesPath))
            {
                Type t = Type.GetType(Namespace + Path.GetFileNameWithoutExtension(fileName));
                if (t != null)
                {
                    entitiesTypes.Add(t);
                }
            }
            return entitiesTypes;
        }
    }
}
