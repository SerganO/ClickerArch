using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelService
{
    ILevelView GetLevelViewForId(string id);
    ILevelModel GetLevelModelForId(string id);
}
