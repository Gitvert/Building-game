using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskManager : MonoBehaviour 
{
	private List<Worker> mWorkers = new List<Worker>();
	private Queue<BuildingTask> mBuildingTasks = new Queue<BuildingTask>();
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	
	public void AddWorker (Worker w)
	{
		mWorkers.Add(w);
	}

	//Adds a new task to the task queue and alerts the first free worker of this newly added task
	public void AddBuildingTask (BuildingTask t)
	{
        mBuildingTasks.Enqueue(t);
		
		foreach (Worker w in mWorkers)
		{
			if (w.GetActive() == false)
				w.Alert();
		}
	}

	//Returns the first task in the queue if there is any, else returns null
	public BuildingTask GetFirstBuildingTask ()
	{
		if (mBuildingTasks.Count > 0)
			return mBuildingTasks.Dequeue();
		
		return null;
	}
}
