using Raylib_cs;

Raylib.InitWindow(1200, 800, "Vinterprojekt2023");
Raylib.SetTargetFPS(60);

Cube cube = new Cube();
Game game = new Game();
List<Platform> platforms = new List<Platform>();
float timer = 1f;
float timerMax = 1f;
int removeCount = 0;
Random generator = new Random();


void ResetTimer()
{
    timer = timerMax;
}
void CheckTimer()
{
    timer -= Raylib.GetFrameTime();
    if (timer <= 0)
    {
        AddPlatform(platforms);
        ResetTimer();
    }
}
void AddPlatform(List<Platform> platforms)
{
    int y = generator.Next(400, 600);
    platforms.Add(new Platform(1200, y, 200, 20));
}

void Remove(List<Platform> platforms)
{

    if (platforms.RemoveAll(p => p.rect.X <= -200) == 1)
    {
        removeCount++;
    }
}

// AddPlatform(platforms);
while (Raylib.WindowShouldClose() == false)
{
    // cube.SetonGroundToFalse();
    cube.CheckPlatformCollision(platforms);
    cube.Update();
    CheckTimer();
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);
    foreach (Platform platform in platforms)
    {
        platform.Draw();
        platform.Update();
    }
    Remove(platforms);
    cube.Draw();

    Console.WriteLine($"{cube.onGround}");
    game.DrawHud(cube.velocity, cube.rect.Y, timer, platforms, removeCount);
    Raylib.EndDrawing();
}