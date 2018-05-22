using UnityEngine;

public class Grid : MonoBehaviour 
{
	public GameObject Tile;
	public int MapSize;
	private Cell[,] _cells;
	private GameObject[,] _tiles;
	// Use this for initialization
	private void Start () 
	{
		_cells = new Cell[MapSize,MapSize];
		_tiles = new GameObject[MapSize,MapSize];
		for (var i = 0; i < MapSize; i++)
		{
			for (var j = 0; j < MapSize; j++)
			{
				//mCells[i,j] = new Cell(i,j,tile);
				Instantiate(Tile, new Vector3(i,0,j), Quaternion.Euler(0,0,0));
			}
		}
	}

	// Update is called once per frame
	void Update () 
	{
	
	}

	public Cell getCell(int x, int y)
	{
		return _cells[x,y];
	}
}
