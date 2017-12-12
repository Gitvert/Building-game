using UnityEngine;
using System.Collections;

public class Task
{
	Vector3 mPosition;
	float mDuration;
	Building mBuilding;
	Cell mCell;
	
	public Task (Vector3 pos, Building building, Cell cell)
	{
		mPosition = pos;
		mDuration = building.getBuildTime();
		mBuilding = building;
		mCell = cell;
	}
	
	public Vector3 getPosition () {return mPosition;}
	public float getDuration () {return mDuration;}
	public Building getBuilding () {return mBuilding;}
	public Cell getCell () {return mCell;}
}
