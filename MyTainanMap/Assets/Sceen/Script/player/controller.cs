using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            // handle moving keys
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Time.deltaTime * transform.forward * speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Time.deltaTime * -transform.forward * speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Time.deltaTime * transform.right * speed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Time.deltaTime * -transform.right * speed;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(Time.deltaTime * new Vector3(0, -10, 0) * rotate);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Time.deltaTime * new Vector3(0, 10, 0) * rotate);
            }
        }
    }

    public bool moving = true;
    public float rotate = 1.0f;
    public float speed = 1.0f;
    public Transform camera;
}