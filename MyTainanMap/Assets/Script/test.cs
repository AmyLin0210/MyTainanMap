using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class test : MonoBehaviour, IPointerClickHandler {

    public GameObject diaryInfo;
    public Transform buildings;
    public void OnPointerClick(PointerEventData e)
    {

        // 以下是可以新增 building 的 code
        GameObject haha = Instantiate(diaryInfo.GetComponent<DiaryInfo>().GetDiaryBuilding("shop"));
        haha.transform.position = new Vector3(2, 0, 1);
        haha.transform.parent = buildings;
        haha.GetComponent<buildInfo>().DiaryInfo = diaryInfo;
        haha.GetComponent<buildInfo>().CreateNewFile();

    }
}
