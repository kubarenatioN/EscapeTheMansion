using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Item, Door
}

public interface IItemCustomData
{
    string Name { get; set; }
}
