using UnityEngine;
using System.Collections;

public abstract class Task
{
	protected Vector3 mPosition;
	protected Cell mCell;
	
	public Vector3 getPosition () {return mPosition;}
	public Cell getCell () {return mCell;}
}
