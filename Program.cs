using Raylib_cs;

Raylib.InitWindow(1200, 800, "Vinterprojekt2023");
Raylib.SetTargetFPS(60);

Cube cube = new Cube();
Game game = new Game();
List<Platform> platforms = new List<Platform>();

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
    game.Remove(platforms);
    cube.Draw();

    Console.WriteLine($"{cube.onGround}");
    game.DrawHud(cube.velocity, cube.rect.Y, game.timer, platforms);
    Raylib.EndDrawing();
}