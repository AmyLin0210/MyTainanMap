using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializCanvas : MonoBehaviour {

    public Canvas canvas_read, canvas_add;
	// Use this for initialization
	void Start () {
        canvas_read.enabled = false;
        canvas_add.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
