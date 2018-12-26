using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildControl : MonoBehaviour {

    public GameObject DiaryInfo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // click the building show the diary information
    // just for test
    void Test()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit ray_cast_hit;

            if (Physics.Raycast(ray, out ray_cast_hit))
            {
                GameObject building = ray_cast_hit.collider.gameObject;
                if (building.tag == "shop") {
                    // open the diary
                    DiaryInfo.GetComponent<CanvasDiaryControl>().OpenDiary( gameObject.GetComponent<buildInfo>().DiaryPath );
                }
            }
        }
    }
}
