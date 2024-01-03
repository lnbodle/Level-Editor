using System.Diagnostics;
using Engine;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.ImGuiNet;

namespace PlatofrmerMonogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static ImGuiRenderer GuiRenderer;
        public Editor editor;
        public SceneManager sceneManager;

        public Game1()
        {
            Configuration.Init();
            

            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;

            Content.RootDirectory = "Content";
            
            
            IsMouseVisible = true;

            sceneManager = new SceneManager();

            editor = new Editor(sceneManager);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            GuiRenderer = new ImGuiRenderer(this);

         


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            GuiRenderer.RebuildFontAtlas();
            // TODO: use this.Content to load your game content here

            AssetManager.Load(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            sceneManager.Update();
            editor.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);

            _spriteBatch.Begin();
            sceneManager.Draw(_spriteBatch);
            editor.Draw(_spriteBatch);
            _spriteBatch.End();

            GuiRenderer.BeginLayout(gameTime);
            editor.Gui();
            GuiRenderer.EndLayout();
        }
    }
}
