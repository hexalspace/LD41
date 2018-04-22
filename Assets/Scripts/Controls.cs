using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float turnAmount = 20.0f;
    public float turnDeadZone = 0.01f;

    public float boostAmount = 20.0f;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        var turnAxis = Input.GetAxis("Horizontal");

        if (Mathf.Abs(turnAxis) > turnDeadZone)
        {
            var turnValue = (turnAmount * Mathf.Abs(turnAxis) * -Mathf.Sign(turnAxis) * Time.deltaTime);
            transform.Rotate(Vector3.forward, turnValue);
        }

        if (Input.GetButton("Fire1") || Input.GetAxis("Fire1") > turnDeadZone)
        {
            rb.AddForce(transform.up * boostAmount * Time.deltaTime, ForceMode2D.Force);
        }

        if (Input.GetButton("Fire2") || Input.GetAxis("Fire2") > turnDeadZone)
        {
            rb.AddForce(-transform.up * boostAmount * Time.deltaTime, ForceMode2D.Force);
        }

    }
}
