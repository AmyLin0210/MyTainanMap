using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class test : MonoBehaviour, IPointerClickHandler {

    public GameObject diaryInfo;
    public Transform buildings;

    void Update()
    {
        // just for test
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit ray_cast_hit;

            if (Physics.Raycast(ray, out ray_cast_hit))
            {
                GameObject building = ray_cast_hit.collider.gameObject;

                if ((building.tag.ToString() == "shop" || building.tag.ToString() == "school") && diaryInfo.GetComponent<DiaryInfo>().IsDiaryOpen == false)
                {
                    // open the diary
                    // 這兩行code重要，要開日記就呼叫這兩行
                    // diaryInfo 是個 gameObject，叫做 Diary，只要有關日記的處理，就拉這個 gameObject 
                    diaryInfo.GetComponent<CanvasDiaryControl>().OpenDiary(building.GetComponent<buildInfo>().BuildingFile);
                    diaryInfo.GetComponent<DiaryInfo>().BuildingFileNow = building.GetComponent<buildInfo>().BuildingFile;
                }
            }
        }
    }
    public void OnPointerClick(PointerEventData e)
    {

        // 以下是可以新增 building 的 code
        GameObject haha = Instantiate(diaryInfo.GetComponent<DiaryInfo>().GetDiaryBuilding("shop"));
        haha.transform.position = new Vector3(0, 0, -5);
        haha.transform.parent = buildings;
        // diaryInfo 是個 gameObject，只要有關日記的處理，就拉這個 gameObject 
        // 下面這兩行超重要，用來儲存建築物的資訊到資料夾裡和初始化一些數據
        // 在固定建築物位置後使用
        haha.GetComponent<buildInfo>().DiaryInfo = diaryInfo;
        haha.GetComponent<buildInfo>().CreateNewFile();

    }
}
