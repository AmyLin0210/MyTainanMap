using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buildingChooseButton : MonoBehaviour, IPointerClickHandler {

    public GameObject diaryInfo;
    public string buildingName;

    public void OnPointerClick(PointerEventData e)
    {
        diaryInfo.GetComponent<DiaryInfo>().chosenBuilding = buildingName;
    }
}
