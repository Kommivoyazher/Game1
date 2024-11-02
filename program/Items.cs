using System.Net.NetworkInformation;

namespace Game1.program;
public class Items
{
    public static Item GetItem(int Id) 
    {
        switch (Id)
        {
            case 0: return Helmet;
            case 1: return Stick;
            case 2: return StickInShit;
            case 3: return Bow;
            case 4: return Mask;
            case 5: return Whip;
            default: return null;
        }
    }

    public static Item Helmet = new(0, "Шлем", "Обычная", 10);
    public static Item Stick = new(1, "Палка", "Обычная", 1);
    public static Item StickInShit = new(2, "Палка в говне", "ЛЕГЕНДАРНАЯ", 666);
    public static Item Bow = new(3, "Лук", "Редкая", 52);
    public static Item Mask = new(4, "Кожанная маска", "ЭпиЧеская", 1488);
    public static Item Whip = new(5, "Плетка", "Редкая", 69);
}
