
using System;

[Serializable]
public class MonsterEntity
{
    public int UniqueId;

    public MonsterEntity() { }

    public MonsterEntity(MonsterEntity data)
    {
        UniqueId = data.UniqueId;
    }
}