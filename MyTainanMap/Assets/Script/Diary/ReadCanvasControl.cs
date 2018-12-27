using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ReadCanvasControl : MonoBehaviour {

    List<string> diary_all_path = new List<string>();
    string building_path, diary_path, diary_image_path;
    public GameObject diary_info;
    public Text diary_date, diary_content;
    public Image diary_image;
    int diaryPage;

    public void LoadDiary()
    {
        building_path = diary_info.GetComponent<DiaryInfo>().BuildingFileNow;
        StreamReader sr = new StreamReader(building_path);

        string temp;
        while ((temp = sr.ReadLine()).IndexOf("diary") == -1) ;
        while ((temp = sr.ReadLine()) != null)
        {
            diary_all_path.Add(temp);
        }
        sr.Close();

        diaryPage = 0;
        diary_path = diary_all_path[0];
        sr = new StreamReader(diary_path);
        diary_date.text = sr.ReadLine();
        diary_content.text = sr.ReadLine();
        diary_image_path = sr.ReadLine();
        ShowImage();

        sr.Close();
    }

    void ShowImage()
    {
        if (diary_image_path != "no image")
        {
            byte[] fileDate;
            fileDate = File.ReadAllBytes(diary_image_path);
            Texture2D file_image = new Texture2D(100, 100);
            file_image.LoadImage(fileDate);
            diary_image.sprite = Sprite.Create(file_image, new Rect(0, 0, file_image.width, file_image.height), new Vector2(0.5f, 0.5f));
        }
        else
            diary_image.sprite = null;
    }

    public void NextDiary()
    {
        if( diaryPage + 1 < diary_all_path.Count)
        {
            diaryPage += 1;
            diary_path = diary_all_path[diaryPage];
            StreamReader sr = new StreamReader(diary_path);
            diary_date.text = sr.ReadLine();
            diary_content.text = sr.ReadLine();
            diary_image_path = sr.ReadLine();
            ShowImage();

            sr.Close();
        }
    }

    public void PreDiary()
    {
        if (diaryPage - 1 >= 0)
        {
            diaryPage -= 1;
            diary_path = diary_all_path[diaryPage];
            StreamReader sr = new StreamReader(diary_path);
            diary_date.text = sr.ReadLine();
            diary_content.text = sr.ReadLine();
            diary_image_path = sr.ReadLine();
            ShowImage();

            sr.Close();
        }
    }
}
