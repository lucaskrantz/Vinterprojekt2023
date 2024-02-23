using Raylib_cs;
namespace Vinterprojekt2023;

public class MysteryPlatform : EvilPlatform
{
    // new float speed = -14;
    // new public Color color = Color.BLACK;
    public int randomValue;


    public MysteryPlatform()
    {
        mediumSpeed = -14;
        color = Color.BLACK;
        rect.Y = generator.Next(300, 500);
        randomValue = generator.Next(0, 1200);
    }
}
