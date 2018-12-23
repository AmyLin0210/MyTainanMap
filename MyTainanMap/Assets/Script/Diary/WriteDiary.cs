using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WriteDiary : MonoBehaviour {

    string filename;
	// Use this for initialization
	void Start () {
        filename = @"C:\Users\User\Documents\AmyLin\";
        if (Directory.Exists(filename))
            transform.position = new Vector3(1, 0, 2);
        else
            transform.position = new Vector3(1, 0, -1);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
