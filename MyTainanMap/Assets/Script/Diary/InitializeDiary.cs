using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class InitializeDiary : MonoBehaviour {

    public Transform buildings;
    string project_directory;
    int    building_num;
    int    diary_num;
    int    image_num;

	// Use this for initialization
	void Start () {

        string diary_imageFolder;
        string building_folder;
        string diary_folder;

        // find the my document
        System.Environment.SpecialFolder myDoc = System.Environment.SpecialFolder.MyDocuments;
        project_directory = System.Environment.GetFolderPath(myDoc)+"\\MyTainanMap\\";
        building_folder = project_directory + "Building\\";
        diary_folder = project_directory + "Diary\\";
        diary_imageFolder = project_directory + "Image\\";

        gameObject.GetComponent<DiaryInfo>().ProjectDirectory = project_directory;

        // check if the map information file exixt
        CheckDirectoryExist(project_directory );
        CheckDirectoryExist(diary_folder);
        CheckDirectoryExist(building_folder);
        CheckDirectoryExist(diary_imageFolder);

        // initialize and read the detail file
        gameObject.GetComponent<DiaryInfo>().BuildNum = DetailFile( building_folder );
        gameObject.GetComponent<DiaryInfo>().ImageNum = DetailFile( diary_imageFolder );
        gameObject.GetComponent<DiaryInfo>().DiaryNum = DetailFile( diary_folder );

        // the building initialize
        DirectoryInfo df = new DirectoryInfo( building_folder );//Assuming Test is your Folder
        FileInfo[] all_FileInfo = df.GetFiles("building*"); //Getting Text files
        string building_file_path;
        string diary_file_information;
        string[] file_building_position;
        GameObject diary_file_building;
        StreamReader sr;
        foreach (FileInfo file in all_FileInfo)
        {
            building_file_path = building_folder + file.Name;
            sr = new StreamReader(building_file_path);                              // open the file

            // set up the building 
            // the kind of the building
            diary_file_information = sr.ReadLine();
            diary_file_building = Instantiate(gameObject.GetComponent<DiaryInfo>().GetDiaryBuilding(diary_file_information));
            diary_file_building.transform.parent = buildings;
            diary_file_building.GetComponent<buildInfo>().BuildingFile = building_file_path;
            diary_file_building.GetComponent<buildInfo>().DiaryInfo = gameObject;

            // the position of the building
            diary_file_information = sr.ReadLine();
            if (diary_file_information.IndexOf("position") != -1)
            {
                diary_file_information = diary_file_information.Substring(diary_file_information.IndexOf(":") + 1);
                diary_file_information = diary_file_information.Substring(1, diary_file_information.Length - 2);
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

    void CheckDirectoryExist( string directory )
    {
        if (!Directory.Exists( directory ))
            Directory.CreateDirectory( directory );
    }

    int DetailFile( string folder_path)
    {
        int num;
        string file_path = folder_path + "detail.txt";
        StreamReader sr;
        StreamWriter sw;
        FileStream fs;
        FileInfo finfo = new FileInfo( file_path );
        if (!finfo.Exists)
        {
            fs = finfo.Create();
            fs.Close();
            sw = new StreamWriter( file_path );
            sw.WriteLine("0");
            sw.Flush();
            sw.Close();
            return 0;
        }
        else
        {
            sr = new StreamReader( file_path );
            string temp = sr.ReadLine();
            num = int.Parse(temp);
            sr.Close();
            return num;
        }
    }
}
