using Raylib_cs;

Raylib.InitWindow(1200, 800, "Vinterprojekt2023");
Raylib.SetTargetFPS(60);

Cube cube = new Cube();
Game game = new Game();
List<Platform> platforms = new List<Platform>();

int removeCount = 0;


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
    cube.SetonGroundToFalse();
    cube.CheckPlatformCollision(platforms);
    cube.Update();
    game.CheckTimer(platforms);
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
    game.DrawHud(cube.velocity, cube.rect.Y, game.timer, platforms, removeCount);
    Raylib.EndDrawing();
}