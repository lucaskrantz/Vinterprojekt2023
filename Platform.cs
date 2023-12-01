
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;
public class Platform
{
    public float speed = -6;
    public Rectangle rect;
    public Platform(float x, float y, float width, float height)
    {
        rect = new Rectangle(x, y, width, height);
    }
    public void Draw()
    {
        Raylib.DrawRectangleRec(rect, Color.BLUE);
    }

    public float ReturnSpeed()
    {
        return speed;
    }
    // public void Update()
    // {
    //     rect.X += speed;
    // }

    public void Update(Game.Difficulty difficulty)
    {
        if (difficulty == Game.Difficulty.Medium)
        {
            speed = -9;
            rect.X += speed;
        }
        else if (difficulty == Game.Difficulty.Hard)
        {
            speed = -12;
            rect.X += speed;
        }
        else
        {
            rect.X += speed;
        }
    }
}
