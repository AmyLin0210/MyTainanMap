using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class buildInfo : MonoBehaviour {

    string building_file;
    public GameObject diary_info;

    public void Update ()
    {
    }

    public void CreateNewFile()
    {
        int diary_num = diary_info.GetComponent<DiaryInfo>().BuildNum + 1;
        building_file = diary_info.GetComponent<DiaryInfo>().ProjectDirectory + "Building\\building_" + diary_num.ToString() + ".txt";

        FileInfo finfo = new FileInfo(building_file);
        FileStream fs = finfo.Create();                           // create empty file of the building
        fs.Close();
        StreamWriter sw = new StreamWriter(building_file);
        sw.WriteLine(transform.tag);                              // the kind of building
        sw.WriteLine("position:" + transform.position.ToString());  // the position of building
        sw.WriteLine("scale:" + transform.localScale.ToString());
        sw.WriteLine("direction:" + transform.eulerAngles.ToString());
        sw.Flush();
        sw.Close();

        diary_info.GetComponent<DiaryInfo>().BuildNum += 1;
        ChangeBuildingDetailNum(diary_info.GetComponent<DiaryInfo>().BuildNum);
    }

    void ChangeBuildingDetailNum(int num )
    {
        string path = diary_info.GetComponent<DiaryInfo>().ProjectDirectory + "Building\\detail.txt";
        FileInfo finfo = new FileInfo(path);
        StreamWriter sw = finfo.CreateText();
        sw.WriteLine(num.ToString());
        sw.Flush();
        sw.Close();
    }

    public string BuildingFile
    {
        get
        {
            return building_file;
        }
        set
        {
            building_file = value;
        }
    }

    public GameObject DiaryInfo
    {
        set
        {
            diary_info = value;
        }
    }

}
