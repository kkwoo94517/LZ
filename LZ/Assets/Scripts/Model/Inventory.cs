using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    // 현재 인벤토리 내 아이템 갯수
    public int TotalCount => Items?.Values.Sum(e => e.Item2.StackCount) ?? 0;

    // 현재 인벤토리 최대 무게
    public float MaxWeight = 10.0f;

    // 현재 인벤토리 무게
    public float CurrentWeight => Items?.Values.Sum(e => e.Item2.Weight) ?? 0.0f;

    // 획득한 아이템
    // Key : UnqieuId, value : (index, item)
    public Dictionary<int, (int, Item)> Items { get; set; } = new Dictionary<int, (int, Item)>();

    // 아이템 획득
    public void Add(int uniqueId)
    {
        // 이미 존재한다면 아이템 StackCount++
        if (Items.ContainsKey(uniqueId))
        {
            Items[uniqueId].Item2.StackCount++;
        }
        else
        {
            // TODO : CreateFactory 추가
            var item = new Item();

            Items.Add(uniqueId, (Items.Count + 1, item));
        }
    }

    // 인벤토리 비우기
    public void Clear()
    {
        Items.Clear();
        Items = new Dictionary<int, (int, Item)>();
    }
}