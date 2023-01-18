using System;
using System.Data.Common;

[Serializable]
public class StageEntity
{
    public int Chapter { get; set; }
    public int Round { get; set; }
    public int GachaLevel { get; set; }
    public int RemoveCardPoint { get; set; }
    public int ReRollCardPoint { get; set; }
    public int NeedScore { get; set; }

    public StageEntity(StageEntity data)
    {
        Chapter = data.Chapter;
        Round = data.Round;
        GachaLevel = data.GachaLevel;
        RemoveCardPoint = data.RemoveCardPoint;
        ReRollCardPoint = data.ReRollCardPoint;
        NeedScore = data.NeedScore;
    }
}