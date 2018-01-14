using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuiController : MonoBehaviour 
{
	List<Building> mBuildings;
	BuildingManager mBuildingManager;
	GameManager mGameManager;
    ResourceManager mResourceManager;

	bool buildingGUIActive = false;
	static Building selectedBuilding = null;
	GUIStyle infoTextStyle = new GUIStyle();
	// Use this for initialization
	void Start () 
	{
		mBuildingManager = GameObjectHelper.getComponent<BuildingManager>(gameObject);
		mBuildings = mBuildingManager.getBuildings();

		mGameManager = GameObjectHelper.getComponent<GameManager>(gameObject);
        mResourceManager = GameObjectHelper.getComponent<ResourceManager>(gameObject);

        infoTextStyle.alignment = TextAnchor.UpperLeft;
		infoTextStyle.normal.textColor = Color.white;
		infoTextStyle.wordWrap = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.B))
		{
			buildingGUIActive = !buildingGUIActive;
			if (!buildingGUIActive)
			{
				selectedBuilding = null;
			}
		}
	}

	void OnGUI ()
	{	
		resourceGUI();
		if (buildingGUIActive)
			buildingGUI();
	}

	//The gui for selecting buildings
	void buildingGUI ()
	{
		GUI.Box(new Rect(0,0,50,50 * mBuildings.Count), "");
		
		//Adds all the buttons
		for (int i = 0; i < mBuildings.Count; i++)
		{
			if (GUI.Button (new Rect(5,5 + i * 50,40,40), new GUIContent(mBuildings[i].getIcon (), mBuildings[i].getName ())))
			{
				selectedBuilding = mBuildings[i];
			}
		}
		
		//Checks if a button is hovered by the mouse and if so displays information about that building
		foreach (Building b in mBuildings)
		{
			if (GUI.tooltip.CompareTo(b.getName()) == 0)
			{
				GUI.Box(new Rect(50,0,115,150),"");
				GUI.Box(new Rect(55,0,110,150), b.getGUIText(), infoTextStyle);
			}
		}
	}

	//Displays info about the current resources
	void resourceGUI ()
	{
		string resourceInfo = "Population: " + mGameManager.getCurrentPopulation().ToString() + "/" + mGameManager.getPopulationLimit().ToString() + "\t\tTree: " +
            mResourceManager.getTreeAmount().ToString() + "/" + mResourceManager.getTreeLimit().ToString();
		GUI.Box(new Rect(Screen.width-300, 0, 300, 25), "");
		GUI.Box(new Rect(Screen.width-295, 5, 295, 25), resourceInfo, infoTextStyle);
	}

	static public Building getSelectedBuilding ()
	{
		return selectedBuilding;
	}
}
