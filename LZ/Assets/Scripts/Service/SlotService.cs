using System.Linq;
using System;

public class SlotService
{
    // 슬롯에 아이템 배치하기
    public void Shuffle(Inventory inventory, Slot slot)
    {
        slot.Clear();

        // 인벤토리에서 아이템 꺼내오기 (height * width 갯수)
        Random random = new Random((int)DateTime.Now.Ticks);
        var items = inventory.Items.Values.SelectMany(e => e)
            .OrderBy(e => random.Next())
            .Take(slot.Count).ToList();

        // 빈 아이템도 넣어두기
        if (inventory.Items.Count < slot.Count)
        {
            var enoughCount = slot.Count - inventory.Items.Count;

            var emptyItems = Enumerable.Repeat(new Item(), enoughCount);

            items.AddRange(emptyItems);
        }

        // 만약 넘치게 배치될 경우 오류
        if (items.Count > slot.Count)
        {
            throw new Exception($"{items.Count} > {slot.Count} 슬롯에 배치할 아이템이 너무 많습니다.");
        }

        // 고정된 아이템 미리 배치하기
        var fixedItems = slot.BeforeItems?.SelectMany(e => e).Where(e => e.Tags.Contains(TagType.Fixed));
        if (fixedItems != null && fixedItems.Any())
        {
            foreach (var item in fixedItems)
            {
                slot.CurrentItems[item.Y - 1][item.X - 1].Set(
                    uniqueId: item.UniqueId,
                    item.X,
                    item.Y,
                    singularScore: 0,
                    accumulateScore: 0,
                    tags: item.Tags,
                    nearItems: item.NearItems);
            }
        }

        // 꺼내온 아이템 배치하기
        int x = 0, y = 0;
        foreach (var item in items)
        {
            // 아이템이 이미 있는지 확인
            if (!slot.CurrentItems[y][x].IsOnSlot)
            {
                slot.CurrentItems[y][x].Set(
                    uniqueId: item.UniqueId,
                    x + 1,
                    y + 1,
                    singularScore: 0,
                    accumulateScore: 0,
                    tags: item.Tags,
                    nearItems: item.NearItems);
            }

            if (x >= slot.Width)
            {
                y++;
                x = 0;
            }

            x++;
        }

        var currentItems = slot.CurrentItems.SelectMany(e => e).ToList();

        // 근처 아이템 빌드하기
        currentItems.ForEach(e => e.BuildNearItems(slot.CurrentItems));

        // 슬롯 아이템 점수 계산하기
        currentItems.ForEach(e => e.Active());
    }
}