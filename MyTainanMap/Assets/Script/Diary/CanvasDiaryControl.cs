﻿using System.Collections;
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
        project_path = diary_info.GetComponent<DiaryInfo>().DirectoryPath;
        canvas_add.GetComponent<Canvas>().enabled = false;
        canvas_new.GetComponent<Canvas>().enabled = false;
        canvas_read.GetComponent<Canvas>().enabled = false;
    }

    public void OpenDiary( string path )
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
        canvas_read.GetComponent<NormalCanvasControl>().BuildingPath = building_path;
    }

    public void ShowNewCanvas()
    {
        CloseAllCanvas();
        canvas_new.GetComponent<Canvas>().enabled = true;
        canvas_new.GetComponent<NormalCanvasControl>().BuildingPath = building_path;
    }

    public void CloseAllCanvas()
    {
        canvas_add.GetComponent<Canvas>().enabled = false;
        canvas_new.GetComponent<Canvas>().enabled = false;
        canvas_read.GetComponent<Canvas>().enabled = false;
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
