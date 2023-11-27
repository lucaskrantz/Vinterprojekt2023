using System.Runtime.InteropServices;
using Raylib_cs;

public class Game
{
    public float timer = 1f;
    private float timerMax = 1f;
    Random generator = new Random();
    private void ResetTimer()
    {
        timer = timerMax;
    }
    public void CheckTimer(List<Platform> platforms)
    {
        timer -= Raylib.GetFrameTime();
        if (timer <= 0)
        {
            AddPlatform(platforms);
            ResetTimer();
        }
    }
    protected void AddPlatform(List<Platform> platforms)
    {
        int y = generator.Next(400, 600);
        platforms.Add(new Platform(1200, y, 200, 20));
    }
    public void DrawHud(int velocity, float y, float timer, List<Platform> platforms, int removeCount)
    {
        Raylib.DrawText($"{velocity}", 300, 300, 20, Color.BLACK);
        Raylib.DrawText($"{y}", 320, 320, 20, Color.BLACK);
        Raylib.DrawText($"{timer}", 340, 340, 20, Color.BLACK);
        Raylib.DrawText($"{platforms.Count}", 360, 360, 20, Color.BLACK);
        Raylib.DrawText($"{removeCount}", 380, 380, 20, Color.BLACK);

    }

}
