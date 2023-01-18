using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;

[Serializable]
public class StoryEventEntity
{
    public int UniqueId { get; set; }
    public string Title { get; set; }
    public string Describe { get; set; }
    public string ItemJson { get; set; }

    [JsonIgnore]
    public List<int> ItemUniqueIds { get; set; }


    public StoryEventEntity(StoryEventEntity data)
    {
        UniqueId = data.UniqueId;
        Title = data.Title;
        Describe = data.Describe;
        ItemJson = data.ItemJson;

        ItemUniqueIds = GetItemUniqueIds(data.ItemJson);
    }

    public List<int> GetItemUniqueIds(string itemJson)
    {
        var result = new List<int>();
        var tags = itemJson.Split(';').ToList();

        tags.ForEach(e => result.Add(int.Parse(e)));

        return result;
    }
}