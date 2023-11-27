
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;
public class Platform
{
    private float speed = -6;

    public Rectangle rect;
    public Platform(float x, float y, float width, float height)
    {
        rect = new Rectangle(x, y, width, height);
    }


    public void Draw()
    {
        Raylib.DrawRectangleRec(rect, Color.BLUE);
    }
    public void Update()
    {
        rect.X += speed;
    }

    

}
