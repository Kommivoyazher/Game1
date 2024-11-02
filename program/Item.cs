using System.Reflection;

namespace Game1.program;
public class Item : IObject
{
    public int ItemId { get; }
    public string Name { get; }
    public string Rarity { get; }
    public int Cost { get; }
    public Item(int id, string name, string rarity, int cost)
    {
        ItemId = id;
        Name = name;
        Rarity = rarity;
        Cost = cost;
    }

    public override string ToString()
    {
        return $"Name item: {Name}\n" +
            $"Rarity: {Rarity}\n" +
            $"Cost: {Cost}";
    }

    public object Clone()
    {
        return new Item(ItemId, Name, Rarity, Cost);
    }
    public static FieldInfo[] Items = typeof(Items).GetFields(BindingFlags.Public | BindingFlags.Static);

}
