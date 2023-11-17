
using Raylib_cs;
public class Platform
{
    public Rectangle platform = new Rectangle(480, 500, 200, 20);

    public void Draw()
    {
        Raylib.DrawRectangleRec(platform, Color.BLUE);
    }
}
