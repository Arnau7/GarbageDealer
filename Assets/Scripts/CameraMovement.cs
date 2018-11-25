using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Mouse Y") < 0 && transform.position.z < 0f && Input.GetMouseButton(0))
        {
            transform.Translate(0f, 0f, Input.GetAxis("Mouse Y") *-speed,Space.World);
        }else if(Input.GetAxis("Mouse Y") > 0 && transform.position.z >= -20f && Input.GetMouseButton(0))
        {
            transform.Translate(0f, 0f, Input.GetAxis("Mouse Y") * -speed, Space.World);
        }
        if (Input.GetMouseButton(0) && Input.GetAxis("Mouse X") < 0 && transform.position.x < 11f)
        {
            transform.Translate(Input.GetAxis("Mouse X") * -speed, 0f, 0, Space.World);
        }
        else if (Input.GetMouseButton(0) && Input.GetAxis("Mouse X") > 0 && transform.position.x >= -10)
        {
            transform.Translate(Input.GetAxis("Mouse X") * -speed, 0f,0f , Space.World);
        }
    }

}
