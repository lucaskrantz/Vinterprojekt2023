using System.Runtime.InteropServices;
using Raylib_cs;
using Vinterprojekt2023;
public class Game
{
    // En enum för olika svårigheter

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    // Spelets svårighet börjar på easy.
    public Difficulty currentDifficulty = Difficulty.Easy;


    public float timer = 0f;
    public float eTimer = 0f;
    public float mTimer = 0f;
    private float timerMax = 1f;  // Timer för när plattformar ska spawnas
    private float eTimerMax = 4f; // Timer för när onda plattformar ska spawnas
    private float mTimerMax = 6f; // Timer för när onda plattformar ska spawnas

    public int removeCount = 0; // Variabel för antal borttagna plattformar

    public int gameState = 0;

    public void ChangeDifficulty()
    {
        if (removeCount >= 10 && removeCount < 20)
        {
            currentDifficulty = Difficulty.Medium;
            timerMax = 0.5f;
            // ResetMysteryTimer();
            Raylib.DrawText("Watch out for the red platforms!", 400, 200, 30, Color.BLACK);

        }
        else if (removeCount >= 30)
        {
            currentDifficulty = Difficulty.Hard;
        }
    }
    private void ResetTimer()
    {
        timer = timerMax;
    }
    private void ResetEvilTimer()
    {
        eTimer = eTimerMax;
    }
    private void ResetMysteryTimer()
    {
        mTimer = mTimerMax;
    }

    //Metod för spawning av plattformar
    public void CheckTimer(List<Platform> platforms, List<EvilPlatform> ePlatforms, List<MysteryPlatform> mPlatforms)
    {
        timer -= Raylib.GetFrameTime();
        eTimer -= Raylib.GetFrameTime();
        mTimer -= Raylib.GetFrameTime();
        if (timer <= 0)
        {
            AddPlatform(platforms);
            ResetTimer();
        }
        if (eTimer <= 0 && currentDifficulty != Difficulty.Easy)
        {
            AddEvilPlatform(ePlatforms);
            ResetEvilTimer();
        }
        if (mTimer <= 0 && currentDifficulty != Difficulty.Easy)
        {
            AddMysteryPlatform(mPlatforms);
            ResetMysteryTimer();
        }
    }

    //Metod som sköter borttagning av plattformar när de har passerat vänster kant av spelets fönster.
    public void Remove(List<Platform> platforms)
    {
        if (platforms.RemoveAll(p => p.rect.X <= -p.rect.Width) == 1)
        {
            removeCount++;
        }
    }
    protected void AddPlatform(List<Platform> platforms)
    {
        platforms.Add(new Platform());
    }
    protected void AddEvilPlatform(List<EvilPlatform> ePlatforms)
    {
        ePlatforms.Add(new EvilPlatform());
    }
    protected void AddMysteryPlatform(List<MysteryPlatform> mPlatforms)
    {
        mPlatforms.Add(new MysteryPlatform());
    }


    //Ifall vänster musknapp trycks ned ska spelet köras.
    public void StartScreen()
    {
        Raylib.DrawText("Use A and D to move left or right.", 100, 200, 50, Color.BLUE);
        Raylib.DrawText("Use SPACEBAR to jump", 100, 250, 50, Color.BLUE);
        Raylib.DrawText("Press LMB to start", 100, 300, 50, Color.BLUE);
        Raylib.DrawText("Beware of the deadly red platforms!", 100, 350, 50, Color.BLUE);
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            gameState = 1;
        }

    }
    public void GameOverScreen()
    {
        Raylib.ClearBackground(Color.WHITE);
        Raylib.DrawText("You lost!", 400, 350, 50, Color.BLUE);
    }
    public void CheckGameState()
    {
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
        gameState = 2;
    }
    public void DrawHud(int velocity, float y, float timer, List<Platform> platforms, float eTimer)
    {
        Raylib.DrawText($"{velocity}", 300, 300, 20, Color.BLACK);
        Raylib.DrawText($"{y}", 320, 320, 20, Color.BLACK);
        Raylib.DrawText($"{timer}", 340, 340, 20, Color.BLACK);
        Raylib.DrawText($"{eTimer}", 400, 400, 20, Color.BLACK);
        Raylib.DrawText($"{platforms.Count}", 360, 360, 20, Color.BLACK);
        Raylib.DrawText($"{removeCount}", 380, 380, 20, Color.BLACK);
    }
}
