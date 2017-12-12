using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	int mTreeAmount;
	int mTreeLimit;
	int mStoneAmount;
	int mStoneLimit;
	int mGoldAmount;
	int mGoldLimit;
	int mPopulationLimit;
	int mCurrentPopulation;

	// Use this for initialization
	void Start () 
	{
		mTreeAmount = 10;
		mTreeLimit = 1000;
		mStoneAmount = 10;
		mStoneLimit = 1000;
		mGoldAmount = 10;
		mGoldLimit = 1000;
		mPopulationLimit = 10;
		//TODO: Change this to a dynamic solution
		mCurrentPopulation = 5;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	//Checks if there are enough resources for a specific task
	public bool requestResourceUsage (int tree, int stone, int gold)
	{
		//If there are enough resources the caller is notified and the resources gets removed
		if (tree <= mTreeAmount && stone <= mStoneAmount && gold <= mGoldAmount)
		{
			mTreeAmount -= tree;
			mStoneAmount -= stone;
			mGoldAmount -= gold;
			return true;
		}
		return false;
	}

	public bool checkPopulationRoom() 
	{
		if (mCurrentPopulation < mPopulationLimit)
			return true;
		else
			return false;
	}

	public void increasePopulationLimit (int n)
	{
		mPopulationLimit += n;
	}

	#region getters
	public int getTreeAmount() {return mTreeAmount;}
	public int getTreeLimit() {return mTreeLimit;}
	public int getStoneAmount() {return mStoneAmount;}
	public int getStoneLimit() {return mStoneLimit;}
	public int getGoldAmount() {return mGoldAmount;}
	public int getGoldLimit() {return mGoldLimit;}
	public int getPopulationLimit() {return mPopulationLimit;}
	public int getCurrentPopulation() {return mCurrentPopulation;}
	#endregion
}
