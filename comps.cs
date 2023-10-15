using System.Numerics;
using System.Security.Cryptography.X509Certificates;
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
       
        YVelocity -= GravityFactor;
        XVelocity *= 0.999f;




        //collision
        if (gameObject.GetComponent<Hitbox>() != null)
        {
            //selfColl is own hitbox
            Hitbox SelfColl = gameObject.GetComponent<Hitbox>();
            //new position without any collision
            int newY =  (int)MathF.Round(gameObject.transform.PosY - YVelocity);
            int newX = (int)MathF.Round(gameObject.transform.PosX - XVelocity);
            //TODO: USES SELFCOLL FOR SOME REASON?? WHAT
            //iterates through every hitbox and checks for collision
            foreach (Hitbox h in CollisionBoxes.Boxes)
            {
                //checks if any points of its own hitbox and the other ones overlaps
                if (h == SelfColl)
                {
                    //leaves if its checking collision against itself
                    continue;

                }
                //gets collision data. array: first is if x breaks against something, second is if y breaks against something
                bool[] collisions = InsideBox(new Vector2(newX,newY),new Vector2(newX + SelfColl.BottomRight.X,newY + SelfColl.BottomRight.Y),h.AbsoluteTopLeft,h.AbsoluteBottomRight);
                if (collisions[0])
                {
                    Console.WriteLine("X collision");
                    newX = gameObject.transform.PosX;
                    XVelocity = 0;


                }
                if (collisions[1])
                {
                    Console.WriteLine("Y Collision!");
                    newY = gameObject.transform.PosY;
                    YVelocity = 0;
                    XVelocity *= 0.7f;


                }
                
                    //snaps to a certain points)
                   
                    

                
                
            }
           
            gameObject.transform.PosX = newX;
            gameObject.transform.PosY = newY;
            

        }
        else
        {
            gameObject.transform.PosY = (int)MathF.Round(gameObject.transform.PosY - YVelocity);
            gameObject.transform.PosX = (int)MathF.Round(gameObject.transform.PosX - XVelocity);

        }
        


    }
    public bool[] InsideBox(Vector2 checkbox,Vector2 Bright, Vector2 upleft, Vector2 bottomright)
    {
        
        

        if(Bright.X > upleft.X && Bright.X < bottomright.X)
        {
            
            if(Bright.Y > upleft.Y && Bright.Y < bottomright.Y)
            {
                return new bool[]{true,true};
            }
        }
       
         if(checkbox.X > upleft.X && checkbox.X < bottomright.X)
        {
            
            if(checkbox.Y > upleft.Y && checkbox.Y < bottomright.Y)
            {
                return new bool[]{true,true};
            }
        }
        Vector2 v = new Vector2(Bright.X,checkbox.Y);

        if(v.X > upleft.X && v.X < bottomright.X)
        {
            
            if(v.Y > upleft.Y && v.Y < bottomright.Y)
            {
                return new bool[]{true,true};
            }
        }
        v = new Vector2(checkbox.X,Bright.Y);

        if(v.X > upleft.X && v.X < bottomright.X)
        {
            
            if(v.Y > upleft.Y && v.Y < bottomright.Y)
            {
                return new bool[]{true,true};
            }
        }
      

        return new bool[]{false,false};
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
public class Hitbox : Component
{
    public override void Tick()
    {
        
    }
    public Vector2 TopLeft;
    public Vector2 BottomRight;

    public Vector2 AbsoluteBottomRight{get
    {
        return BottomRight + new Vector2(gameObject.transform.PosX,gameObject.transform.PosY);

    }}

    public Vector2 AbsoluteTopLeft{get
    {
        return TopLeft + new Vector2(gameObject.transform.PosX,gameObject.transform.PosY);

    }    
    }
    public Hitbox()
    {
        CollisionBoxes.Boxes.Add(this);
    }
}

public static class CollisionBoxes
{
    public static List<Hitbox> Boxes = new List<Hitbox>();
}