using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	int mPopulationLimit;
	int mCurrentPopulation;
    ResourceManager mResourceManager;
    TaskManager mTaskManager;

	// Use this for initialization
	private void Start () 
	{
        mResourceManager = GameObjectHelper.getComponent<ResourceManager>(GameObjectHelper.findInScene("Misc"));
        mTaskManager = GameObjectHelper.getComponent<TaskManager>(GameObjectHelper.findInScene("Misc"));
        mPopulationLimit = 10;
		//TODO: Change this to a dynamic solution
		mCurrentPopulation = 5;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public bool checkPopulationRoom() 
	{
		if (mCurrentPopulation < mPopulationLimit)
			return true;
		else
			return false;
	}

	public void increasePopulationLimit (int n)
	{
		mPopulationLimit += n;
	}

    public void attemptBuildingTask(Cell cell)
    {
        Building building = GuiController.GetSelectedBuilding();
        if (mResourceManager.RequestResourceUsage(building.GetTreeCost(), building.GetStoneCost(), building.GetGoldCost()))
        {
            cell.SetOccupationStatus(Cell.Occupied.Constructing);
            mTaskManager.AddBuildingTask(new BuildingTask(new Vector3(cell.transform.position.x, 1, cell.transform.position.z), GuiController.GetSelectedBuilding(), cell));
        }
    }

    #region getters
	public int getPopulationLimit() {return mPopulationLimit;}
	public int getCurrentPopulation() {return mCurrentPopulation;}
	#endregion
}
