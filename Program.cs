using Raylib_cs;

Raylib.InitWindow(1200, 800, "Vinterprojekt2023");
Raylib.SetTargetFPS(60);

Cube cube = new Cube();
Game game = new Game();
Platform plat = new Platform();

while (Raylib.WindowShouldClose() == false)
{


    cube.Update(plat.platform);

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);
    cube.Draw();
    plat.Draw();
    Console.WriteLine($"{cube.onGround}");

    Raylib.EndDrawing();
}