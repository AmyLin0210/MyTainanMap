using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCanvasControl : MonoBehaviour {

    string diary_path, build_path;
    public void ShowCanvas( string path)
    {
        build_path = path;
        gameObject.GetComponent<Canvas>().enabled = true;
    }
}
