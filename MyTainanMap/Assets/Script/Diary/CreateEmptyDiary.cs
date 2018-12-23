using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateEmptyDiary : MonoBehaviour {

    public GameObject diary_info;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateNewFile()
    {
        int diary_num = diary_info.GetComponent<DiaryInfo>().BuildTotalNum + 1;
        string file_path = diary_info.GetComponent<DiaryInfo>().DirectoryPath + "diary_" + diary_num.ToString() + ".txt";
        gameObject.GetComponent<buildInfo>().DiaryPath = file_path;

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
}
