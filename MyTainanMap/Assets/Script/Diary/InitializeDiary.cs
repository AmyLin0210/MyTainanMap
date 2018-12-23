﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InitializeDiary : MonoBehaviour {

    public Transform buildings;
    public string diary_directory;
    string diary_detailFile;
    int    building_totalNum;
	// Use this for initialization
	void Start () {

        string readFile;

        diary_detailFile = diary_directory + "detail.txt";
        // check if the map information file exixt
        if ( !Directory.Exists(diary_directory) )
            Directory.CreateDirectory(diary_directory);

        StreamReader sr;
        StreamWriter sw;
        FileStream fs;
        FileInfo   finfo = new FileInfo(diary_detailFile);
        if ( !finfo.Exists )
        {
            fs = finfo.Create();
            fs.Close();
            sw = new StreamWriter(diary_detailFile);
            sw.WriteLine("0");
            sw.Flush();
            sw.Close();
        }

        // initialize the map information
        gameObject.GetComponent<DiaryInfo>().DirectoryPath = diary_directory;

        sr = new StreamReader(diary_detailFile);

        // how many building
        readFile = sr.ReadLine();
        building_totalNum = int.Parse(readFile);
        gameObject.GetComponent<DiaryInfo>().BuildTotalNum = building_totalNum;
        sr.Close();

        // the building initialize
        string diary_file_path;
        string diary_file_information;
        string []file_building_position;
        GameObject diary_file_building;

        for ( int i = 1; i <= building_totalNum; ++i)
        {
            diary_file_path = diary_directory + "diary_" + i.ToString() + ".txt";  // the diary path
            sr = new StreamReader(diary_file_path);                              // open the file

            // set up the building 
            // the kind of the building
            diary_file_information = sr.ReadLine();
            diary_file_building = Instantiate(gameObject.GetComponent<DiaryInfo>().GetDiaryBuilding(diary_file_information));
            diary_file_building.transform.parent = buildings;
            // the position of the building
            diary_file_information = sr.ReadLine();
            if( diary_file_information.IndexOf( "position" ) != -1)
            {
                diary_file_information = diary_file_information.Substring(diary_file_information.IndexOf(":") + 1);
                diary_file_information = diary_file_information.Substring(1, diary_file_information.Length - 2 );
                file_building_position = diary_file_information.Split(',');
                diary_file_building.transform.position = new Vector3(
                    float.Parse(file_building_position[0]),
                    float.Parse(file_building_position[1]),
                    float.Parse(file_building_position[2]));
            }


            //end readfile
            sr.Close();
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}