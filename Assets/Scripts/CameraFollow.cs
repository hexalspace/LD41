using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform follow;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 followPosition = new Vector3(follow.position.x, follow.position.y, this.transform.position.z);
        this.transform.position = followPosition;
	}
}
