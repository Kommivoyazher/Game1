namespace Game1.program;
public class Player
{
    public string Name { get; }
    public Inventory Inv { get; } = new();
    public Pos Pos { get; }
    public int UserID { get; }
    public Player(string name, Pos pos) 
    {
        Random rnd = new();
        UserID = rnd.Next(100000000, 1000000000);
        Name = name;
        Pos = (Pos)pos.Clone();
    }
    public static bool LhsIsGreater(object lhs, object rhs)
    { 
        Player lhsP = (Player)lhs;
        Player rhsP = (Player)rhs;
        return lhsP.Inv.GetCost() > rhsP.Inv.GetCost();
    }
}
