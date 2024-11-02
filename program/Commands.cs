using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;

namespace Game1.program;

public class Commands
{
    public static void AnalInput(string input)
    {
        if (input == "") return;
        if (input.StartsWith("/help")) { HelpCommand(); return; }
        if (input.StartsWith("/exit")) { ExitCommand(); return; }
        if (input.StartsWith("/createplayer ")) { CreatePlayerCommand(input.Substring(14)); return; }
        if (input.StartsWith("/player ")) { PlayerCommand(input.Substring(8)); return; }
        if (input.StartsWith("/playerinv ")) { PlayerInvCommand(input.Substring(11)); return; }
        if (input.StartsWith("/itemlist")) { ItemListCommand(); return; }
        if (input.StartsWith("/additem ")) { AddItemCommand(input.Substring(9)); return; }
        if (input.StartsWith("/removeitem ")) { RemoveItemCommand(input.Substring(12)); return; }
        if (input.StartsWith("/top")) { TopCommand(); return; }
    }

    public static void TopCommand()
    {
        CompareOp op = new(Player.LhsIsGreater);
        List<Player> players = new List<Player>(Game.Players);
        BubbleSorter<Player>.Sort(players, op);
        for (int i = 0; i < 10; i++)
        {
            if (i < 9) Console.Write(" ");
            try 
            { 
                Console.WriteLine($"{i + 1} - {players[i].Name} ({players[i].Inv.GetCost()})");
                
            }
            catch 
            {
                
                Console.WriteLine($"{i + 1} - -------");
            }
        }
    }

    public static void RemoveItemCommand(string value)
    {
        try
        {
            if (value.Substring(9, 1) != " ")
            {
                Console.WriteLine("Неверный ID персонажа");
                return;
            }
            int playerId = int.Parse(value.Substring(0, 9));
            Player player = Game.Players.Find(p => p.UserID == playerId);
            try
            {
                int itemId = int.Parse(value.Substring(9));
                if (Items.GetItem(itemId) == null)
                {
                    Console.WriteLine("Неверный ID предмета");
                    return;
                }
                try
                {
                    if (player.Inv.Items.Remove(Items.GetItem(itemId)))
                    {   
                        Console.WriteLine("Предмет успешно удален");
                        return;
                    }
                    throw new NullReferenceException();
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Предмета с данным ID в инвентаре нет");
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Неверный ID персонажа");
            }
            catch
            {
                Console.WriteLine("Неверный ID предмета");
            }
        }
        catch 
        {
            Console.WriteLine("Неверный ID персонажа");
        }
    }

    public static void AddItemCommand(string value)
    {
        try 
        {
            if (value.Substring(9, 1) != " ")
            {
                Console.WriteLine("Неверный ID персонажа");
                return;
            }
            int playerId = int.Parse(value.Substring(0, 9));
            Player player = Game.Players.Find(p => p.UserID == playerId);
            try 
            {
                int itemId = int.Parse(value.Substring(9));
                if (Items.GetItem(itemId) == null) 
                {
                    Console.WriteLine("Неверный ID предмета");
                    return;
                }
                player.Inv.Items.Add(Items.GetItem(itemId));
                Console.WriteLine("Предмет успешно добавлен");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Неверный ID персонажа");
            }
            catch 
            {
                Console.WriteLine("Неверный ID предмета");
            }
        }
        catch
        {
            Console.WriteLine("Неверный ID персонажа");
        }
    }

    public static void ItemListCommand()
    {
        foreach (FieldInfo i in Item.Items) Console.WriteLine($"{i.GetValue(null)}\n");
    }

    public static void PlayerInvCommand(string sID)
    {
        try
        {
            int ID = int.Parse(sID);
            Player player = Game.Players.Find(p => p.UserID == ID);
            Console.WriteLine($"Nick: {player.Name}\n" +
                $"ID: {player.UserID}\n" +
                $"Full cost {player.Inv.GetCost()}\n");
            Console.WriteLine(String.Join("\n\n", player.Inv.Items));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Вы ввели ID в неверном формате");
        }
    }

    public static void PlayerCommand(string sID)
    {
        try 
        {
            int ID = int.Parse(sID);
            Player player = Game.Players.Find(p => p.UserID == ID);
            Console.WriteLine($"Nick: {player.Name}\n" +
                $"ID: {player.UserID}\n" +
                $"Pos X: {player.Pos.X} Y: {player.Pos.Y}\n" +
                $"Count of Items: {player.Inv.Items.Count}");
        }
        catch 
        {
            Console.WriteLine("Вы ввели ID в неверном формате");
        }
    }

    public static void CreatePlayerCommand(string name)
    {
        Random rnd = new();
        Player player = new(name, new Pos(rnd.Next(10000) - 5000, rnd.Next(10000) - 5000));
        List<Item> inv = player.Inv.Items;
        inv.Add(Items.Stick);
        for (int i = 0; i < rnd.Next(2,11);i++) inv.Add(Items.GetItem(rnd.Next(6)));
        player.Inv.Items = inv;
        Game.Players.Add(player);
        PlayerCommand($"{player.UserID}");
    }

    public static void HelpCommand()
    {
        Console.WriteLine("...");
    }
    public static void ExitCommand()
    {
        Environment.Exit(0);
    }
}
