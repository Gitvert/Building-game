using UnityEngine;
using System.Collections;

public class Worker : MonoBehaviour 
{
	public float MoveSpeed = 1;
	private UnitManager _unitManager;
	private TaskManager _taskManager;
	private bool _active = false;
	private Vector3 _target = new Vector3(0,0,0);
	private float _workDuration = 0;
	private float _workInitiated = 0;
	private BuildingTask _currentTask = null;
	// Use this for initialization
	private void Start () 
	{
		_unitManager = GameObjectHelper.getComponent<UnitManager>(GameObjectHelper.findInScene("Misc"));
		_taskManager = GameObjectHelper.getComponent<TaskManager>(GameObjectHelper.findInScene("Misc"));
		_taskManager.AddWorker(gameObject.GetComponent<Worker>());
	}
	
	void ResetWorker ()
	{
		_active = false;
		_workInitiated = 0;
		_currentTask = null;
		Alert();
	}
	
	public bool GetActive() {return _active;}
	
	// Update is called once per frame
	private void Update () 
	{
		//Moves a worker to a tile where a building will be constructed
		if (_active)
		{
			if (transform.position != _target)
				transform.position = Vector3.MoveTowards(transform.position, _target, Time.deltaTime * MoveSpeed);
			else
			{
				if (_workInitiated == 0)
					_workInitiated = Time.time;
				
				if (Time.time > _workInitiated + _workDuration)
				{
					_currentTask.getCell().AddBuilding(_currentTask.getBuilding());
					//When the building is completed the worker becomes idle and can recieve new tasks
					ResetWorker();
				}
			}	
		}
	}
	
	private void OnMouseDown ()
	{
		_unitManager.AddUnit(gameObject);
	}

	//This function is called from the task manager when a new task is added and this worker isn't active. When a task is completed the worker checks the task queue to see if there are any waiting tasks
	public void Alert ()
	{
		_currentTask = _taskManager.GetFirstBuildingTask();

		if (_currentTask == null)
		{
			return;
		}
		
		_active = true;
		_target = _currentTask.getPosition();
		_workDuration = _currentTask.getDuration();
	}
}
