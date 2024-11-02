namespace Game1.program;
public class Inventory : IObject
{
    public List<Item> Items { get; set; } = new();
    public int GetCost() 
    {
        int FullCost = 0;
        foreach (Item item in Items) FullCost += item.Cost;
        return FullCost;
    }
    public object Clone()
    {
        return new Inventory();
    }
}
