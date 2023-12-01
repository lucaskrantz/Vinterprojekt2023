using System.Dynamic;
using Raylib_cs;
Raylib.InitWindow(1200, 800, "Vinterprojekt2023");
Raylib.SetTargetFPS(60);
Cube cube = new Cube();
Game game = new Game();
List<Platform> platforms = new List<Platform>();
// platform.AddFirstPlatform(platforms);
Console.WriteLine($"{game.gameState}");
while (Raylib.WindowShouldClose() == false)
{
    game.CheckGameState();
    if (game.gameState == 1)
    {
        game.ChangeDifficulty();
        cube.SetonGroundToFalse();
        cube.CheckPlatformCollision(platforms);
        cube.Update(game);
        game.CheckTimer(platforms);
        game.Remove(platforms);
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);
        // game.ChangeDifficulty(easy, medium, hard, game);
        foreach (Platform platform in platforms)
        {
            platform.Update(game.currentDifficulty);
            platform.Draw();
            Console.WriteLine($"{platform.ReturnSpeed()}");
        }
        cube.Draw();
        Console.WriteLine($"{cube.onGround}");
        game.DrawHud(cube.velocity, cube.rect.Y, game.timer, platforms);
    }
    Raylib.EndDrawing();
}