using System.Collections.Generic;
using System.Linq;

public class Item
{
    // 아이템 키
    public int UniqueId { get; set; }

    // 해당 아이템의 위치
    // Default : 0, 1 ~ 5
    public int X { get; set; }
    public int Y { get; set; }


    // 단일로 지급되는 좀비화 점수
    // Default : 0
    public int SingularScore { get; set; }

    // 누적되는 좀비화 점수
    // Default : 0
    public int AccumulateScore { get; set; }

    // 현재 아이템 상태
    public StatusType Status { get; protected set; }

    public int Combo { get; protected set; } = 1;

    // 슬롯 or 인벤토리
    public bool IsOnSlot => X > 0 && Y > 0;

    // 한 회에 얻게 되는 좀비화 점수
    // 단일 점수, 누적된 점수, 이번에 활성화 된 점수
    public int TotalScore => SingularScore + AccumulateScore + ActiveLists.Sum(e => e.Score);

    // 해당 아이템의 여러 태그
    public HashSet<TagType> Tags { get; set; } = new HashSet<TagType>();

    // 주변에 있는 아이템들
    public List<Item> NearItems { get; set; } = new List<Item>();

    // 재생해야할 애니메이션 목록
    public List<(int Score, AnimationType Ani)> ActiveLists { get; set; } = new List<(int, AnimationType)>();

    // 최초 슬롯 전체 생성
    public Item()
    {
        Tags = new HashSet<TagType>();
        NearItems = new List<Item>();
        ActiveLists = new List<(int, AnimationType)>();
    }

    public Item Clone()
    {
        return new Item
        {
            UniqueId = UniqueId,
            X = X,
            Y = Y,
            SingularScore = SingularScore,
            AccumulateScore = AccumulateScore,
            Tags = new HashSet<TagType>(Tags),
            NearItems = new List<Item>(NearItems),
            ActiveLists = new List<(int, AnimationType)>(ActiveLists),
        };
    }

    public void Set(int uniqueId, int x, int y, int singularScore, int accumulateScore, HashSet<TagType> tags, List<Item> nearItems)
    {
        UniqueId = uniqueId;
        X = x;
        Y = y;
        SingularScore = singularScore;
        AccumulateScore = accumulateScore;
        Tags = tags;
        NearItems = nearItems;
    }

    public void BuildNearItems(Item[][] currentItems)
    {
        NearItems.Clear();

        for (int y = 0; y < currentItems.Length; y++)
        {
            for (int x = 0; x < currentItems[y].Length; x++)
            {
                // 자기 자신은 제외
                if (X == x + 1 && Y == y + 1) { continue; }

                // 중심을 주변으로 3x3으로 가져오기
                if ((X - 1 <= x + 1 && X + 1 >= x + 1) &&
                    (Y - 1 <= y + 1 && Y + 1 >= y + 1))
                {
                    NearItems.Add(currentItems[y][x]);
                }
            }
        }
    }

    public virtual void Active()
    {

    }
}




// 똥
public class PoopItem : Item
{
    public override void Active()
    {
        base.Active();

        Status = StatusType.Activate;
    }
}

// 하루살이
public class EphemeraItem : Item
{
    public override void Active()
    {
        base.Active();

        if (IsOnSlot)
        {
            Status = StatusType.Destory;
            ActiveLists.Add((0, AnimationType.Destory));
        }
    }
}

// 외톨이
public class AloneItem : Item
{
    public override void Active()
    {
        base.Active();

        // TODO 
        // ActiveLists에 각각의 이벤트 점수 더하기
        // 예를 들어, 혼자 있으면 3배로 얻고 터집니다.
        // 누군가와 같이 있으면 기본 값만 받습니다.
        if (NearItems.Any(e => !e.Tags.Contains(TagType.None)))
        {
            Status = StatusType.Destory;
            ActiveLists.Add((0, AnimationType.Destory));
        }
        else
        {
            Combo++;
            Status = StatusType.Activate;
            ActiveLists.Add((SingularScore, AnimationType.AddScore));
        }
    }
}

public class FlyItem : Item
{
    public override void Active()
    {
        base.Active();

        foreach (var item in NearItems)
        {
            if (item.Tags.Contains(TagType.Poop))
            {
                Combo++;
                ActiveLists.Add((SingularScore, AnimationType.AddScore));
            }
        }
    }
}



