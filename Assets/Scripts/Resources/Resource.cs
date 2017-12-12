using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour 
{
	protected Cell mOccupyingCell;
	protected int mCurrentAmount;

	protected bool mSelected;
	protected float mLastMouseClick;
    protected string mDescription = string.Empty;
	// Use this for initialization
	protected void Start () 
	{
		mCurrentAmount = 5000;
		mSelected = false;
	}
	
	// Update is called once per frame
	protected void Update () 
	{
		//Deselects the resource when the left mouse button is pressed, if the resource is pressed when it is already selected it will be deselected and then selected again
		if (Input.GetMouseButtonDown (0))
		{
			if (mSelected == true && mLastMouseClick + 0.1f < Time.time)
				mSelected = false;
		}
	}

	public void setOccupyingCell (Cell cell)
	{
		mOccupyingCell = cell;
	}

	//Displays the GUI options for the resource when it is selected
	void OnGUI ()
	{
		if (mSelected)
		{
			GUI.Box(new Rect(0, Screen.height-50, 300, 50), mDescription);
			GUI.Button (new Rect(400,400,50,50), "Gather");
		}
	}

	protected void OnMouseDown ()
	{
		mSelected = true;
		mLastMouseClick = Time.time;
	}
}
