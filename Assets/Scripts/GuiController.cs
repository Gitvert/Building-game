using UnityEngine;
using System.Collections.Generic;


public class GuiController : MonoBehaviour
{
	
	private List<Building> _buildings;
	private BuildingManager _buildingManager;
	private GameManager _gameManager;
    private ResourceManager _resourceManager;

	private bool _buildingGuiActive = false;
	private static Building _selectedBuilding = null;
	private GUIStyle _infoTextStyle = new GUIStyle();
	// Use this for initialization
	private void Start () 
	{
		_buildingManager = GameObjectHelper.getComponent<BuildingManager>(gameObject);
		_buildings = _buildingManager.GetBuildings();

		_gameManager = GameObjectHelper.getComponent<GameManager>(gameObject);
        _resourceManager = GameObjectHelper.getComponent<ResourceManager>(gameObject);

        _infoTextStyle.alignment = TextAnchor.UpperLeft;
		_infoTextStyle.normal.textColor = Color.white;
		_infoTextStyle.wordWrap = true;
	}
	
	// Update is called once per frame
	private void Update () 
	{
		if (Input.GetKeyDown(KeyCode.B))
		{
			_buildingGuiActive = !_buildingGuiActive;
			if (!_buildingGuiActive)
			{
				_selectedBuilding = null;
			}
		}
		
		
	}

	private void OnGUI ()
	{	
		/*ResourceGui();
		if (_buildingGuiActive)
			BuildingGui();*/
	}

	//The gui for selecting buildings
	private void BuildingGui ()
	{
		GUI.Box(new Rect(0,0,50,50 * _buildings.Count), "");
		
		//Adds all the buttons
		for (int i = 0; i < _buildings.Count; i++)
		{
			if (GUI.Button (new Rect(5,5 + i * 50,40,40), new GUIContent(_buildings[i].GetIcon (), _buildings[i].GetName ())))
			{
				_selectedBuilding = _buildings[i];
			}
		}
		
		//Checks if a button is hovered by the mouse and if so displays information about that building
		foreach (var b in _buildings)
		{
			if (GUI.tooltip.CompareTo(b.GetName()) == 0)
			{
				GUI.Box(new Rect(50,0,115,150),"");
				GUI.Box(new Rect(55,0,110,150), b.GetGuiText(), _infoTextStyle);
			}
		}
	}

	//Displays info about the current resources
	private void ResourceGui ()
	{
		string resourceInfo = "Population: " + _gameManager.GetCurrentPopulation() + "/" + _gameManager.GetPopulationLimit() + "\t\tTree: " +
            _resourceManager.GetTreeAmount() + "/" + _resourceManager.GetTreeLimit();
		GUI.Box(new Rect(Screen.width-300, 0, 300, 25), "");
		GUI.Box(new Rect(Screen.width-295, 5, 295, 25), resourceInfo, _infoTextStyle);
	}

	public static Building GetSelectedBuilding ()
	{
		return _selectedBuilding;
	}
}
