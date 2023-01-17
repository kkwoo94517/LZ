using System;
using Unity.VisualScripting;

public class Database
{
    public virtual string LoadDoneText { get; protected set; }

    public virtual void Load() 
    {
        Console.WriteLine($"{this.GetType().Name} Start Load");
    }
}

public class ScenarioData : Database
{
    public override string LoadDoneText { get; protected set; } = "시나리오 로드 완료";

    public override void Load()
    {
        base.Load();    
    }
}