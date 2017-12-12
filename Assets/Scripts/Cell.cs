using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour 
{
	enum Occupied {Empty, Building, Constructing, Stone, Gold, Forest, Food, Water};
	Occupied mOccupied = Occupied.Empty;
	GameObject mOccupyingObject = null;
	public Material mMaterial;

	static TaskManager taskManager;
	static GameManager gameManager;
	
	static bool buildingSelected = false;


	static public void setBuildingSelected(bool status)
	{
		buildingSelected = status;
	}
	// Use this for initialization
	void Start ()
	{
		taskManager = GameObjectHelper.getComponent<TaskManager>(GameObjectHelper.findInScene("Misc"));
		gameManager = GameObjectHelper.getComponent<GameManager>(GameObjectHelper.findInScene("Misc"));

		randomizeNature();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	//Randomizes different nature objects to every tile
	private void randomizeNature()
	{
		int randValue = Random.Range (0,100);

		if (randValue > 98)
		{
			addNature (Resources.Load("Nature/Gold") as GameObject, Occupied.Gold);
			mOccupyingObject.GetComponent<Gold>().setOccupyingCell(this);
		}

		else if (randValue > 95)
		{
			addNature (Resources.Load("Nature/Stone") as GameObject, Occupied.Stone);
			mOccupyingObject.GetComponent<Stone>().setOccupyingCell(this);
		}

		else if (randValue > 80)
		{
			addNature (Resources.Load("Nature/Forest") as GameObject, Occupied.Forest);
			mOccupyingObject.GetComponent<Forest>().setOccupyingCell(this);
		}
	}

	//Instatiates a nature object to the cell
	private void addNature(GameObject nature, Occupied occupyingType)
	{
		Vector3 spawnPosition = new Vector3(transform.position.x, 0 + nature.transform.localScale.y / 2, transform.position.z);
		mOccupyingObject = Instantiate(nature, spawnPosition, Quaternion.Euler(Vector3.zero)) as GameObject;
		mOccupied = occupyingType;
	}

	//Instantiates a building in the cell
	public void addBuilding (Building building)
	{
		if (mOccupyingObject == null && mOccupied == Occupied.Constructing)
		{
			Vector3 spawnPosition = new Vector3(transform.position.x, 0 + building.getGameObject().transform.localScale.y / 2, transform.position.z);
			mOccupyingObject = Instantiate(building.getGameObject(), spawnPosition, Quaternion.Euler(Vector3.zero)) as GameObject;
			mOccupied = Occupied.Building;
		}
		else
			Debug.LogError("Internal Error: A request to place a building in an occupied cell was made, this should never happen");
	}

	//Highlights the cell with green or red depending on the status of the cell when the user hovers the cell with the mouse cursor and has a building selected from the buildngs menu
	void OnMouseEnter ()
	{
		if (buildingSelected)
		{
			//TODO: Change this to support the Occupied enum
			if (mOccupied == Occupied.Empty)
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            //else 
            //gameObject.renderer.material.color = Color.red;
        }
	}

	void OnMouseExit ()
	{
        gameObject.GetComponent<Renderer>().material = mMaterial;
	}

	//Issues a building task
	void OnMouseDown ()
	{
		if (buildingSelected)
		{
			//Temp fix for preventing several buldings being built on the same tile, needs to be modified so buildings can be built on tiles with nature
			if (mOccupied == Occupied.Empty)
				attemptBuildingTask();
		}
	}

	//Issues a new building task if there are enough resources available
	void attemptBuildingTask ()
	{
		Building building = GuiController.getSelectedBuilding();
		if (gameManager.requestResourceUsage(building.getTreeCost(), building.getStoneCost(),building.getGoldCost()))
		{
			mOccupied = Occupied.Constructing;
			taskManager.addTask(new Task(new Vector3(transform.position.x,1,transform.position.z), GuiController.getSelectedBuilding(), this));
		}
	}
}
