using System.Runtime.InteropServices;
using Raylib_cs;

public class Game
{
    public int windowHeight = 800;


    public void DrawHud(int velocity, float y, float timer, List<Platform> platforms, int removeCount)
    {
        Raylib.DrawText($"{velocity}", 300, 300, 20, Color.BLACK);
        Raylib.DrawText($"{y}", 320, 320, 20, Color.BLACK);
        Raylib.DrawText($"{timer}", 340, 340, 20, Color.BLACK);
        Raylib.DrawText($"{platforms.Count}", 360, 360, 20, Color.BLACK);
        Raylib.DrawText($"{removeCount}", 380, 380, 20, Color.BLACK);

    }
    
}
