using UnityEngine;
using Events;

public class Cell : MonoBehaviour 
{
	public enum Occupied {Empty, Building, Constructing, Stone, Gold, Forest, Food, Water};
	Occupied mOccupied = Occupied.Empty;
	GameObject mOccupyingObject = null;
	public Material mMaterial;

	private EventDispatcher _eventDispatcher;
	
	// Use this for initialization
	private void Start ()
	{
		_eventDispatcher = EventDispatcher.GetInstance();

		RandomizeNature();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	//Randomizes different nature objects to every tile
	private void RandomizeNature()
	{
		var randValue = Random.Range (0,100);

		if (randValue > 98)
		{
			AddNature (Resources.Load("Nature/Gold") as GameObject, Occupied.Gold);
			mOccupyingObject.GetComponent<Gold>().setOccupyingCell(this);
		}

		else if (randValue > 95)
		{
			AddNature (Resources.Load("Nature/Stone") as GameObject, Occupied.Stone);
			mOccupyingObject.GetComponent<Stone>().setOccupyingCell(this);
		}

		else if (randValue > 80)
		{
			AddNature (Resources.Load("Nature/Forest") as GameObject, Occupied.Forest);
			mOccupyingObject.GetComponent<Forest>().setOccupyingCell(this);
		}
	}

	//Instatiates a nature object to the cell
	private void AddNature(GameObject nature, Occupied occupyingType)
	{
		var spawnPosition = new Vector3(transform.position.x, 0 + nature.transform.localScale.y / 2, transform.position.z);
		mOccupyingObject = Instantiate(nature, spawnPosition, Quaternion.Euler(Vector3.zero)) as GameObject;
		mOccupied = occupyingType;
	}

	//Instantiates a building in the cell
	public void AddBuilding (Building building)
	{
		if (mOccupyingObject == null && mOccupied == Occupied.Constructing)
		{
			var spawnPosition = new Vector3(transform.position.x, 0 + building.GetGameObject().transform.localScale.y / 2, transform.position.z);
			mOccupyingObject = Instantiate(building.GetGameObject(), spawnPosition, Quaternion.Euler(Vector3.zero)) as GameObject;
            SetOccupationStatus(Occupied.Building);
		}
		else
			Debug.LogError("Internal Error: A request to place a building in an occupied cell was made, this should never happen");
	}

    public void SetOccupationStatus(Occupied occupied)
    {
        mOccupied = occupied;
    }

	//Highlights the cell with green or red depending on the status of the cell when the user hovers the cell with the mouse cursor and has a building selected from the buildngs menu
	private void OnMouseEnter ()
	{
		if (GuiController.GetSelectedBuilding() == null)
		{
			return;
		}

		gameObject.GetComponent<Renderer>().material.color = mOccupied == Occupied.Empty ? Color.green : Color.red;
	}

	private void OnMouseExit ()
	{
        gameObject.GetComponent<Renderer>().material = mMaterial;
	}

	//Issues a building task
	private void OnMouseDown ()
	{
		var selectedBuilding = GuiController.GetSelectedBuilding();
		if (selectedBuilding == null)
		{
			return;
		}
		if (mOccupied == Occupied.Empty)
		{
			//_gameManager.attemptBuildingTask(this);
			_eventDispatcher.AddEvent(new BuildOrderEvent(this, selectedBuilding));
		}
	}
}
