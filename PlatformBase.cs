using Raylib_cs;
public abstract class PlatformBase
{
    public abstract void Update(Game.Difficulty difficulty);
    public abstract void Draw();
    public abstract float GetXPosition(); // Abstrakt metod för att hämta X-koordinaten
    // Abstrakt metod för att hämta kollisionsrektangeln för plattformen
    public abstract Rectangle GetCollisionRect();

    // Abstrakt metod för att hämta Y-positionen för plattformen
    public abstract float GetYPosition();
    public Rectangle rect = new Rectangle(1200, 500, 200, 20);


}


