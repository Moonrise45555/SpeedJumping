using System.Reflection.Emit;
using System.Runtime.Versioning;
using Raylib_cs;

namespace HelloWorld;

static class Program
{
    public static void DrawHitbox(GameObject g)
    {
        Hitbox h = g.GetComponent<Hitbox>();
        Raylib.DrawRectangle(Convert.ToInt16(g.GetComponent<Hitbox>().AbsoluteTopLeft.X)
        ,Convert.ToInt16(h.AbsoluteTopLeft.Y),
        Convert.ToInt16(MathF.Abs(Convert.ToInt16(h.AbsoluteTopLeft.X) - Convert.ToInt16(h.AbsoluteBottomRight.X))),
         Convert.ToInt16(MathF.Abs(h.AbsoluteTopLeft.Y - h.AbsoluteBottomRight.Y)),
         Color.BLACK);
    }
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
        Player.AddComponent<PlayerControls>();
        Player.AddComponent<Hitbox>();
        Player.GetComponent<Hitbox>().TopLeft = new System.Numerics.Vector2(0,10);
        Player.GetComponent<Hitbox>().BottomRight = new System.Numerics.Vector2(100,120);

        GameObject Floor = new GameObject();
        Floor.transform.PosX = 0;
        Floor.transform.PosY = 600;
        Floor.AddComponent<Hitbox>();
        Floor.GetComponent<Hitbox>().TopLeft = new System.Numerics.Vector2(0,0);
        Floor.GetComponent<Hitbox>().BottomRight = new System.Numerics.Vector2(3000,100);
        Console.WriteLine(Floor.GetComponent<Hitbox>().AbsoluteBottomRight);
        Console.WriteLine(Floor.GetComponent<Hitbox>().AbsoluteTopLeft);

        GameObject Floor2 = new GameObject();
        Floor2.transform.PosX = 600;
        Floor2.transform.PosY = 200;
        Floor2.AddComponent<Hitbox>();
        Floor2.GetComponent<Hitbox>().TopLeft = new System.Numerics.Vector2(0,0);
        Floor2.GetComponent<Hitbox>().BottomRight = new System.Numerics.Vector2(50,200);
        Console.WriteLine(Floor2.GetComponent<Hitbox>().AbsoluteBottomRight);
        Console.WriteLine(Floor2.GetComponent<Hitbox>().AbsoluteTopLeft);
        Floor2.AddComponent<Rigidbody2D>();
        
        
        while (!Raylib.WindowShouldClose())
        {
            
            Raylib.WaitTime(0.016);
       
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.WHITE);
            Player.Tick();
            //DrawHitbox(Player);
            DrawHitbox(Floor);
             DrawHitbox(Floor2);
             Floor2.Tick();

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
