using System;

[Serializable]
public class StageEntity
{
    public int StageId;
    public TileEventType TileEventType;
    public GradeType Grade;
    public StoryEventType StoryEventType;

    public StageEntity() { }

    public StageEntity(StageEntity data)
    {
        StageId = data.StageId;
        TileEventType = data.TileEventType;
        Grade = data.Grade;
        StoryEventType = data.StoryEventType;
    }
}