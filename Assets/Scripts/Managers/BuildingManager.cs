using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public class BuildingManager : MonoBehaviour
{
	List<Building> mBuildings = new List<Building>();

	void Start () 
	{
		loadBuildingsFromDisc();
	}

	//Loads all the buildings that the game will contain from a xml file
	void loadBuildingsFromDisc ()
	{
		XDocument xmlDoc = XDocument.Load ("BuildingGame_Data/Buildings.xml");

		mBuildings = xmlDoc.Descendants("building")
			.Select(be => new Building (
				(string)be.Element("name"),
				(int)be.Element("buildTime"),
				(int)be.Element("treeCost"),
				(int)be.Element("stoneCost"),
				(int)be.Element("goldCost"),
				(string)be.Element("description")))
				.ToList();
	}

	public List<Building> getBuildings ()
	{
		return mBuildings;
	}
}
