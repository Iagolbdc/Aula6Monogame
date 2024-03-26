using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Aula6;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Color _bgColor;
    private Timer _timer;
    private Player _player;
    private Vector2 _scenePosition;
    private Texture2D _background;

    private void ChangeBG(){
        if(_bgColor == Color.LightBlue){
            _bgColor = Color.DarkBlue;
        }else{
            _bgColor = Color.LightBlue;
        }
    }

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();

        _bgColor = Color.LightBlue;
        
        _timer = new Timer();
        _timer.Start(ChangeBG, 2, true);

        Globals.SCREEN_WIDTH = _graphics.PreferredBackBufferWidth;
        Globals.SCREEN_HEIGHT = _graphics.PreferredBackBufferHeight;

        _player.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _background = Content.Load<Texture2D>("background2");
        
        _player = new Player();

        _player.LoadContent(Content);  
        
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        _timer.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        Vector2 playerOffset = _player.Update(deltaTime);
        Camera.Update(playerOffset, ref _scenePosition);
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(_bgColor);

        _spriteBatch.Begin();

        _spriteBatch.Draw(_background, -_scenePosition,Color.White);

        _player.Draw(_spriteBatch);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
