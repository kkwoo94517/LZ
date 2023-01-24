
using System.Collections.Generic;

public class Player
{
    // 현재 좀비화 점수
    public int Score { get; set; }

    // 현재 챕터
    public int Chapter { get; set; }

    // 현재 스테이지
    public int Stage { get; set; }

    // 오늘 날의 상태
    public DateType DateType { get; set; }

    // 현재 체력
    public int CurrentHP { get; set; }

    // 최대 체력
    public int MaxHP { get; set; }

    // 제거 카드 가능 횟수
    public int RemoveCardPoint { get; set; }

    // 리롤 가능 횟수
    public int ReRollCardPoint { get; set; }

    // 현재 몸 상태
    public Dictionary<BodyType, BodyDamageType> BodyStatus = new Dictionary<BodyType, BodyDamageType>();

    // 뽑기 아이템 확률
    public Dictionary<GradeType, int> GachaProbability = new Dictionary<GradeType, int>();

    public Player()
    {
        Score = 0;
    }

    public void SetGachaProbability()
    {

    }
}