using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CanvasDiaryControl : MonoBehaviour {

    public GameObject diary_info;
    public GameObject canvas_add;
    public GameObject canvas_new;
    public GameObject canvas_read;
    string building_path, diar_path, project_path;

    bool isOpenDiary;

    void Start()
    {
        // initialize
        project_path = diary_info.GetComponent<DiaryInfo>().ProjectDirectory;
        canvas_add.GetComponent<Canvas>().enabled = false;
        canvas_new.GetComponent<Canvas>().enabled = false;
        canvas_read.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        // just for test
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit ray_cast_hit;

            if (Physics.Raycast(ray, out ray_cast_hit))
            {
                GameObject building = ray_cast_hit.collider.gameObject;
                if ((building.tag.ToString() == "shop" || building.tag.ToString() == "school") && gameObject.GetComponent<DiaryInfo>().IsDiaryOpen == false)
                {
                    // open the diary
                    gameObject.GetComponent<CanvasDiaryControl>().OpenDiary(building.GetComponent<buildInfo>().BuildingFile);
                    gameObject.GetComponent<DiaryInfo>().BuildingFileNow = building.GetComponent<buildInfo>().BuildingFile;
                }
            }
        }
    }

    public void OpenDiary( string path )
    {
        gameObject.GetComponent<DiaryInfo>().IsDiaryOpen = true;
        diary_info.GetComponent<DiaryInfo>().BuildingFileNow = path;

        bool isDiary = false;
        string fileConetent;
        StreamReader sr;
        building_path = path;

        sr = new StreamReader(building_path);

        while( (fileConetent = sr.ReadLine()) != null)
        {
            if(fileConetent.IndexOf("diary") != -1)
            {
                isDiary = true;
                break;
            }
        }

        // open read diary canvas
        if (isDiary)
            ShowReadCanvas();
        // open add diary canvas
        else
            ShowAddCanvas();
    }

    public void ShowCanvas( GameObject canvas )
    {
        canvas.GetComponent<Canvas>().enabled = true;
        canvas.GetComponent<NormalCanvasControl>().BuildingPath = building_path;
    }

    public void ShowAddCanvas()
    {
        CloseAllCanvas();
        canvas_add.GetComponent<Canvas>().enabled = true;
        canvas_add.GetComponent<NormalCanvasControl>().BuildingPath = building_path;
    }

    public void ShowReadCanvas()
    {
        CloseAllCanvas();
        canvas_read.GetComponent<Canvas>().enabled = true;
        canvas_read.GetComponent<ReadCanvasControl>().LoadDiary();
        canvas_read.GetComponent<NormalCanvasControl>().BuildingPath = building_path;
    }

    public void ShowNewCanvasNew()
    {
        CloseAllCanvas();
        canvas_new.GetComponent<NewCanvasControl>().ShowCanvas();
        canvas_new.GetComponent<NewCanvasControl>().IsDiaryExit = false;
    }

    public void ShowNewCanvasAdd()
    {
        CloseAllCanvas();
        canvas_new.GetComponent<NewCanvasControl>().ShowCanvas();
        canvas_new.GetComponent<NewCanvasControl>().IsDiaryExit = true;
    }

    public void CloseAllCanvas()
    {
        canvas_add.GetComponent<Canvas>().enabled = false;
        canvas_new.GetComponent<Canvas>().enabled = false;
        canvas_read.GetComponent<Canvas>().enabled = false;
    }

    public void ExitCanvas()
    {
        CloseAllCanvas();
        gameObject.GetComponent<DiaryInfo>().IsDiaryOpen = false;
    }

    public GameObject GetCanvas( string canvas)
    {
        if (canvas == "read")
            return canvas_read;
        else if (canvas == "add")
            return canvas_add;
        else
            return canvas_new;
    }

    public GameObject CanvasNew
    {
        get
        {
            return canvas_new;
        }
    }

}
