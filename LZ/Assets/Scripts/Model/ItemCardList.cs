using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ItemCardList
{
    // 선택 가능한 아이템 갯수
    // Default : 3
    public int Count { get; set; }

    // 선택 가능한 아이템 목록
    public List<int> ItemUniqueIds { get; set; }

    public ItemCardList()
    {
        Count = 3;
        ItemUniqueIds = new List<int>();
    }

    public void SetCount(int count)
    {
        Count = count;
    }
}