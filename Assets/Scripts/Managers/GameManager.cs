using System;
using Events;
using UnityEngine;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

public class GameManager : MonoBehaviour, ISubscriber
{
	public Text PopulationText;
	
	private int _populationLimit;
	private int _currentPopulation = 0;
    private ResourceManager _resourceManager;
    private TaskManager _taskManager;
	private EventDispatcher _eventDispatcher;

	// Use this for initialization
	private void Start () 
	{
        _resourceManager = GameObjectHelper.getComponent<ResourceManager>(GameObjectHelper.findInScene("Misc"));
        _taskManager = GameObjectHelper.getComponent<TaskManager>(GameObjectHelper.findInScene("Misc"));
		_eventDispatcher = EventDispatcher.GetInstance();
		_eventDispatcher.Subscribe(this);
		
		IncreasePopulationLimit(10);
	}

	public bool CheckPopulationRoom()
	{
		return _currentPopulation < _populationLimit;
	}

	public void IncreasePopulationLimit(int n)
	{
		_populationLimit += n;
		UpdatePopulationText();
	}

	private void UpdatePopulationText()
	{
		PopulationText.text = string.Format("Population: {0}/{1}", _currentPopulation, _populationLimit);
	}

    private void AttemptBuildingTask(Cell cell, Building building)
    {
	    if (!_resourceManager.RequestResourceUsage(building.GetTreeCost(), building.GetStoneCost(), building.GetGoldCost()))
	    {
		    return;
	    }
	    
	    cell.SetOccupationStatus(Cell.Occupied.Constructing);
	    _taskManager.AddBuildingTask(new BuildingTask(
		    new Vector3(cell.transform.position.x, 1, cell.transform.position.z), GuiController.GetSelectedBuilding(), 
		    cell
		));
    }

    #region getters
	public int GetPopulationLimit() {return _populationLimit;}
	public int GetCurrentPopulation() {return _currentPopulation;}
	#endregion

	public void Notify(IEvent e)
	{
		switch (e.GetEventType())
		{
			case EventType.BuildOrder:
				var buildOrderEvent = e as BuildOrderEvent;
				Debug.Assert(buildOrderEvent != null, "buildOrderEvent != null");
				AttemptBuildingTask(buildOrderEvent.Cell, buildOrderEvent.Building);
				break;
			case EventType.GatherOrder:
				break;
			case EventType.MouseClick:
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}
}
