public class People
{
    public int UniqueId { get; set; }
    public string Name { get; set; }
    // 현재 마을에 있는지
    public bool OnTown { get; set; }
    // 건강Type => 특성이 꺼지고 켜지는 트리거
    // 갖고 있는 특성
}