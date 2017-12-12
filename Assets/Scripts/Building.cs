using UnityEngine;
using System.Collections;

public class Building
{
	string mName;
	int mBuildTime;
	int mTreeCost;
	int mStoneCost;
	int mGoldCost;
	string mDescription;

	GameObject mGameObject;
	Texture2D mIcon;
	
	string mGUIText;

	public Building (string name, int buildTime, int treeCost, int stoneCost, int goldCost, string description)
	{
		mName = name;
		mBuildTime = buildTime;
		mTreeCost = treeCost;
		mStoneCost = stoneCost;
		mGoldCost = goldCost;
		mDescription = description;

		mGUIText = mName + "\nTime to build: " + mBuildTime + "\nTree: " + mTreeCost + "\nStone: " + mStoneCost + "\nGold: " + mGoldCost + "\n\n" + mDescription;

		mGameObject = Resources.Load ("Buildings/" + name) as GameObject;
		if (mGameObject == null)
			Debug.LogError ("Internal Error: The gameobject for the " + name + " building can't be found. It should be located in the Resources/Buildings folder");
		mIcon = Resources.Load ("Icons/" + name) as Texture2D;
		if (mIcon == null)
			Debug.LogError ("Internal Error: The icon for the " + name + " building can't be found. It should be located in the Resources/Icons folder");
	}

	public string getName() {return mName;}
	public Texture2D getIcon() {return mIcon;}
	public GameObject getGameObject() {return mGameObject;}
	public int getBuildTime() {return mBuildTime;}
	public int getTreeCost() {return mTreeCost;}
	public int getStoneCost() {return mStoneCost;}
	public int getGoldCost() {return mGoldCost;}
	public string getGUIText() {return mGUIText;}
}
