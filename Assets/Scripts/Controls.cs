using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public float turnAmount = 20.0f;
    public float turnDeadZone = 0.01f;

    public float boostAmount = 20.0f;

    public GameObject startingPlayerObject;
    public Transform mainCamera;

	// Use this for initialization
	void Start ()
    {
        var pc = startingPlayerObject.GetComponent<IPlayerControllable>();
        pc.startControl();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 followPosition = new Vector3(startingPlayerObject.transform.position.x, startingPlayerObject.transform.position.y, mainCamera.transform.position.z);
        mainCamera.transform.position = followPosition;

        var rb = startingPlayerObject.GetComponent<Rigidbody2D>();

        var turnAxis = Input.GetAxis("Horizontal");

        if (Mathf.Abs(turnAxis) > turnDeadZone)
        {
            var turnValue = (turnAmount * Mathf.Abs(turnAxis) * -Mathf.Sign(turnAxis) * Time.deltaTime);
            startingPlayerObject.transform.Rotate(Vector3.forward, turnValue);
        }

        if (Input.GetButton("Fire1") || Input.GetAxis("Fire1") > turnDeadZone)
        {
            rb.AddForce(startingPlayerObject.transform.up * boostAmount * Time.deltaTime, ForceMode2D.Force);
        }

        if (Input.GetButton("Fire2") || Input.GetAxis("Fire2") > turnDeadZone)
        {
            rb.AddForce(-startingPlayerObject.transform.up * boostAmount * Time.deltaTime, ForceMode2D.Force);
        }

    }
}
