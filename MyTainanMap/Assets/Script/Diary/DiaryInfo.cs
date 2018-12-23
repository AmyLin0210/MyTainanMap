using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryInfo : MonoBehaviour {

    public GameObject buildings;
    public GameObject school;

    int build_totalNum;
    string directory_path;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject GetDiaryBuilding( string build_name )
    {
        if (build_name == "school")
            return school;
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
