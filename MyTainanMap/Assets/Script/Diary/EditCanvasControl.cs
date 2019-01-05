using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditCanvasControl : MonoBehaviour {

    public GameObject diaryInfo;
    public GameObject building;
    public GameObject player;
    public GameObject camera;
    public bool buildingMoving = false;

    private float speed = 2.0f;
    private float rotate = 1.0f;
    private Vector3 cameraStarting, cameraStartRotate;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (buildingMoving && !diaryInfo.transform.GetComponent<DiaryInfo>().IsDiaryOpen)
        {
            // handle moving keys
            if (Input.GetKey(KeyCode.W))
            {
                building.transform.position += Time.deltaTime * building.transform.forward * speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                building.transform.position += Time.deltaTime * -building.transform.forward * speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                building.transform.position += Time.deltaTime * building.transform.right * speed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                building.transform.position += Time.deltaTime * -building.transform.right * speed;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                building.transform.Rotate(Time.deltaTime * new Vector3(0, -30, 0) * rotate);
            }
            if (Input.GetKey(KeyCode.E))
            {
                building.transform.Rotate(Time.deltaTime * new Vector3(0, 30, 0) * rotate);
            }
            if (Input.GetKey(KeyCode.Z))
            {
                building.transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
            }
            if (Input.GetKey(KeyCode.X))
            {
                building.transform.localScale -= new Vector3(0.001f, 0.001f, 0.001f);
            }
        }
    }

    public void startEditing()
    {
        buildingMoving = true;
        player.GetComponent<controller>().moving = false;
        // record the camera position 
        cameraStarting = camera.transform.localPosition;
        cameraStartRotate = camera.transform.localEulerAngles;
        // change to the building's view
        camera.transform.parent = building.transform;
        camera.transform.localPosition = new Vector3(0, 5, -5);
        camera.transform.localEulerAngles = cameraStartRotate;
        camera.transform.LookAt(building.transform);
    }
    public void openDiary()
    {
        diaryInfo.GetComponent<CanvasDiaryControl>().OpenDiary(building.GetComponent<buildInfo>().BuildingFile);
        diaryInfo.GetComponent<DiaryInfo>().BuildingFileNow = building.GetComponent<buildInfo>().BuildingFile;
    }

    public void deleteBuilding()
    {
        diaryInfo.GetComponent<CanvasDiaryControl>().CloseAllCanvas();
        buildingMoving = false;
        player.GetComponent<controller>().moving = true;
        camera.transform.parent = player.transform;
        camera.transform.localPosition = cameraStarting;
        camera.transform.localEulerAngles = cameraStartRotate;


        GameObject.Destroy(building);
    }
    public void back()
    {
        diaryInfo.GetComponent<CanvasDiaryControl>().CloseAllCanvas();
        buildingMoving = false;
        player.GetComponent<controller>().moving = true;
        camera.transform.parent = player.transform;
        camera.transform.localPosition = cameraStarting;
        camera.transform.localEulerAngles = cameraStartRotate;

        diaryInfo.GetComponent<CanvasDiaryControl>().changeBuildingInfo(building);
    }
}
