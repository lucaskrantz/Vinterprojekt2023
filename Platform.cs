
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;
public class Platform
{
    protected float speed = -6;
    public Color color = Color.BLUE;
    public Rectangle rect = new Rectangle(1200, 500, 200, 20);
    protected Random generator = new Random();
    public Platform()
    {
        rect.Y = generator.Next(400, 600);
    }
    public void Draw()
    {
        Raylib.DrawRectangleRec(rect, color);
    }

    public float ReturnSpeed()
    {
        return speed;
    }
    
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
