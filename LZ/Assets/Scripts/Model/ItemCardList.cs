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

    public void Shuffle()
    {
        ItemUniqueIds.Clear();

        // 플레이어 가챠 테이블 데이터 받아오기
        Player player = new Player();
        Random random = new Random((int)DateTime.Now.Ticks);

        var gradeSet = new List<GradeType>();

        // 확률에 따른 브실골 카드 가챠
        for (int i = 0; i < Count; i++)
        {
            var result = random.Next(0, 10000);

            foreach (var gachaProb in player.GachaProbability)
            {
                var select = result - gachaProb.Value;
                if (select < 0)
                {
                    gradeSet.Add(gachaProb.Key);
                    break;
                }

                result -= select;
            }
        }

        // 가챠 나온 것을 대상으로 랜덤하게
        foreach (var grade in gradeSet)
        {
            // Get Grade Data
            // ItemUniqueIds.Add(random.Next(0, data.max))
        }
    }
}