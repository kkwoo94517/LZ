using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMedicalPeople : MonoBehaviour
{
    [SerializeField] private Text Name;
    [SerializeField] private Text Property;
    [SerializeField] private Text CureDay;

    public void SetMedicalPeople(string name, string property, int cureDay)
    {
        Name.text = name;
        Property.text = property;
        CureDay.text = $"회복까지 : {cureDay}일";
    }
}
