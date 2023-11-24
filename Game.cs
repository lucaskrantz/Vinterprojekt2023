using System.Runtime.InteropServices;
using Raylib_cs;

public class Game
{
    public int windowHeight = 800;


    public void DrawHud(int velocity, float y)
    {
        Raylib.DrawText($"{velocity}", 300, 300, 20, Color.BLACK);
        Raylib.DrawText($"{y}", 320, 320, 20, Color.BLACK);
    }
    public void CheckCollision(Rectangle rect, ref bool onGround, ref int velocity, List<Platform> platforms)
    {
        foreach (Platform platform in platforms)
        {
            if (Raylib.CheckCollisionRecs(rect, platform.Bounds))
            {
                // onGround ska bara vara true ifall kuben är över platformarna
                // if (rect.Y + rect.Height <= platform.Bounds.Y)
                // {
                onGround = true;
                velocity = 0;
                // }
            }
        }
    }
}
