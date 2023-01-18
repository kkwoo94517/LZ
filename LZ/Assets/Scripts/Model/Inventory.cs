using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    // 현재 인벤토리 내 아이템 갯수
    public int Count => Items?.Values.Count ?? 0;

    // 각 아이템마다의 카운트
    public Dictionary<int, int> EachCount => Items?.ToDictionary(k => k.Key, v => v.Value.Count) ?? new Dictionary<int, int>();

    // 획득한 아이템
    // Key : UnqieuId
    public Dictionary<int, List<Item>> Items { get; set; } = new Dictionary<int, List<Item>>();

    // 아이템 획득
    public void AddItem(Item item)
    {
        // 이미 존재한다면 해당 리스트에 추가
        if (Items.ContainsKey(item.UniqueId))
        {
            Items[item.UniqueId].Add(item);
        }
        else
        {
            Items.Add(item.UniqueId, new List<Item>() { item });
        }
    }

    // 아이템 제거
    public void RemoveItem(Item item)
    {
        if (Items.ContainsKey(item.UniqueId))
        {
            Items[item.UniqueId].Remove(item);
        }
    }
}