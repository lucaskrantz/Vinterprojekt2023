using Raylib_cs;
public class Raindrop : GameObject
{
    protected float easySpeed = -4;
    protected float mediumSpeed = -8;
    protected float hardSpeed = -12;

    public Color color = Color.GREEN;
    protected Random generator = new Random();

    public Raindrop()
    {
        rect.X = generator.Next(0, 1200);
    }
    public override void Draw()
    {
        Raylib.DrawRectangleRec(rect, color);
    }
    public override float GetXPosition()
    {
        return rect.X; // Returnera X-koordinaten för regndroppen
    }
    public override Rectangle GetCollisionRect()
    {
        return rect; // Returnera regndroppens kollisionsrektangel
    }
    public override float GetYPosition()
    {
        return rect.Y; // Returnera regndroppens Y-position
    }
    //En metod för att justera regndropparnas hastighet beroende på vilken difficulty som är aktuell.
    public override void Update(Game.Difficulty difficulty)
    {
        if (difficulty == Game.Difficulty.Medium)
        {
            rect.Y -= mediumSpeed;
        }
        else if (difficulty == Game.Difficulty.Hard)
        {
            rect.Y -= hardSpeed;
        }
        else
        {
            rect.Y -= easySpeed;
        }
    }
}
