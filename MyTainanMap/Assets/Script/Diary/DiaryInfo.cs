using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryInfo : MonoBehaviour {

    public GameObject buildings;
    public GameObject school, shop, restaurant;
    public Canvas diary_canvas;

    int build_totalNum;
    string directory_path;

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

    public int BuildTotalNum
    {
        get
        {
            return build_totalNum;
        }
        set
        {
            build_totalNum = value;
        }
    }

    public string DirectoryPath
    {
        get
        {
            return directory_path;
        }
        set
        {
            directory_path = value;
        }
    }
}
