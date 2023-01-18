using System;
using System.Data;
using System.Data.Common;

[Serializable]
public class ChapterEntity
{
    // 난이도 키 값
    public int Chapter { get; set; }
    // 제목
    public string Title { get; set; }
    public DifficultyType Difficulty { get; set; }

    public ChapterEntity(ChapterEntity data)
    {
        Chapter = data.Chapter;
        Title = data.Title;
        Difficulty = data.Difficulty;
    }
}
