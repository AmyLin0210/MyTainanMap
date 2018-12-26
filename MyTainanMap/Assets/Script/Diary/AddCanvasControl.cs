using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCanvasControl : MonoBehaviour {

    public GameObject diary_info;
    string diary_path, build_path;
    
    void ShowNewCanvas()
    {
        diary_info.GetComponent<CanvasDiaryControl>().ShowCanvas( diary_info.GetComponent<CanvasDiaryControl>().CanvasNew );
        gameObject.GetComponent<Canvas>().enabled = false;
    }

    
}
