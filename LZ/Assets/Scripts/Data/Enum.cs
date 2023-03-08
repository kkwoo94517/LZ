public enum DayType
{
    Dawn = 0,
    Day = 1,
    Night = 2,
}

public enum ItemCategoryType
{
    None = 0,

}

public enum ParcelType
{
    None = 0,
    Item = 10000,
    Status = 50000,
    Property = 90000,
}

public enum RewardType
{
    None = 0,
    ItemNone = 10000,
    
    StatusNone = 50000,
    STR = 50001,
    WIS = 50002,
    CHA = 50003,

    PropertyNone = 100000,
}

// ???? ?????? ???? (????????)
public enum DifficultyType
{
    Normal = 0,
    Hard = 1,
    Boss = 2,
}

public enum GradeType
{
    None = 0,
    A = 1,
    B = 2,
    C = 3,
    D = 4,
}

public enum AugmentedType
{
    None = 0,
    Destory = 1,
    Singular = 2,
    Accumulate = 3,
}

public enum BodyType
{
    None = 0,
    Head = 1,
    Neck = 2,
    LeftShoulder = 3,
    RightShoulder = 4,
    LeftArm = 5,
    RightArm = 6,
    Chest = 7,
    LeftLeg = 8,
    RightLeg = 9,
}

public enum BodyDamageType
{
    None = 0,
    Slight = 1, // ??????
    SeriousInjury = 2, // ????
    Critical = 3, // ????????
}

public enum HouseType
{
    ThermalHull = 1,
    House = 2,
    Stockpiles = 3,
    MedicalPost = 4,
    Laboratory = 5,
    SaleShop = 6,
    TownMission = 7,
    FightingArena = 8,
    Cookhouse = 9,
    Sawmill = 10,
    CoalMine = 11,
}


public enum PropertyType
{
    None = 0,
}

public enum TileEventType
{
    None = 0,
    Start = 1,
    End = 2,
    Event = 3,
    NormalItems = 4,
    SpecialItem = 5,
    Monster = 6,
}

public enum StoryEventType
{
    None = 0,
    Tutorial_1 = 1,
    Tutorial_2 = 2,
}

public enum IntroButtonType
{
    None = 0,
    NewGame = 1,
    Continue = 2,
    Exit = 3,
}

public enum DirectionType
{
    None = 0,
    Right = 1,
    Left = 2,
    Up = 3,
    Down = 4,
}

public enum RegionType
{
    None = 0,
    Outskirts = 1,
    Intersection = 2,
    Forest = 3,
    Park = 4,
    Hospital = 5,
    School = 6,
    Apartment = 7,
    Supermarket = 8,
    DepartmentStore = 9,
    Laundromat = 10,
    Restaurant = 11,
    Factory = 12,
    Tunnel = 13,
    Riverside = 14,
}