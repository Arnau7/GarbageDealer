using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, 10, 0),0.1f);
	}
}
