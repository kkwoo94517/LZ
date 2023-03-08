using System;

[Serializable]
public class ScenarioEntity
{
    public int GroupId;
    public int Order;
    public int Answer_1;
    public int Answer_2;
    public int Answer_3;
    public string Describe;

    public ScenarioEntity() { }

    public ScenarioEntity(ScenarioEntity data)
    {
        GroupId = data.GroupId;
        Order = data.Order;
        Answer_1 = data.Answer_1;
        Answer_2 = data.Answer_2;
        Answer_3 = data.Answer_3;
        Describe = data.Describe + "\n\n\n\n\n\n";
    }
}