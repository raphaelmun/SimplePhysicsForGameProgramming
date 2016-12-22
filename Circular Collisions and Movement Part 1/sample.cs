public class Vector2D
{
    public float X;
    public float Y;
    
    public Vector2D( float x, float y )
    {
        this.X = x;
        this.Y = y;
    }
    
    public static Vector2D operator +( Vector2D value1, Vector2D value2 )
    {
        value1.X += value2.X;
        value1.Y += value2.Y;
        return value1;
    }

    public static Vector2D operator -( Vector2D value1, Vector2D value2 )
    {
        value1.X -= value2.X;
        value1.Y -= value2.Y;
        return value1;
    }

    public static Vector2D operator *( Vector2D value1, Vector2D value2 )
    {
        value1.X *= value2.X;
        value1.Y *= value2.Y;
        return value1;
    }

    public static Vector2D operator *( Vector2D value, float scaleFactor )
    {
        value.X *= scaleFactor;
        value.Y *= scaleFactor;
        return value;
    }

    public static Vector2D operator *( float scaleFactor, Vector2D value )
    {
        value.X *= scaleFactor;
        value.Y *= scaleFactor;
        return value;
    }

    public static Vector2D operator /( Vector2D value1, Vector2D value2 )
    {
        value1.X /= value2.X;
        value1.Y /= value2.Y;
        return value1;
    }

    public static Vector2D operator /( Vector2D value1, float divider )
    {
        float factor = 1 / divider;
        value1.X *= factor;
        value1.Y *= factor;
        return value1;
    }
    
    // Get the length of the vector
    public float Length()
    {
        return (float)Math.Sqrt( ( X * X ) + ( Y * Y ) );
    }
    
    // Make the vector a length of 1
    public void Normalize()
    {
        float val = 1.0f / Length();
        X *= val;
        Y *= val;
    }
}

public class Entity
{
    public Vector2D Position;
    public Vector2D Velocity;
    public float Radius;
    public float Mass;

    public Entity( Vector2D pos, Vector2D vel, float radius, float mass )
    {
        this.Position = pos;
        this.Velocity = vel;
        this.Radius = radius;
        this.Mass = mass;
    }
    
    public void Step( float time )
    {
        this.Position = this.Velocity * time;
    }
}

public class World
{
    public List<Entity> Bubbles;
    
    public World()
    {
        Bubbles = new List<Entity>();
    }
    
    public void Step( float time )
    {
        foreach( var bubble in Bubbles )
        {
            bubble.Step( time );
        }
    }
    
    public static World GiveMeRandomBubbles( int numBubbles = 10, int maxX = 1000, int maxY = 1000 )
    {
        var world = new World();
        var random = new Random();
        for( int i = 0; i < numBubbles; i++ )
        {
            Vector2D pos = new Vector2D( (float)random.Next( maxX ), (float)random.Next( maxY ) );
            Vector2D vel = new Vector2D( (float)( random.Next( maxX ) - maxX / 2 ), (float)( random.Next( maxY ) - maxY / 2 ) );
            float radius = 50;
            float mass = 1.0f;
            world.Bubbles.Add( new Entity( pos, vel, radius, mass ) );
        }
        return world;
    }
}