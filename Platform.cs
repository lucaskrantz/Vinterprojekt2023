
using Raylib_cs;
public class Platform
{

    public Rectangle Bounds { get; private set; }
    
    // public Rectangle platform = new Rectangle(x, y, 200, 20);


    public Platform(float x, float y, float width, float height)
    {
        Bounds = new Rectangle(x, y, width, height);
    }


    public void Draw(List<Platform> platforms)
    {
        foreach (Platform platform in platforms)
        {
            Raylib.DrawRectangleRec(platform.Bounds, Color.BLUE);

        }
    }


}
