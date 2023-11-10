using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic.FileIO;
using Raylib_cs;
public class Cube
{
    public Rectangle rect = new Rectangle(500, 500, 50, 50);
    private int speed = 0;

    public int originalVelocity = 5;
    public int currentVelocity = 0;



    public void StopFalling(int windowHeight)
    {
        if (rect.Y + 50 >= windowHeight)
        {
            currentVelocity = 0;
        }
        else
        {
            currentVelocity = originalVelocity;
        }
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(rect, Color.BLUE);
    }

    public void Update()
    {
        rect.X += speed;

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            currentVelocity = 400;
            rect.Y -= currentVelocity;
            currentVelocity++;
        }
        else
        {

            rect.Y += currentVelocity;
        }
    }
}
