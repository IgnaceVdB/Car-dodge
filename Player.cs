using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
    public class Sanic : Support.Texture
    {
        public Sanic(Vector2 position) : base("sanic", position, new Vector2(0.4f))
        {
        }

        public void Update(GameTime gameTime)
        {
            Vector2 previousPos = Position;
            if (Keyboard.GetState().IsKeyDown(Keys.Right) ) Position.X = 0.7f;
            if (Keyboard.GetState().IsKeyDown(Keys.Left) ) Position.X = -0.7f;
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) Position.X = 0.0f;



            var status = Support.Camera.GetCollision(this);
            if (status != Support.CollisionStatus.Inside)
            {
                Position = previousPos;
            }
        }
    }
}
