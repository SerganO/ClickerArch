using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonLevelService: ILevelService
{

    public ILevelModel GetLevelModelForId(string id)
    {
        return new CommonLevelModel(id);
    }

    public ILevelView GetLevelViewForId(string id)
    {
        return new CommonLevelView(id);
    }
}
