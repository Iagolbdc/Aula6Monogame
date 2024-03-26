using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player{
    private Texture2D[] _images;
    private int _index;
    private Vector2 _position;
    private const float SPEED = 200;
    private Timer _timer;

    public void LoadContent(ContentManager content){
        _images = new Texture2D[6]{
            content.Load<Texture2D>("helicopter/helicopter1"),content.Load<Texture2D>("helicopter/helicopter2"),
            content.Load<Texture2D>("helicopter/helicopter3"),content.Load<Texture2D>("helicopter/helicopter4"),
            content.Load<Texture2D>("helicopter/helicopter5"),content.Load<Texture2D>("helicopter/helicopter6"),
        };
    }

    public void Initialize(){
        _index = 0;
        _position = new Vector2(400, 200);
        _timer = new Timer();
        _timer.Start(IncrementIndex, 0.1f, true);
    }

    public Vector2 Update(float deltaTime)
    {
        Vector2 direction = Vector2.Zero;

        if(Input.GetKey(Keys.W)){
            direction.Y = -1.0f;
        }
        if(Input.GetKey(Keys.S)){
            direction.Y = 1.0f;
        }
        if(Input.GetKey(Keys.A)){
            direction.X = -1.0f;
        }
        if(Input.GetKey(Keys.D)){
            direction.X  = 1.0f;
        }

        Vector2 offset = Vector2.Zero;

        if(direction != Vector2.Zero){
            direction.Normalize();
            offset = direction * SPEED * deltaTime;

            //_position = _position + (direction * SPEED * deltaTime);
        }

        _timer.Update(deltaTime);

        return offset;

    }

    public void Draw(SpriteBatch spriteBatch){
        spriteBatch.Draw(_images[_index], _position ,Color.White);
    }

    private void IncrementIndex(){
        _index++;
        if(_index > 5){
            _index = 0;
        }
    }
}

// using Microsoft.Xna.Framework;
// using Microsoft.Xna.Framework.Content;
// using Microsoft.Xna.Framework.Graphics;
// using Microsoft.Xna.Framework.Input;

// public class Player{
//     private Texture2D[] _images;
//     private int _index;
//     private Rectangle _position;
//     private const float SPEED = 200;
//     private Timer _timer;

//     public void LoadContent(ContentManager content){
//         _images = new Texture2D[6]{
//             content.Load<Texture2D>("helicopter/helicopter1"),content.Load<Texture2D>("helicopter/helicopter2"),
//             content.Load<Texture2D>("helicopter/helicopter3"),content.Load<Texture2D>("helicopter/helicopter4"),
//             content.Load<Texture2D>("helicopter/helicopter5"),content.Load<Texture2D>("helicopter/helicopter6"),
//         };
//     }

//     public void Initialize(){
//         _index = 0;
//         _position = new Rectangle(400, 200, _images[0].Width, _images[0].Height);
//         _timer = new Timer();
//         _timer.Start(IncrementIndex, 0.1f, true);
//     }

//     public Vector2 Update(float deltaTime)
//     {
//         Vector2 direction = Vector2.Zero;

//         if(Input.GetKey(Keys.W)){
//             direction.Y = -1.0f;
//         }
//         if(Input.GetKey(Keys.S)){
//             direction.Y = 1.0f;
//         }
//         if(Input.GetKey(Keys.A)){
//             direction.X = -1.0f;
//         }
//         if(Input.GetKey(Keys.D)){
//             direction.X  = 1.0f;
//         }

//         Vector2 offset = Vector2.Zero;

//         if(direction != Vector2.Zero){
//             direction.Normalize();
//             offset = direction * SPEED * deltaTime;

//             //_position = _position + (direction * SPEED * deltaTime);

//             // _position.X += (int)offset.X;
//             // _position.Y += (int)offset.Y;
//         }

//         _timer.Update(deltaTime);

//         return offset;

//     }

//     public void Draw(SpriteBatch spriteBatch){
//         spriteBatch.Draw(_images[_index], _position ,Color.White);
//     }

//     private void IncrementIndex(){
//         _index++;
//         if(_index > 5){
//             _index = 0;
//         }
//     }
// }