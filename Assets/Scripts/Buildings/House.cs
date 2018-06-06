using UnityEngine;
using System.Collections;

public class House : MonoBehaviour 
{
	public int populationLimitIncrease = 5;
	GameManager mGameManager;
	// Use this for initialization
	void Start () 
	{
		mGameManager = GameObjectHelper.getComponent<GameManager>(GameObjectHelper.findInScene("Misc"));
		mGameManager.IncreasePopulationLimit(populationLimitIncrease);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
