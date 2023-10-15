using System.Numerics;
using System.Reflection;
using Raylib_cs;



public abstract class Component
{
    public abstract void Tick();
    
   
    public string name = "";
    public GameObject? gameObject;
}



public class GameObject
{
    public void Tick()
    {
        foreach(Component c in Components)
        {
            c.Tick();
        }
    }

    public List<Component> Components = new List<Component>();
    public Transform transform;
    public GameObject()
    {
        AddComponent<Transform>();
        transform = (Transform)Components[0];
    }
    public T GetComponent<T>() where T : Component
    {
        for (int i = 0; i < Components.Count; i++)
        {
            
            if (Components[i]  is T)
            {
                
                return (T)Components[i];
            }
        }
        return null;
    }
    public void AddComponent<T>() where T :  Component
    {
        T comp = Activator.CreateInstance<T>();
        comp.gameObject = this;
        Components.Add(comp);
        

        
    }
}