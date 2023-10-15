using System.Runtime.Versioning;
using Raylib_cs;

namespace HelloWorld;

static class Program
{
    static int Movement_Speed = 1;
    static Texture2D ghostSprite;
    
    public static void Main()
    {

        Raylib.InitWindow(1600, 960, "Hello Wo");
        GameObject Player = new GameObject();
        Player.AddComponent<SpriteRenderer>();
        ghostSprite = Raylib.LoadTexture("resources/BlueGhost.png");
        Player.GetComponent<SpriteRenderer>().Sprite = ghostSprite;
        Player.AddComponent<Rigidbody2D>();
        
        bool JumpAbility = true;
        Rigidbody2D rb = Player.GetComponent<Rigidbody2D>();
        ghostSprite = Raylib.LoadTexture("resources/BlueGhost.png");
        Console.WriteLine(ghostSprite);
        while (!Raylib.WindowShouldClose())
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_M))
            {
                rb.GravityFactor = 0.2f;

            }
            else
            {
                rb.GravityFactor = 0.5f;
            }
            Raylib.WaitTime(0.016);
           

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
            
            


            
           
            
            if(Player.transform.PosY > 400)
            {
                Player.transform.PosY = 400;
                rb.YVelocity = 0;
                JumpAbility = true;
                rb.XVelocity *= 0.7f;
            }
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.WHITE);
            Player.Tick();
            

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
