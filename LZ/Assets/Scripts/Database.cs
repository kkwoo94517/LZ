using System.Collections.Generic;
using System;
using UnityEngine;

public class Database : MonoSingleton<Database>
{
    [SerializeField] private CharacterStatusData CharacterStatusData;
    [SerializeField] private CharacterLevelData CharacterLevelData;
    [SerializeField] private TownHouseData TownHouseData;
    [SerializeField] private ScenarioData ScenarioData;
    [SerializeField] private StageData StageData;
    [SerializeField] private ItemData ItemData;
    [SerializeField] private EventData EventData;
    [SerializeField] private MonsterData MonsterData;
    [SerializeField] private StageTileData StageTileData;
    [SerializeField] private RegionData RegionData;

    public Dictionary<int, CharacterStatusEntity> CharacterStatusDict = new Dictionary<int, CharacterStatusEntity>();
    public Dictionary<int, List<CharacterLevelEntity>> CharacterLevelDict = new Dictionary<int, List<CharacterLevelEntity>>();
    public Dictionary<HouseType, TownHouseEntity> TownHouseDict = new Dictionary<HouseType, TownHouseEntity>();
    public Dictionary<long, List<ScenarioEntity>> ScenarioDict = new Dictionary<long, List<ScenarioEntity>>();
    public Dictionary<int, List<StageEntity>> StageDict = new Dictionary<int, List<StageEntity>>();
    public Dictionary<int, ItemEntity> ItemDict = new Dictionary<int, ItemEntity>();
    public Dictionary<int, EventEntity> EventDict = new Dictionary<int, EventEntity>();
    public Dictionary<int, MonsterEntity> MonsterDict = new Dictionary<int, MonsterEntity>();
    public Dictionary<TileEventType, List<StageTileEntity>> StageTileDict = new Dictionary<TileEventType, List<StageTileEntity>>();
    public Dictionary<RegionType, RegionEntity> RegionDict = new Dictionary<RegionType, RegionEntity>();

    public IEnumerator<string> LoadData()
    {
        yield return LoadStageData();
        yield return LoadCharacterStatusData();
        yield return LoadTownHouseData();
        yield return LoadScenarioData();
        yield return LoadItemData();
        yield return LoadEventData();
        yield return LoadMonsterData();
        yield return LoadStageTileData();
        yield return LoadRegionData();
    }

    private string LoadCharacterStatusData()
    {
        CharacterStatusDict.Clear();
        foreach (var data in CharacterStatusData.CharacterStatusDatas)
        {
            if (!CharacterStatusDict.ContainsKey(data.UniqueId))
            {
                CharacterStatusDict.Add(data.UniqueId, new CharacterStatusEntity(data));

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

            CharacterLevelDict[data.UniqueId].Add(new CharacterLevelEntity(data));
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
                TownHouseDict.Add(data.HouseType, new TownHouseEntity(data));

                Console.WriteLine($"{data.HouseType}");
            }
            else
            {
                Console.WriteLine($"TownHouseDict duplecated {data.HouseType}");
            }
        }

        return "분주한 건물들 사이로 빛이 새어나온다.";
    }

    private string LoadScenarioData()
    {
        ScenarioDict.Clear();
        foreach (var data in ScenarioData.ScenarioDatas)
        {
            if (!ScenarioDict.ContainsKey(data.GroupId))
            {
                ScenarioDict.Add(data.GroupId, new List<ScenarioEntity>());
            }

            ScenarioDict[data.GroupId].Add(new ScenarioEntity(data));
        }

        return "오늘의 이야기는 어제와 함께합니다.";
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

            StageDict[data.StageId].Add(new StageEntity(data));
        }

        return "어두운 하늘이 드리우고, 폭설이 내리기 시작했다.";
    }

    private string LoadItemData()
    {
        ItemDict.Clear();
        foreach (var data in ItemData.ItemDatas)
        {
            if (!ItemDict.ContainsKey(data.UniqueId))
            {
                ItemDict.Add(data.UniqueId, new ItemEntity(data));

                Console.WriteLine($"{data.UniqueId}");
            }
            else
            {
                Console.WriteLine($"ItemDict duplecated {data.UniqueId}");
            }
        }

        return "폭풍우에 아이템이 사방 팔방으로 흩어집니다.";
    }

    private string LoadEventData()
    {
        EventDict.Clear();
        foreach (var data in EventData.EventDatas)
        {
            if (!EventDict.ContainsKey(data.UniqueId))
            {
                EventDict.Add(data.UniqueId, new EventEntity(data));

                Console.WriteLine($"{data.UniqueId}");
            }
            else
            {
                Console.WriteLine($"EventDict duplecated {data.UniqueId}");
            }
        }

        return "빨간 실의 끝이 어딘가를 향해 이동합니다.";
    }

    private string LoadMonsterData()
    {
        MonsterDict.Clear();
        foreach (var data in MonsterData.MonsterDatas)
        {
            if (!MonsterDict.ContainsKey(data.UniqueId))
            {
                MonsterDict.Add(data.UniqueId, new MonsterEntity(data));

                Console.WriteLine($"{data.UniqueId}");
            }
            else
            {
                Console.WriteLine($"MonsterDict duplecated {data.UniqueId}");
            }
        }

        return "피에 굶주린 몬스터가 깨어나고 있습니다.";
    }

    private string LoadStageTileData()
    {
        StageTileDict.Clear();
        foreach (var data in StageTileData.StageTileDatas)
        {
            if (!StageTileDict.ContainsKey(data.TileEventType))
            {
                StageTileDict.Add(data.TileEventType, new List<StageTileEntity>());
            }

            StageTileDict[data.TileEventType].Add(new StageTileEntity(data));
        }

        return "세상이 뒤죽박죽 섞이기 시작했습니다. ";
    }

    private string LoadRegionData()
    {
        RegionDict.Clear();
        foreach (var data in RegionData.RegionDatas)
        {
            if (!RegionDict.ContainsKey(data.RegionType))
            {
                RegionDict.Add(data.RegionType, new RegionEntity(data));

                Console.WriteLine($"{data.RegionType}");
            }
            else
            {
                Console.WriteLine($"RegionDict duplecated {data.RegionType}");
            }
        }

        return "지역이 차가운 바람과 함께 얼어붙고 있습니다.";
    }
}
