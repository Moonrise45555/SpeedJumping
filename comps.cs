using Raylib_cs;

public class Rigidbody2D : Component
{
    public Rigidbody2D() 
    {
        
    }

    public override void Tick()
    {
        if (XVelocity > maxSpeed)
            {
                XVelocity = maxSpeed;
            }
            if (XVelocity < -maxSpeed)
            {
                XVelocity = -maxSpeed;
            }
        gameObject.transform.PosY = (int)MathF.Round(gameObject.transform.PosY - YVelocity);
        gameObject.transform.PosX = (int)MathF.Round(gameObject.transform.PosX - XVelocity);
        YVelocity -= GravityFactor;
        XVelocity *= 0.999f;
    }
    public float YVelocity = 0;
    public float XVelocity = 0;
    public float GravityFactor = 0.5f;
    public float maxSpeed = 10f;
}
public class Transform : Component
{
    public override void Tick()
    {
    }
    public Transform()  
    {

    }

    public int PosY = 100;
    public int PosX = 100;
}
public class SpriteRenderer : Component
{
    public override void Tick()
    {
        Raylib.DrawTexture(Sprite,gameObject.transform.PosX,gameObject.transform.PosY,Color.WHITE);
    }
    public Texture2D Sprite;
    public SpriteRenderer() 
    {

    }
}