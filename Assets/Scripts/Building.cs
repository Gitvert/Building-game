using UnityEngine;
using System.Collections;

public class Building
{
	private readonly string _name;
	private readonly int _buildTime;
	private readonly int _treeCost;
	private readonly int _stoneCost;
	private readonly int _goldCost;

	private readonly GameObject _gameObject;
	private readonly Texture2D _icon;
	
	private readonly string _guiText;

	public Building (string name, int buildTime, int treeCost, int stoneCost, int goldCost, string description)
	{
		_name = name;
		_buildTime = buildTime;
		_treeCost = treeCost;
		_stoneCost = stoneCost;
		_goldCost = goldCost;

		_guiText = _name + "\nTime to build: " + _buildTime + "\nTree: " + _treeCost + "\nStone: " + _stoneCost + "\nGold: " + _goldCost + "\n\n" + description;

		_gameObject = Resources.Load ("Buildings/" + name) as GameObject;
		if (_gameObject == null)
			Debug.LogError ("Internal Error: The gameobject for the " + name + " building can't be found. It should be located in the Resources/Buildings folder");
		_icon = Resources.Load ("Icons/" + name) as Texture2D;
		if (_icon == null)
			Debug.LogError ("Internal Error: The icon for the " + name + " building can't be found. It should be located in the Resources/Icons folder");
	}

	public string GetName() {return _name;}
	public Texture2D GetIcon() {return _icon;}
	public GameObject GetGameObject() {return _gameObject;}
	public int GetBuildTime() {return _buildTime;}
	public int GetTreeCost() {return _treeCost;}
	public int GetStoneCost() {return _stoneCost;}
	public int GetGoldCost() {return _goldCost;}
	public string GetGuiText() {return _guiText;}
}
