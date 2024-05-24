
using Raylib_cs;
public class Platform : PlatformBase
{
    protected float easySpeed = -6;
    protected float mediumSpeed = -9;
    protected float hardSpeed = -12;

    public Color color = Color.BLUE;
    protected Random generator = new Random();

    public Platform()
    {
        rect.Y = generator.Next(400, 600);
    }

    public override void Draw()
    {
        Raylib.DrawRectangleRec(rect, color);
    }
    public override float GetXPosition()
    {
        return rect.X; // Returnera X-koordinaten för plattformen
    }
    public override Rectangle GetCollisionRect()
    {
        return rect; // Returnera plattformens kollisionsrektangel
    }

    public override float GetYPosition()
    {
        return rect.Y; // Returnera plattformens Y-position
    }
    //En metod för att justera platformarnas hastighet beroende på vilken difficulty som är aktuell.
    public override void Update(Game.Difficulty difficulty)
    {
        if (difficulty == Game.Difficulty.Medium)
        {
            rect.X += mediumSpeed;
        }
        else if (difficulty == Game.Difficulty.Hard)
        {
            rect.X += hardSpeed;
        }
        else
        {
            rect.X += easySpeed;
        }
    }
}

