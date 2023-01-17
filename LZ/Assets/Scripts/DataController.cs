using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public bool IsLoadDone { get; set; }

    public List<Database> DatabaseList { get; set; }

    private void LoadData()
    {
        DatabaseList = new List<Database>
        {
            new ScenarioData()
        };
    }
}
