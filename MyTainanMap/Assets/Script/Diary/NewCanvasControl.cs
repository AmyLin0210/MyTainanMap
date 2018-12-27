using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using UnityEngine.UI;

public class NewCanvasControl : MonoBehaviour {

    public Image diary_image;
    public Text  diary_date, diary_content;
    public GameObject diary_info;

    Texture2D file_image;
    string image_path;
    string diary_path;
    string building_path;
    bool   isDiaryExist = false;

    //[MenuItem("Custom/OpenFile")]
    public void AddImage()
    {
        string image_path = EditorUtility.OpenFilePanel("Open File Dialog", "D:\\", "Image Files(*.png; *.jpg; *.gif)| *.png; *.jpg; *.gif");
        Debug.Log(image_path);

        byte[] fileDate;

        if( image_path != null)
        {
            fileDate = File.ReadAllBytes(image_path);
            file_image = new Texture2D(100, 100);
            file_image.LoadImage(fileDate);
            diary_image.sprite = Sprite.Create(file_image, new Rect(0,0,file_image.width, file_image.height),new Vector2(0.5f, 0.5f));
        }
    }

    public void StoreDiary()
    {
        // check whether the user input date and content
        if (diary_date.text == "" || diary_content.text == "")
            return;

        StreamWriter sw;
        FileInfo finfo;
        bool isDiaryExist = false;
        string diary_file;
        int diaryNum;

        if (!isDiaryExist)
        {
            string path = diary_info.GetComponent<DiaryInfo>().ProjectDirectory + "Diary\\detail.txt";
            diaryNum = diary_info.GetComponent<DiaryInfo>().DiaryNum + 1;
            diary_info.GetComponent<DiaryInfo>().DiaryNum += 1;
            diary_file = diary_info.GetComponent<DiaryInfo>().ProjectDirectory + "Diary\\diary_" + diaryNum.ToString() + ".txt";
            finfo = new FileInfo(path);
            sw = finfo.CreateText();
            sw.WriteLine(diaryNum.ToString());
            sw.Flush();
            sw.Close();
        }
        else
            diary_file = diary_info.GetComponent<DiaryInfo>().DiaryFileNow;

        finfo = new FileInfo(diary_file);
        sw = finfo.CreateText();
        sw.WriteLine(diary_date.text);
        sw.WriteLine(diary_content.text);
        sw.Flush();
        sw.Close();

        building_path = diary_info.GetComponent<DiaryInfo>().BuildingFileNow;
        if (!isDiaryExist)
        {
            finfo = new FileInfo(building_path);
            sw = finfo.AppendText();
            sw.WriteLine("diary");
            sw.WriteLine(diary_file);
            sw.Flush();
            sw.Close();
        }

    }
}
