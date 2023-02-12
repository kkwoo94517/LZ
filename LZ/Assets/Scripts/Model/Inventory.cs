using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    // 현재 인벤토리 내 아이템 갯수
    public int TotalCount => Items?.Sum(e => e.StackCount) ?? 0;

    // 현재 인벤토리 최대 무게
    public float MaxWeight = 10.0f;

    // 현재 인벤토리 무게
    public float CurrentWeight => Items?.Sum(e => e.Weight) ?? 0.0f;

    // 획득한 아이템
    public List<Item> Items { get; set; } = new List<Item>();

    public Dictionary<int, int> History { get; set; } = new Dictionary<int, int>();

    // 아이템 획득
    public void Add(int uniqueId, int amount)
    {
        // 이미 존재한다면 아이템 StackCount++
        var found = Items.FirstOrDefault(e => e.UniqueId == uniqueId);
        if (found == null)
        {
            var item = new Item()
            {
                UniqueId = uniqueId,
                StackCount = amount,
                OnInventory = true,
            };

            Items.Add(item);
        }
        else
        {
            found.StackCount += amount;
        }

        if (!History.ContainsKey(uniqueId))
        {
            History.Add(uniqueId, 0);
        }
        History[uniqueId] += amount;
    }

    public void Reduce(int uniqueId, int amount)
    {
        var found = Items.FirstOrDefault(e => e.UniqueId == uniqueId);
        if (found == null)
        {
            throw new System.Exception();
        }

        found.StackCount -= amount;
    }

    public void ArrangeItems()
    {
        if (!Items.Any()) { return; }

        var upsertItems = new List<Item>();

        foreach (var item in Items)
        {
            if (item.StackCount > 0)
            {
                upsertItems.Add(item);
            }
        }

        Items = upsertItems;
    }

    public bool Found(int uniqueId)
    {
        return Items?.Any(e => e.UniqueId == uniqueId) ?? false;
    }

    public bool Many(int uniqueId)
    {
        if (!Found(uniqueId))
        {
            return false;
        }

        return Items.FirstOrDefault(e => e.UniqueId == uniqueId).StackCount >= 1;
    }
}