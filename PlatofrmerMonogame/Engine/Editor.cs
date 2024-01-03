using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using Newtonsoft.Json.Bson;

namespace Engine
{
    public class Editor
    {
        SceneManager sceneManager;

        List<Type> entitiesTypes;
        Type currentEntity;

        string currentScene;

        MouseState mouseState;
        Entity selectedEntity;

        public Editor(SceneManager _sceneManager)
        {
            sceneManager = _sceneManager;
            entitiesTypes = Configuration.GetEntitiesTypes();
            currentEntity = entitiesTypes.FirstOrDefault();
        }

        public void Update()
        {
            mouseState = Mouse.GetState();

            if (ImGui.GetIO().WantCaptureMouse)
            {
                return;
            };

            selectedEntity = GetEntityAtMousePosition();

            if (selectedEntity != null)
            {
                if (mouseState.RightButton == ButtonState.Pressed)
                {
                    sceneManager.GetCurrentScene().EntityManager.entities.Remove(selectedEntity);
                }

                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    selectedEntity.ToggleGuiShow();
                }
            } else
            {
                
                if (mouseState.LeftButton == ButtonState.Pressed && currentEntity != null)
                {
                    CreateEntityAtMousePosition();
                }
            }        
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (selectedEntity != null)
            {
                spriteBatch.DrawRectangle(selectedEntity.bounds, Color.White, 2);
                //spriteBatch.DrawString(AssetManager.GetFont("EditorFont"), "test", new Vector2(selectedEntity.bounds.X, selectedEntity.bounds.Y) , Color.AliceBlue);
            }
        }

        public void CreateEntityAtMousePosition()
        {
            var entity = Activator.CreateInstance(currentEntity) as Entity;
            var x = (int)mouseState.X - (int)mouseState.X % 16;
            var y = (int)mouseState.Y - (int)mouseState.Y % 16;
            entity.bounds = new Rectangle(x, y, 16, 16);
            sceneManager.GetCurrentScene().EntityManager.entities.Add(entity);
        }

        public Entity GetEntityAtMousePosition()
        {
            foreach (Entity entity in sceneManager.GetCurrentScene().EntityManager.entities)
            {
                if (entity.bounds.Contains(mouseState.X, mouseState.Y))
                {
                    return entity;
                }
            }
            return null;
        }

        public void Gui()
        {



            //ImGui.BeginMenuBar();
            //ImGui.SetWindowPos(new System.Numerics.Vector2(0,0), ImGuiCond.Always);
            var open = true;
            //
            ImGui.Begin("Menu", ref open, ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.MenuBar | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoScrollbar);

            ImGui.SetWindowPos(new System.Numerics.Vector2(0,0));
            //ImGui.SetWindowSize();

            if (ImGui.BeginMenuBar())
            {
                GuiUpdating();
                ImGui.EndMenuBar();
            }
            ImGui.End();

            ImGui.Begin("Editor");
           



            GuiEntities();
            GuiScenes();
            
            ImGui.End();

            foreach (Entity entity in sceneManager.GetCurrentScene().EntityManager.entities)
            {
                entity.Gui();
            }
        }

        void GuiEntities()
        {
            if (ImGui.BeginCombo("##entity_type_selection", currentEntity.Name))
            {
                foreach (var item in entitiesTypes)
                {
                    if (ImGui.Selectable(item.Name))
                    {
                        currentEntity = item;
                    }
                }
                ImGui.EndCombo();
            }

            ImGui.BeginChild("Entities");
            foreach (var entity in sceneManager.GetCurrentScene().EntityManager.entities)
            {
                ImGui.Text(entity.GetType().Name);
                if (ImGui.Button("Edit : " + entity.GetHashCode().ToString()))
                {
                    entity.ToggleGuiShow();
                } 
            }
            ImGui.EndChild();
        }

        void GuiUpdating()
        {
            if (ImGui.Button("Play"))
            {
                sceneManager.GetCurrentScene().EntityManager.isUpdating = true;
                sceneManager.SaveCurrentScene();
            }

            if (ImGui.Button("Stop"))
            {
                sceneManager.GetCurrentScene().EntityManager.isUpdating = false;
                sceneManager.LoadScene(currentScene);
            }
        }

        void GuiScenes()
        {
            Scene scene = sceneManager.GetCurrentScene();

            if (ImGui.BeginCombo("##scene_selection", currentScene))
            {
                foreach (var item in Configuration.GetScenesFiles())
                {
                    if (ImGui.Selectable(item))
                    {
                        currentScene = item;
                    }
                }
                ImGui.EndCombo();
            }

            ImGui.Text("Current scene : " + scene.Name);
            ImGui.InputText("##scene_name", ref scene.Name, 128);

            if (ImGui.Button("Load"))
            {
                sceneManager.LoadScene(currentScene);
            }

            if (ImGui.Button("Save"))
            {
                sceneManager.SaveCurrentScene();
            }
        }
    }
}
