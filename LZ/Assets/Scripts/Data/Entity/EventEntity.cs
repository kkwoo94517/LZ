
using System;

[Serializable]
public class EventEntity
{
    public int UniqueId;

    public EventEntity() { }

    public EventEntity(EventEntity data)
    {
        UniqueId = data.UniqueId;
    }
}