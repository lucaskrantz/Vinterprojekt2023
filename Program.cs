using System.Dynamic;
using Raylib_cs;

Raylib.InitWindow(1200, 800, "Vinterprojekt2023");
Raylib.SetTargetFPS(60);

Cube cube = new Cube();
Game game = new Game();
List<Platform> platforms = new List<Platform>();
game.AddFirstPlatform(platforms);
Console.WriteLine($"{game.gameState}");

while (Raylib.WindowShouldClose() == false)
{
    Raylib.BeginDrawing();
    game.CheckGameState();
    if (game.gameState == 1)
    {
        cube.SetonGroundToFalse();
        cube.CheckPlatformCollision(platforms);
        cube.Update(game);
        game.CheckTimer(platforms);
        game.Remove(platforms);
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);
        foreach (Platform platform in platforms)
        {
            platform.Draw();
            platform.Update();
        }
        cube.Draw();

        Console.WriteLine($"{cube.onGround}");
        game.DrawHud(cube.velocity, cube.rect.Y, game.timer, platforms);
    }
    Raylib.EndDrawing();
}