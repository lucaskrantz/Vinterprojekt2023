using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic.FileIO;
using Raylib_cs;
public class Cube
{
    public Rectangle rect = new Rectangle(575, 0, 50, 50);
    private int speed = 5;
    public int velocity = 2;
    public bool onGround = true;
    public void Draw()
    {
        Raylib.DrawRectangleRec(rect, Color.BLUE);
    }

    public void Move()
    {

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


    public void ApplyVelocity()
    {
        if (onGround)
        {
            velocity = 0;
        }
        else
        {
            velocity += 2;
        }
    }
    public void SetonGroundToFalse()
    {
        onGround = false;
    }

    public void CheckCollision()
    {
        // Kollar ifall kuben nuddar golvet
        if (rect.Y >= 750)
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
    }

    public void SetYPos(Platform platform)
    {
        rect.Y = platform.rect.Y - 49;
        onGround = true;
    }

    public void CheckPlatformCollision(List<Platform> platforms)
    {
        foreach (Platform platform in platforms)
        {
            if (Raylib.CheckCollisionRecs(rect, platform.rect))
            {
                onGround = true;
                velocity = 0;
                SetYPos(platform);
            }
        }
    }

    public void Update()
    {
        CheckCollision();
        Move();
        ApplyVelocity();

    }
}
