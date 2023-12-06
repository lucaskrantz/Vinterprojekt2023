using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;
namespace Vinterprojekt2023;



public class EvilPlatform : Platform
{
    new float speed = -24;
    new public Color color = Color.RED;
    public readonly int removeHealth = 1;

    public EvilPlatform()
    {
        rect.Y = generator.Next(300, 500);
    }

    public void Update()
    {
        rect.X += speed;
    }
    new public void Draw()
    {
        Raylib.DrawRectangleRec(rect, color);
    }
}
