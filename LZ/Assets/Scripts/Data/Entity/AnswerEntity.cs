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
}