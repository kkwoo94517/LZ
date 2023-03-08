using System;

[Serializable]
public class TownHouseEntity
{
    public HouseType HouseType;
    public string DevName;
    public int OpenLevel;
    public string DescribeString;

    public TownHouseEntity() { }

    public TownHouseEntity(TownHouseEntity data)
    {
        HouseType = data.HouseType;
        DevName = data.DevName;
        OpenLevel = data.OpenLevel;
        DescribeString = data.DescribeString;
    }
}
