using System.Dynamic;
using Raylib_cs;
using Vinterprojekt2023;
Raylib.InitWindow(1200, 800, "Vinterprojekt2023");
Raylib.SetTargetFPS(60);
Cube cube = new Cube();
Game game = new Game();

//Debug-kod
Console.WriteLine($"{game.gameState}");

//Spelkoden
//Först kollas det vilket gamestate som är aktuellt, alltså ifall spelet ska visa startskärm eller gameOverskärm osv.
//Ifall gameState är lika med 1 så ska spelet köras. Då sätts difficultyn och lite andra småvariabler. Sedan körs kubens och game-klassens update metoder.
//Sedan ritas spelet.
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