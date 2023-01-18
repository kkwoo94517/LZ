
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;

[Serializable]
public class ItemEntity
{
    // 키 값
    public int UniqueId { get; set; }
    // 등장 확률
    public int Probability { get; set; }
    // 등급
    public GradeType Grade { get; set; }
    // 획득 점수
    public int Score { get; set; }
    // 구매시 가격
    public int Price { get; set; }
    // 제목
    public string Title { get; set; }
    // 내용
    public string Describe { get; set; }
    // 태그 원본
    public string TagJson { get; set; }
    [JsonIgnore] // 연관 태그
    public HashSet<TagType> Tags { get; set; }

    public ItemEntity(ItemEntity data)
    {
        UniqueId = data.UniqueId;
        Probability = data.Probability;
        Grade = data.Grade;
        Score = data.Score;
        Price = data.Price;
        Title = data.Title;
        Describe = data.Describe;
        TagJson = data.TagJson;

        Tags = GetTagTypes(data.TagJson);
    }

    public HashSet<TagType> GetTagTypes(string tagjson)
    {
        var result = new HashSet<TagType>();
        var tags = tagjson.Split(';').ToList();

        tags.ForEach(e => result.Add((TagType)Enum.Parse(typeof(TagType), e)));

        return result;
    }
}