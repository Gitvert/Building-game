using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public class BuildingManager : MonoBehaviour
{
	private List<Building> _buildings = new List<Building>();

	private void Start () 
	{
		LoadBuildingsFromDisc();
	}

	//Loads all the buildings that the game will contain from a xml file
	private void LoadBuildingsFromDisc ()
	{
		var xmlDoc = XDocument.Load ("BuildingGame_Data/Buildings.xml");

		_buildings = xmlDoc.Descendants("building")
			.Select(be => new Building (
				(string)be.Element("name"),
				(int)be.Element("buildTime"),
				(int)be.Element("treeCost"),
				(int)be.Element("stoneCost"),
				(int)be.Element("goldCost"),
				(string)be.Element("description")))
				.ToList();
	}

	public List<Building> GetBuildings ()
	{
		return _buildings;
	}
}
