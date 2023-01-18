using System.Collections.Generic;
using System;
using UnityEngine;

public class Database : MonoBehaviour
{
    // Text 


    [SerializeField] private ItemData ItemData;
    [SerializeField] private ChapterData ChapterData;
    [SerializeField] private StageData StageData;
    [SerializeField] private AugmentedData AugmentedData;
    [SerializeField] private StoryEventData StoryEventData;


    // Key : ItemUniqueId
    public Dictionary<int, ItemEntity> ItemDataDict = new Dictionary<int, ItemEntity>();

    // Key : Chapter
    public Dictionary<int, ChapterEntity> ChapterDataDict = new Dictionary<int, ChapterEntity>();

    // Key : Chapter
    public Dictionary<int, List<StageEntity>> StageDataDict = new Dictionary<int, List<StageEntity>>();

    // Key : UniqueId
    public Dictionary<int, StoryEventEntity> StoryEventDataDict = new Dictionary<int, StoryEventEntity>();

    // Key : UniqueId
    public Dictionary<int, AugmentedEntity> AugmentedDataDict = new Dictionary<int, AugmentedEntity>();




    public void Load()
    {
        LoadItemData();
        LoadChapterData();
        LoadStageData();
        LoadStoryEventData();
        LoadAugmentedData();
    }

    private string LoadItemData()
    {
        ItemDataDict.Clear();
        foreach (var data in ItemData.ItemDatas)
        {
            if (!ItemDataDict.ContainsKey(data.UniqueId))
            {
                ItemDataDict.Add(data.UniqueId, new ItemEntity(data));
            }
            else
            {
                Console.WriteLine($"ItemDataDict duplecated {data.UniqueId}");
            }
        }

        return "가방에서 모든 아이템을 꺼내었다.";
    }

    private string LoadChapterData()
    {
        ChapterDataDict.Clear();
        foreach (var data in ChapterData.ChapterDatas)
        {
            if (!ChapterDataDict.ContainsKey(data.Chapter))
            {
                ChapterDataDict.Add(data.Chapter, new ChapterEntity(data));
            }
            else
            {
                Console.WriteLine($"ChapterDataDict duplecated {data.Chapter}");
            }
        }

        return "정신 없게 난이도 설정 중";
    }

    private string LoadStageData()
    {
        StageDataDict.Clear();
        foreach (var data in StageData.StageDatas)
        {
            var stageData = new StageEntity(data);

            if (!StageDataDict.ContainsKey(data.Chapter))
            {
                StageDataDict.Add(data.Chapter, new List<StageEntity>() { stageData });
            }
            else
            {
                StageDataDict[data.Chapter].Add(stageData);
            }
        }

        return "북적거리는 스테이지 설정 중";
    }


    private string LoadStoryEventData()
    {
        StoryEventDataDict.Clear();
        foreach (var data in StoryEventData.StoryEventDatas)
        {
            if (!StoryEventDataDict.ContainsKey(data.UniqueId))
            {
                StoryEventDataDict.Add(data.UniqueId, new StoryEventEntity(data));
            }
            else
            {
                Console.WriteLine($"StoryEventDataDict duplecated {data.UniqueId}");
            }
        }

        return "쓸만한 시나리오 뽑아내는 중";
    }

    private string LoadAugmentedData()
    {
        AugmentedDataDict.Clear();
        foreach (var data in AugmentedData.AugmentedDatas)
        {
            if (!AugmentedDataDict.ContainsKey(data.UniqueId))
            {
                AugmentedDataDict.Add(data.UniqueId, new AugmentedEntity(data));
            }
            else
            {
                Console.WriteLine($"AugmentedDataDict duplecated {data.UniqueId}");
            }
        }

        return "시스템 가동 준비 완료";
    }
}
