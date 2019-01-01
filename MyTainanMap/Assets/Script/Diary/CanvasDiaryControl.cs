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
    public GameObject canvas_edit;
    public GameObject player;
    string building_path, diar_path, project_path;

    bool isOpenDiary;

    void Start()
    {
        // initialize
        project_path = diary_info.GetComponent<DiaryInfo>().ProjectDirectory;
        canvas_edit.GetComponent<Canvas>().enabled = false;
        canvas_add.GetComponent<Canvas>().enabled = false;
        canvas_new.GetComponent<Canvas>().enabled = false;
        canvas_read.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
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

    public void ShowEditCanvas()
    {
        CloseAllCanvas();
        canvas_edit.GetComponent<Canvas>().enabled = true;
    }

    public void ShowEditCanvas(GameObject building)
    {
        CloseAllCanvas();
        canvas_edit.GetComponent<Canvas>().enabled = true;
        canvas_edit.GetComponent<EditCanvasControl>().building = building;
        canvas_edit.GetComponent<EditCanvasControl>().startEditing();
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
        canvas_edit.GetComponent<Canvas>().enabled = false;
        canvas_add.GetComponent<Canvas>().enabled = false;
        canvas_new.GetComponent<Canvas>().enabled = false;
        canvas_read.GetComponent<Canvas>().enabled = false;        
    }

    public void ExitCanvas()
    {
        CloseAllCanvas();
        // back to Edit Canvas
        ShowEditCanvas();
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

    public void changeBuildingInfo(GameObject building)
    {
        string buildingFile = building.GetComponent<buildInfo>().BuildingFile;
        StreamReader sr = new StreamReader(buildingFile);
        string fileContent = "";
        string temp;

        fileContent += building.tag.ToString() + "\r\n";
        fileContent += "position:" + building.transform.position.ToString() + "\r\n" ;

        temp = sr.ReadLine();
        while (temp == null || temp.LastIndexOf("diary") != -1)
            temp = sr.ReadLine();

        if (temp.IndexOf("diary") != -1)
        {
            fileContent += temp;
            while ((temp = sr.ReadLine()) != null)
            {
                fileContent += temp;
            }
        }

        sr.Close();

        FileInfo finfo = new FileInfo(buildingFile);
        StreamWriter sw = finfo.CreateText();
        sw.Write(fileContent);

        sw.Flush();
        sw.Close();

    }
}
