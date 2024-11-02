namespace Game1.program;
public class Pos : IObject
{
    public int X { get; }
    public int Y { get; }
    public Pos( int x, int y ) 
    {
        X = x;
        Y = y;
    }
    public object Clone()
    {
        return new Pos(X, Y);
    }
}
