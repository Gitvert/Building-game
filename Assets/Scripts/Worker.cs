using UnityEngine;
using System.Collections;

public class Worker : MonoBehaviour 
{
	public float mMoveSpeed = 1;
	UnitManager unitManager;
	TaskManager taskManager;
	bool mActive = false;
	Vector3 mTarget = new Vector3(0,0,0);
	float mWorkDuration = 0;
	float mWorkInitiated = 0;
	BuildingTask mCurrentTask = null;
	// Use this for initialization
	void Start () 
	{
		unitManager = GameObjectHelper.getComponent<UnitManager>(GameObjectHelper.findInScene("Misc"));
		taskManager = GameObjectHelper.getComponent<TaskManager>(GameObjectHelper.findInScene("Misc"));
		taskManager.addWorker(gameObject.GetComponent<Worker>());
	}
	
	void resetWorker ()
	{
		mActive = false;
		mWorkInitiated = 0;
		mCurrentTask = null;
		alert();
	}
	
	public bool getActive() {return mActive;}
	
	// Update is called once per frame
	void Update () 
	{
		//Moves a worker to a tile where a building will be constructed
		if (mActive)
		{
			if (transform.position != mTarget)
				transform.position = Vector3.MoveTowards(transform.position, mTarget, Time.deltaTime * mMoveSpeed);
			else
			{
				if (mWorkInitiated == 0)
					mWorkInitiated = Time.time;
				
				if (Time.time > mWorkInitiated + mWorkDuration)
				{
					mCurrentTask.getCell().addBuilding(mCurrentTask.getBuilding());
					//When the building is completed the worker becomes idle and can recieve new tasks
					resetWorker();
				}
			}	
		}
	}
	
	void OnMouseDown ()
	{
		unitManager.addUnit(gameObject);
	}

	//This function is called from the task manager when a new task is added and this worker isn't active. When a task is completed the worker checks the task queue to see if there are any waiting tasks
	public void alert ()
	{
		mCurrentTask = taskManager.getFirstBuildingTask();
		
		if (mCurrentTask != null)
		{
			mActive = true;
			mTarget = mCurrentTask.getPosition();
			mWorkDuration = mCurrentTask.getDuration();
		}
	}
}
