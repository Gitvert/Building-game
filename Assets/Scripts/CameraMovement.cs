using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
	public float speed = 10;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 dir = Vector3.zero;
		if (Input.GetAxis("Horizontal") > 0)
			dir =  -Vector3.left * Time.deltaTime * speed;
		
		if (Input.GetAxis("Horizontal") < 0)
			dir = Vector3.left * Time.deltaTime * speed;
		
		if (Input.GetAxis("Vertical") > 0)
			dir = Vector3.forward * Time.deltaTime * speed;
		
		if (Input.GetAxis("Vertical") < 0)
			dir = -Vector3.forward * Time.deltaTime * speed;
		
		if (Input.GetAxis("Zoom") < 0 && transform.position.y < 20)
			dir = Vector3.up * Time.deltaTime * speed;

		if (Input.GetAxis("Zoom") > 0 && transform.position.y > 5)
			dir = -Vector3.up * Time.deltaTime * speed;
		
//		if (Input.GetAxis("Rotate") < 0)
//			transform.Rotate(0,1,0, Space.World);
//		
//		if (Input.GetAxis("Rotate") > 0)
//			transform.Rotate(0,-1,0, Space.World);
		
		transform.Translate (dir, Space.World);
	}
}
