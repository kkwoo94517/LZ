using UnityEngine;

public class UIGameModel : MonoBehaviour
{
    public bool AlreadySearch { get; set; }

    public virtual void Load() 
    {
        if (AlreadySearch) { return; }
    }

    public virtual void Load(int uniqueId = 0)
    {
        if (AlreadySearch) { return; }
    }
}