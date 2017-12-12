using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskManager : MonoBehaviour 
{
	List<Worker> mWorkers = new List<Worker>();
	Queue<Task> mTasks = new Queue<Task>();
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	
	public void addWorker (Worker w)
	{
		mWorkers.Add(w);
	}

	//Adds a new task to the task queue and alerts the first free worker of this newly added task
	public void addTask (Task t)
	{
		mTasks.Enqueue(t);
		
		foreach (Worker w in mWorkers)
		{
			if (w.getActive() == false)
				w.alert();
		}
	}

	//Returns the first task in the queue if there is any, else returns null
	public Task getFirstTask ()
	{
		if (mTasks.Count > 0)
			return mTasks.Dequeue();
		else 
			return null;
	}
}
