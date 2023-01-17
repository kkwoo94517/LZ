using System;

[Serializable]
public class ScenarioEntity
{
    public long GroupId;
    public long Chapter;
    public long Episode;
    public AnswerType AnswerType;
    public string Subscribe;
}

public class ScenarioHistory
{
    public long GroupId;
    public long Chapter;
    public long Episode;
}