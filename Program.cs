using System.Dynamic;
using Raylib_cs;
using Vinterprojekt2023;
Raylib.InitWindow(1200, 800, "Vinterprojekt2023");
Raylib.SetTargetFPS(60);
Cube cube = new Cube();
Game game = new Game();
// List<Platform> platforms = new List<Platform>();
// List<EvilPlatform> ePlatforms = new List<EvilPlatform>();
// List<MysteryPlatform> mPlatforms = new List<MysteryPlatform>();

Console.WriteLine($"{game.gameState}");
while (Raylib.WindowShouldClose() == false)
{
    game.CheckGameState();
    if (game.gameState == 1)
    {
        game.ChangeDifficulty();
        cube.SetonGroundToFalse();
        cube.Update(game, game.platforms);
        game.Update();
        // game.Remove(platforms);
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawText($"{game.removeCount}", 100, 100, 20, Color.RED);

        cube.Draw();
        Console.WriteLine($"{cube.onGround}");
        // game.DrawHud(cube.velocity, cube.rect.Y, game.timer, platforms, game.eTimer);
    }
    Raylib.EndDrawing();
}