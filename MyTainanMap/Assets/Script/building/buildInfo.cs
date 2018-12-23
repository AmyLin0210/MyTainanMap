using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class buildInfo : MonoBehaviour {

    string diary_path;
    public GameObject diary_info;

    public void CreateNewFile()
    {
        int diary_num = diary_info.GetComponent<DiaryInfo>().BuildTotalNum + 1;
        string file_path = diary_info.GetComponent<DiaryInfo>().DirectoryPath + "diary_" + diary_num.ToString() + ".txt";
        diary_path = file_path;

        FileInfo finfo = new FileInfo(file_path);
        FileStream fs = finfo.Create();                           // create empty file of the building
        fs.Close();
        StreamWriter sw = new StreamWriter(file_path);
        sw.WriteLine(transform.tag);                              // the kind of building
        sw.WriteLine("position:" + transform.position.ToString());  // the position of building
        sw.Flush();
        sw.Close();

        diary_info.GetComponent<DiaryInfo>().BuildTotalNum += 1;
    }

    public string DiaryPath
    {
        get
        {
            return diary_path;
        }
        set
        {
            diary_path = value;
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
