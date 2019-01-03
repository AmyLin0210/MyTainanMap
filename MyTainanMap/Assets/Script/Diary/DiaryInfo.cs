using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DiaryInfo : MonoBehaviour {

    public GameObject buildings;
    public GameObject school, shop, restaurant;
    public Canvas diary_canvas;
    public string chosenBuilding = "shop";

    int    build_num, diary_num, image_num;
    string project_directory;
    string building_file_now;
    string diary_file_now;
    bool   isDiaryOpen = false;

    public GameObject GetDiaryBuilding( string build_name )
    {
        if (build_name == "school")
            return school;
        else if (build_name == "shop")
            return shop;
        else if (build_name == "restaurant")
            return restaurant;
        else
            return null;
    }



    public int BuildNum
    {
        get
        {
            return build_num;
        }
        set
        {
            build_num = value;
        }
    }

    public int ImageNum
    {
        get
        {
            return image_num;
        }
        set
        {
            image_num = value;
        }
    }

    public int DiaryNum
    {
        get
        {
            return diary_num;
        }
        set
        {
            diary_num = value;
        }
    }

    public string ProjectDirectory
    {
        get
        {
            return project_directory;
        }
        set
        {
            project_directory = value;
        }
    }

    public string BuildingFileNow
    {
        get
        {
            return building_file_now;
        }
        set
        {
            building_file_now = value;
        }
    }

    public string DiaryFileNow
    {
        get
        {
            return diary_file_now;
        }
        set
        {
            diary_file_now = value;
        }
    }

    public bool IsDiaryOpen
    {
        get
        {
            return isDiaryOpen;
        }
        set
        {
            isDiaryOpen = value;
        }
    }
}
