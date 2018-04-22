using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public float hitDurationStick = 0.1f;

    private float hitTime = 0.0f;
    private Transform hitObject = null;


	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hitObject != null)
        {
            hitTime += Time.deltaTime;
        }

        if (hitTime > hitDurationStick)
        {
            transform.parent = hitObject;
        }
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponentInParent<Controls>() != null)
        {
            hitObject = other.gameObject.transform;  
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponentInParent<Controls>() != null)
        {
            transform.parent = hitObject;
        }
    }

}
