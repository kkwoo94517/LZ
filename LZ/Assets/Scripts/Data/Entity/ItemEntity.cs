
using System;

[Serializable]
public class ItemEntity
{
    public int UniqueId;
    public string Title;
    public string Describe;
    public int Probability;
    public int Price;
    public float Weight;

    public ItemEntity() { }

    public ItemEntity(ItemEntity data)
    {
        UniqueId = data.UniqueId;
        Title = data.Title;
        Describe = data.Describe;
        Probability = data.Probability;
        Price = data.Price;
        Weight = data.Weight;
    }
}