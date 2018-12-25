using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CanvasDiaryControl : MonoBehaviour {

    public GameObject diary_info;
    public GameObject canvas_add;
    public Canvas canvas_new;
    public GameObject canvas_read;
    string building_path, diar_path, project_path;

    bool isOpenDiary;

    void Start()
    {
        project_path = diary_info.GetComponent<DiaryInfo>().DirectoryPath;
    }

    void OpenDiary( string path )
    {
        bool isDiary = false;
        string fileConetent;
        StreamReader sr;
        building_path = path;

        sr = new StreamReader(building_path);

        while( (fileConetent = sr.ReadLine()) != null)
        {
            if(fileConetent == "diary")
            {
                isDiary = true;
                break;
            }
        }

        // open read diary canvas
        if (isDiary)
            canvas_read.GetComponent<AddCanvasControl>().ShowCanvas(building_path);
        // open add diary canvas
        else
            canvas_add.GetComponent<AddCanvasControl>().ShowCanvas(building_path);
    }


}
