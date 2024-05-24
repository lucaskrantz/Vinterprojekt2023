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

    //Flyttar kuben berodne på input.
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

    //Lägger till velocity till kuben så att den faller när man hoppar.
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

    //Metod för att kolla collision mellan kuben och olika plattformar.
    public void CheckPlatformCollision(List<PlatformBase> platforms)
    {
        foreach (PlatformBase platformBase in platforms)
        {
            if (platformBase is Platform platform)
            {
                if (Raylib.CheckCollisionRecs(rect, platform.GetCollisionRect()))
                {
                    onGround = true;
                    velocity = 0;

                    // Anropa SetYPos med den konverterade Platform-instansen
                    SetYPos(platform);
                }
            }
            //Även fast MysteryPlatform är en typ av EvilPlatform, så appliceras bara MysteryPlatforms Debuff istället för båda plattformarnas debuff vid kollision.
            //Detta är för att MysteryPlatform kollas först, och ifall plattformen inte är en MysteryPlatform så är det en EvilPlatform, och då appliceras EvilPlatform.
            if (platformBase is MysteryPlatform mPlatform && Raylib.CheckCollisionRecs(rect, mPlatform.GetCollisionRect()))
            {
                //Debuff, slumpar kubens x värde
                rect.X = mPlatform.randomValue;
                rect.Y = 100;
            }
            else if (platformBase is EvilPlatform ePlatform && Raylib.CheckCollisionRecs(rect, ePlatform.GetCollisionRect()))
            {
                //Debuff, dödar kuben
                health -= ePlatform.removeHealth;
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

    public void Update(Game game, List<PlatformBase> platforms)
    {
        IsAlive(game);
        CheckCollision(game);
        CheckPlatformCollision(platforms);
        Move();
        ApplyVelocity();
    }
}
