﻿using System.Runtime.InteropServices;
using Raylib_cs;
public class Game
{


    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    public Difficulty currentDifficulty = Difficulty.Easy;


    public float timer = 0f;
    private float timerMax = 1f;
    public int removeCount = 0;

    public int gameState = 0;
    Random generator = new Random();

    public void ChangeDifficulty()
    {
        if (removeCount >= 10 && removeCount < 20)
        {
            currentDifficulty = Difficulty.Medium;
            timerMax = 0.5f;
        }
        else if (removeCount >= 20)
        {
            currentDifficulty = Difficulty.Hard;
            

        }
    }
    private void ResetTimer()
    {
        timer = timerMax;
    }
    public void CheckTimer(List<Platform> platforms)
    {
        timer -= Raylib.GetFrameTime();
        if (timer <= 0)
        {
            AddPlatform(platforms);
            ResetTimer();
        }
    }
    public void Remove(List<Platform> platforms)
    {
        if (platforms.RemoveAll(p => p.rect.X <= -200) == 1)
        {
            removeCount++;
        }
    }
    protected void AddPlatform(List<Platform> platforms)
    {
        int y = generator.Next(400, 600);
        platforms.Add(new Platform(1200, y, 200, 20));
    }
    public void AddFirstPlatform(List<Platform> platforms)
    {
        platforms.Add(new Platform(400, 400, 800, 20));
    }
    public void StartScreen()
    {
        Raylib.DrawText("Press LMB to start", 400, 350, 50, Color.BLUE);
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
    public void DrawHud(int velocity, float y, float timer, List<Platform> platforms)
    {
        Raylib.DrawText($"{velocity}", 300, 300, 20, Color.BLACK);
        Raylib.DrawText($"{y}", 320, 320, 20, Color.BLACK);
        Raylib.DrawText($"{timer}", 340, 340, 20, Color.BLACK);
        Raylib.DrawText($"{platforms.Count}", 360, 360, 20, Color.BLACK);
        Raylib.DrawText($"{removeCount}", 380, 380, 20, Color.BLACK);
    }
}
