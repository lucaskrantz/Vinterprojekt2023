using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic.FileIO;
using Raylib_cs;
using Vinterprojekt2023;
public class Cube
{
    public Rectangle rect = new Rectangle(1100, 0, 50, 50);
    private int speed = 5;
    public int velocity = 2;
    public bool onGround = true;
    private int health = 1;
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

    public void CheckCollision(Game game)
    {
        // Kollar ifall kuben nuddar golvet
        if (rect.Y >= 750)
        {
            // rect.Y = 750;
            // onGround = true;
            game.Died();
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

    // Sätter kubens Y-värde till platformens y-värde minus 49.
    public void SetYPos(Platform platform)
    {
        rect.Y = platform.rect.Y - 49;
        onGround = true;
    }

    public void CheckPlatformCollision(List<Platform> platforms, List<EvilPlatform> ePlatforms, List<MysteryPlatform> mPlatforms)
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
        foreach (EvilPlatform ePlatform in ePlatforms)
        {
            if (Raylib.CheckCollisionRecs(rect, ePlatform.rect))
            {
                health -= ePlatform.removeHealth;
            }
        }
        foreach (MysteryPlatform mPlatform in mPlatforms)
        {
            if (Raylib.CheckCollisionRecs(rect, mPlatform.rect))
            {
                rect.X = mPlatform.randomValue;
                rect.Y = 0;
            }
        }
    }

    public void IsAlive(Game game)
    {
        if (health <= 0)
        {
            game.Died();
        }
    }

    public void Update(Game game, List<Platform> platforms, List<EvilPlatform> ePlatforms, List<MysteryPlatform> mPlatforms)
    {
        IsAlive(game);
        CheckCollision(game);
        CheckPlatformCollision(platforms, ePlatforms, mPlatforms);
        Move();
        ApplyVelocity();

    }
}
    