using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic.FileIO;
using Raylib_cs;
public class Cube
{
    public Rectangle rect = new Rectangle(500, 750, 50, 50);
    private int speed = 5;
    public int velocity = 2;
    public bool onGround = true;
    public void Draw()
    {
        Raylib.DrawRectangleRec(rect, Color.BLUE);
    }

    public void Move()
    {
        velocity += 2;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            rect.X += speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            rect.X -= speed;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && onGround)
        {
            velocity = -30;
            onGround = false;
        }

        rect.Y += velocity;
    }

    public void CheckCollision(Rectangle platform)
    {
        // Kollar ifall kuben nuddar golvet
        if (rect.Y + 50 >= 800)
        {
            rect.Y = 750;
            onGround = true;
        }
        // Kollar ifall kuben nuddar höger vägg
        if (rect.X + 50 >= 1200)
        {
            rect.X = 1150;
        }
        // Kollar ifall kuben nuddar vänster vägg
        if (rect.X <= 0)
        {
            rect.X = 0;
        }
        if (Raylib.CheckCollisionRecs(rect, platform))
        {
            onGround = true;
            velocity = 0;
        }
    }

    public void Update(Rectangle platform)
    {

        CheckCollision(platform);
        Move();
    }
}
