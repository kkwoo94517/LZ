public class Slot
{
    // 가로 길이 1 ~ 5
    public int Width { get; set; }
    // 세로 길이 1 ~ 5
    public int Height { get; set; }
    // 전체 갯수
    public int Count => Width * Height;

    // 현재 슬롯 0 ~ 4
    public Item[][] CurrentItems;

    // 이전 슬롯 0 ~ 4
    public Item[][] BeforeItems;


    // 최초 생성자
    public Slot(int width, int height)
    {
        Width = width;
        Height = height;

        CurrentItems = new Item[height][];
        BeforeItems = new Item[height][];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                CurrentItems[y][x] = new Item();
                BeforeItems[y][x] = new Item();
            }
        }
    }
}