using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour 
{
	public GameObject tile;
	public int mapSize;
	Cell[,] mCells;
	GameObject[,] mTiles;
	// Use this for initialization
	void Start () 
	{
		mCells = new Cell[mapSize,mapSize];
		mTiles = new GameObject[mapSize,mapSize];
		for (int i = 0; i < mapSize; i++)
		{
			for (int j = 0; j < mapSize; j++)
			{
				//mCells[i,j] = new Cell(i,j,tile);
				Instantiate(tile, new Vector3(i,0,j), Quaternion.Euler(0,0,0));
			}
		}
	}

	// Update is called once per frame
	void Update () 
	{
	
	}

	public Cell getCell(int x, int y)
	{
		return mCells[x,y];
	}
}
