using System;

[Serializable]
public class RegionEntity
{
    public RegionType RegionType;
    public string DevName;
    public int Level;
    public bool Enable;

    public RegionEntity() { }

    public RegionEntity(RegionEntity data)
    {
        RegionType = data.RegionType;
        DevName = data.DevName;
        Level = data.Level;
        Enable = data.Enable;
    }
}