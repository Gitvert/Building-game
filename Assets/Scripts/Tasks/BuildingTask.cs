using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTask : Task {

    float mDuration;
    Building mBuilding;

    public BuildingTask(Vector3 pos, Building building, Cell cell)
    {
        mPosition = pos;
        mDuration = building.getBuildTime();
        mBuilding = building;
        mCell = cell;
    }

    public float getDuration () {return mDuration;}
    public Building getBuilding () {return mBuilding;}
}
