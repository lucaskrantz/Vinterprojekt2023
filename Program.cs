using System.Dynamic;
using Raylib_cs;
using Vinterprojekt2023;
Raylib.InitWindow(1200, 800, "Vinterprojekt2023");
Raylib.SetTargetFPS(60);
Cube cube = new Cube();
Game game = new Game();
List<Platform> platforms = new List<Platform>();
List<EvilPlatform> ePlatforms = new List<EvilPlatform>();
List<MysteryPlatform> mPlatforms = new List<MysteryPlatform>();

Console.WriteLine($"{game.gameState}");
while (Raylib.WindowShouldClose() == false)
{
    game.CheckGameState();
    if (game.gameState == 1)
    {
        game.ChangeDifficulty();
        cube.SetonGroundToFalse();
        cube.Update(game, platforms, ePlatforms, mPlatforms);
        game.CheckTimer(platforms, ePlatforms, mPlatforms);
        game.Remove(platforms);
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);
        // game.ChangeDifficulty(easy, medium, hard, game);
        foreach (Platform platform in platforms)
        {
            platform.Update(game.currentDifficulty);
            platform.Draw();
            // Console.WriteLine($"platform speed:{platform.ReturnSpeed()}");
        }

        foreach (EvilPlatform ePlatform in ePlatforms)
        {
            ePlatform.Draw();
            ePlatform.Update(game.currentDifficulty);
            // Console.WriteLine($"ePlatform speed:{ePlatform.ReturnSpeed()}");

        }
        foreach (MysteryPlatform mPlatform in mPlatforms)
        {
            mPlatform.Draw();
            mPlatform.Update(game.currentDifficulty);
            // Console.WriteLine($"ePlatform speed:{ePlatform.ReturnSpeed()}");

        }
        cube.Draw();
        Console.WriteLine($"{cube.onGround}");
        // game.DrawHud(cube.velocity, cube.rect.Y, game.timer, platforms, game.eTimer);
    }
    Raylib.EndDrawing();
}