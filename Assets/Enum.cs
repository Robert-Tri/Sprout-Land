using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Variety : uint
{
    Seed,
    Product,
    Material,
}

public enum ShowType : uint
{
    None,
    CurrentValue,
    CurrentValueWithMaxValue,
    MaxValue,
    MinValue
}

public enum DropType : uint
{
    DropByThrown,
    DropWithMouse
}

public enum ItemShownType : uint
{
    All,
    Tool,
    Seed,
    Product,
    Material
}

public enum SetType : uint
{
    CurrentValue,
    MaxValue,
    MinValue
}
