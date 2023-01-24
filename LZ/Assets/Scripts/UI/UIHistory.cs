using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIHistory : MonoBehaviour
{
    [SerializeField] private Transform Parent;
    [SerializeField] private GameObject HistoryItem;

    private int index = 0;
    private List<UIHistoryItem> Items = new List<UIHistoryItem>();


    public void AddHistoryItem()
    {
        var item = Items.ElementAtOrDefault(index);
        if (item == null)
        {
            item = CreateHistoryItem();
        }

        item.SetHistoryItem(null, "蟹控亜走", $"けいしけいしけいしけい {index}");
        item.gameObject.SetActive(true);

        index++;
    }

    private UIHistoryItem CreateHistoryItem()
    {
        var gameObj = Instantiate(HistoryItem, Parent);
        var historyItem = gameObj.GetComponent<UIHistoryItem>();

        gameObj.transform.SetAsFirstSibling();
        Items.Add(historyItem);

        return historyItem;
    }

    public void ClearHistory()
    {
        index = 0;
        Items.ForEach(e => e.gameObject.SetActive(false));
    }
}
