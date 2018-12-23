using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildInfo : MonoBehaviour {

    string diary_path;

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
}
