using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

[Serializable]
public class AugmentedEntity
{
    public int UniqueId { get; set; }
    public string Title { get; set; }
    public string Describe { get; set; }

    public AugmentedType Augmented { get; set; }

    public string ItemJson { get; set; }
    [JsonIgnore]
    public HashSet<int> ItemIds { get; set; }

    public AugmentedEntity(AugmentedEntity data)
    {
        UniqueId = data.UniqueId;
        Title = data.Title;
        Describe = data.Describe;
        Augmented = data.Augmented;
        ItemJson = data.ItemJson;
        ItemIds = GetItemIds(data.ItemJson);
    }

    public HashSet<int> GetItemIds(string tagjson)
    {
        var result = new HashSet<int>();
        var tags = tagjson.Split(';').ToList();

        tags.ForEach(e => result.Add(int.Parse(e)));

        return result;
    }
}

