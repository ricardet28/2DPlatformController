using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPlayer : MonoBehaviour {

	private float xdis, ydis;
	public int numRays;

	// Use this for initialization
	void Start () {
		Renderer rend = GetComponent<Renderer> ();
		xdis = rend.bounds.size.x;
		ydis = rend.bounds.size.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 bottomlefttip = new Vector2 (transform.position.x - xdis / 2, transform.position.y - ydis / 2);

		for (int i = 0; i < numRays; i++){
			Debug.DrawLine (bottomlefttip + new Vector2 ((xdis / (numRays - 1)) * i, 0), bottomlefttip + new Vector2 ((xdis / (numRays - 1)) * i, -0.05f), Color.green);
			RaycastHit2D rayosDown = Physics2D.Raycast (bottomlefttip + new Vector2 ((xdis / (numRays - 1)) * i, 0), new Vector2 (0, -1), 0.05f);

			if (rayosDown)
				print ("COLISION INFERIOR");
		}
	}
}
