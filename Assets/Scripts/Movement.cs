using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 1000.0f;

        GetComponent<Rigidbody2D>().AddForce(new Vector2(x,0), ForceMode2D.Force);

        if (Input.GetButtonDown("Fire1") && Mathf.Approximately(GetComponent<Rigidbody2D>().velocity.y, 0))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500)*Time.deltaTime, ForceMode2D.Impulse);
        }

        
    }
}
