using System;

[Serializable]
public class AnswerEntity
{
    public int UniqueId;
    public RewardType ConditionRewardType;
    public int ConditionAmount;
    public RewardType RewardType;
    public int RewardAmount;
    public string Title;
    public string Describe;

    public AnswerEntity() { }

    public AnswerEntity(AnswerEntity data)
    {
        UniqueId = data.UniqueId;
        ConditionRewardType = data.ConditionRewardType;
        ConditionAmount = data.ConditionAmount;
        RewardType = data.RewardType;
        RewardAmount = data.RewardAmount;
        Title = data.Title;
        Describe = data.Describe;
    }
}