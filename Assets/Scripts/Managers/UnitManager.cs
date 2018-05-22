using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour 
{
	public List<GameObject> SelectedUnits = new List<GameObject>();
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void AddUnit (GameObject unit)
	{
		SelectedUnits.Add(unit);
	}
}
