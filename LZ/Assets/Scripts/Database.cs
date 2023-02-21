using System.Collections.Generic;
using System;
using UnityEngine;

public class Database : MonoSingleton<Database>
{
    //[SerializeField] private ItemData ItemData;
    [SerializeField] private CharacterStatusData CharacterStatusData;
    [SerializeField] private CharacterLevelData CharacterLevelData;
    [SerializeField] private TownHouseData TownHouseData;
    [SerializeField] private StageData StageData;

    // Key : ItemUniqueId
    //public Dictionary<int, ItemEntity> ItemDataDict = new Dictionary<int, ItemEntity>();
    public Dictionary<int, CharacterStatusEntity> CharacterStatusDict = new Dictionary<int, CharacterStatusEntity>();
    public Dictionary<int, List<CharacterLevelEntity>> CharacterLevelDict = new Dictionary<int, List<CharacterLevelEntity>>();
    public Dictionary<HouseType, TownHouseEntity> TownHouseDict = new Dictionary<HouseType, TownHouseEntity>();
    public Dictionary<int, List<StageEntity>> StageDict = new Dictionary<int, List<StageEntity>>();


    public IEnumerator<string> LoadData()
    {
        yield return LoadStageData();
        yield return LoadCharacterStatusData();
        yield return LoadTownHouseData();
    }

    //private string LoadItemData()
    //{
    //    ItemDataDict.Clear();
    //    foreach (var data in ItemData.ItemDatas)
    //    {
    //        if (!ItemDataDict.ContainsKey(data.UniqueId))
    //        {
    //            ItemDataDict.Add(data.UniqueId, new ItemEntity(data));
    //        }
    //        else
    //        {
    //            Console.WriteLine($"ItemDataDict duplecated {data.UniqueId}");
    //        }
    //    }

    //    return "가방에서 모든 아이템을 꺼내었다.";
    //}

    private string LoadCharacterStatusData()
    {
        CharacterStatusDict.Clear();
        foreach (var data in CharacterStatusData.CharacterStatusDatas)
        {
            if (!CharacterStatusDict.ContainsKey(data.UniqueId))
            {
                CharacterStatusDict.Add(data.UniqueId, data);

                Console.WriteLine($"{data.UniqueId}");
            }
            else
            {
                Console.WriteLine($"CharacterStatusDict duplecated {data.UniqueId}");
            }
        }

        CharacterLevelDict.Clear();
        foreach (var data in CharacterLevelData.CharacterLevelDatas)
        {
            if (!CharacterLevelDict.ContainsKey(data.UniqueId))
            {
                CharacterLevelDict.Add(data.UniqueId, new List<CharacterLevelEntity>());
            }

            CharacterLevelDict[data.UniqueId].Add(data);
        }

        return "모든 캐릭터들이 잠에서 깨어났다...! ";
    }

    private string LoadTownHouseData()
    {
        TownHouseDict.Clear();
        foreach (var data in TownHouseData.TownHouseDatas)
        {
            if (!TownHouseDict.ContainsKey(data.HouseType))
            {
                TownHouseDict.Add(data.HouseType, data);

                Console.WriteLine($"{data.HouseType}");
            }
            else
            {
                Console.WriteLine($"TownHouseDict duplecated {data.HouseType}");
            }
        }

        return "분주한 건물들 사이로 빛이 새어나온다.";
    }

    private string LoadStageData()
    {
        StageDict.Clear();
        foreach (var data in StageData.StageDatas)
        {
            if (!StageDict.ContainsKey(data.StageId))
            {
                StageDict.Add(data.StageId, new List<StageEntity>());
            }

            StageDict[data.StageId].Add(data);
        }

        return "어두운 하늘이 드리우고, 폭설이 내리기 시작했다.";
    }
}
