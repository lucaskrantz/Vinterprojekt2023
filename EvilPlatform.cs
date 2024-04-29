using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;
namespace Vinterprojekt2023;



public class EvilPlatform : Platform
{
    // new readonly float speed = -24;
    // new public Color color = Color.RED;
    public readonly int removeHealth = 1;

    public EvilPlatform()
    {
        color = Color.RED;
        mediumSpeed = -24;
        hardSpeed = -30;
        rect.Y = generator.Next(300, 500);
    }


}
