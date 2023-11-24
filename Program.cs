using Raylib_cs;

Raylib.InitWindow(1200, 800, "Vinterprojekt2023");
Raylib.SetTargetFPS(60);

Cube cube = new Cube();
Game game = new Game();
List<Platform> platforms = new List<Platform>();
float Timer = 3f;
float TimerMax = 3f;
void ResetTimer() // Startar om rock-timern
{
    Timer = TimerMax;
}
void AddPlatform(List<Platform> platforms)
{
    platforms.Add(new Platform(600, 600, 200, 20));
}
AddPlatform(platforms);
while (Raylib.WindowShouldClose() == false)
{

    cube.SetonGroundToFalse();
    game.CheckCollision(cube.rect, ref cube.onGround, ref cube.velocity, platforms);
    cube.Update();
    Timer -= Raylib.GetFrameTime();


    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);
    foreach (Platform platform in platforms)
    {
        platform.Draw(platforms);
    }
    cube.Draw();
    Console.WriteLine($"{cube.onGround}");
    game.DrawHud(cube.velocity, cube.rect.Y);

    Raylib.EndDrawing();
}