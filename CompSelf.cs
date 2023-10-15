using Raylib_cs;
public class PlayerControls : Component
{
    public bool JumpAbility = true;
    Rigidbody2D rb;
    float Movement_Speed = 1f;
    public override void Tick()
    {
        JumpAbility = true;
            
            rb = gameObject.GetComponent<Rigidbody2D>();
            if (Raylib.IsKeyDown(KeyboardKey.KEY_M))
            {
                rb.GravityFactor = 0.2f;

            }
            else
            {
                rb.GravityFactor = 0.5f;
            }
           

            if (Raylib.IsKeyDown(KeyboardKey.KEY_M)&& JumpAbility	)
            {
                rb.YVelocity = 10;
                JumpAbility = false;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            rb.XVelocity-= Movement_Speed;
            else

            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            rb.XVelocity+= Movement_Speed;
            
            


            
           
            
            
    }
}