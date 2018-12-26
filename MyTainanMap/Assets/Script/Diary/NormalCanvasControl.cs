using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCanvasControl : MonoBehaviour {

    string building_path;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowCanvas( string path)
    {
        gameObject.GetComponent<Canvas>().enabled = true;
        gameObject.GetComponent<NormalCanvasControl>().BuildingPath = path;
    }

    public string BuildingPath
    {
        get
        {
            return building_path;
        }
        set
        {
            building_path = value;
        }
    }
}
