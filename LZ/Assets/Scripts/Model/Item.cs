using System.Collections.Generic;
using System.Linq;

public class Item
{
    // 아이템 키
    public int UniqueId { get; set; }

    // 아이템 갯수
    public int StackCount { get; set; }

    // 아이템의 무게
    public float Weight { get; set; }

    // 아이템이 가방에 있는지
    public bool OnInventory { get; set; }
    // public int Combo { get; protected set; } = 1;
}