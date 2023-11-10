
using Raylib_cs;
public class Platform
{
    public Rectangle rect = new Rectangle(480, 500, 200, 20);

    public void Draw()
    {
        Raylib.DrawRectangleRec(rect, Color.BLUE);
    }
}
