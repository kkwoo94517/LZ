
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class StageTileEntity
{
    public TileEventType TileEventType;
    public GradeType Grade;
    public string UniqueIds;

    [JsonIgnore]
    public List<int> UniqueList = new List<int>();

    public StageTileEntity() { }

    public StageTileEntity(StageTileEntity data)
    {
        TileEventType = data.TileEventType;
        Grade = data.Grade;
        UniqueIds = data.UniqueIds;

        SetUniqueIds();
    }

    public void SetUniqueIds()
    {
        var ids = UniqueIds?.Split(';').ToList() ?? new List<string>();

        ids.ForEach(e => UniqueList.Add(int.Parse(e)));
    }
}