using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buildingDropdown : MonoBehaviour {

    public Dropdown dropdown;
    public GameObject diaryInfo;
    public List<string> buildings = new List<string>() { "shop", "school", "restaurant", "monument1", "monument2", "monument3" , "bank", "park", "cinema" };

    // Use this for initialization
    void Start () {      
        dropdown.AddOptions(buildings);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void dropdownIndexChanged(int index) {
        diaryInfo.GetComponent<DiaryInfo>().chosenBuilding = buildings[index];
        Debug.Log(buildings[index]);
    }
}
