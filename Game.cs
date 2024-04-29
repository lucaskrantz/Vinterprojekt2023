using System.Collections.Generic;
using Raylib_cs;
using Vinterprojekt2023;

public class Game
{
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    public Difficulty currentDifficulty = Difficulty.Easy;
    public List<PlatformBase> platforms = new List<PlatformBase>(); // Använder en generisk lista för plattformar

    private float timer = 0f;
    private float eTimer = 0f;
    private float mTimer = 0f;
    private float timerMax = 1f;
    private float eTimerMax = 4f;
    private float mTimerMax = 6f;
    private int removeCount = 0;
    public int gameState = 0;

    public void ChangeDifficulty()
    {
        if (removeCount >= 10 && removeCount < 20)
        {
            currentDifficulty = Difficulty.Medium;
            timerMax = 0.5f;
            Raylib.DrawText("Watch out for the red platforms!", 400, 200, 30, Color.BLACK);
        }
        else if (removeCount >= 30)
        {
            currentDifficulty = Difficulty.Hard;
        }
    }

    public void Update()
    {
        if (gameState == 1)
        {
            timer -= Raylib.GetFrameTime(); ;
            eTimer -= Raylib.GetFrameTime();
            mTimer -= Raylib.GetFrameTime();

            if (timer <= 0)
            {
                AddPlatform<Platform>();
                timer = timerMax;
            }

            if (eTimer <= 0 && currentDifficulty != Difficulty.Easy)
            {
                AddPlatform<EvilPlatform>(); // Lägg till EvilPlatform
                eTimer = eTimerMax;
            }

            if (mTimer <= 0 && currentDifficulty != Difficulty.Easy)
            {
                AddPlatform<MysteryPlatform>(); // Lägg till MysteryPlatform
                mTimer = mTimerMax;
            }

            // Uppdatera och rita ut alla plattformar
            for (int i = platforms.Count - 1; i >= 0; i--)
            {
                var platform = platforms[i];
                platform.Update(currentDifficulty);
                platform.Draw();

                if (platform.GetXPosition() <= -platform.rect.Width)
                {
                    platforms.Remove(platform);
                    removeCount++;
                }
            }

            // Ta bort plattformar som har passerat vänster kant
            // platforms.RemoveAll(p => p.rect.X <= -p.rect.Width);
        }
    }

    // Generisk metod för att lägga till en ny plattform i listan
    private void AddPlatform<T>() where T : PlatformBase, new()
    {
        platforms.Add(new T());
    }

    public void StartScreen()
    {
        // Startskärmen
        string StartInstru = "Tryck på vänsterklick för att spela!";
        string StartInstru2 = "Se upp för de röda och svarta plattofrmarna!";
        Raylib.DrawText(StartInstru, 400, 400, 20, Color.WHITE);
        Raylib.DrawText(StartInstru2, 440, 440, 20, Color.WHITE);
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            gameState = 1;
        }
    }

    public void GameOverScreen()
    {
        // Game Over-skärmen
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawText("You lost!", 400, 350, 50, Color.BLUE);
    }

    public void CheckGameState()
    {
        // Kontrollera spelets tillstånd (startskärm, spela, game over)
        if (gameState == 0)
        {
            StartScreen();
        }
        else if (gameState == 2)
        {
            GameOverScreen();
        }
    }

    public void Died()
    {
        // Metod som anropas när spelaren dör
        gameState = 2;
    }

    public void DrawHud(int velocity, float y, float timer)
    {
        // Rita ut HUD (heads-up display) med spelinformation
        Raylib.DrawText($"{velocity}", 300, 300, 20, Color.BLACK);
        Raylib.DrawText($"{y}", 320, 320, 20, Color.BLACK);
        Raylib.DrawText($"{timer}", 340, 340, 20, Color.BLACK);
        Raylib.DrawText($"{platforms.Count}", 360, 360, 20, Color.BLACK);
        Raylib.DrawText($"{removeCount}", 380, 380, 20, Color.BLACK);
    }
}
