using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearSave : MonoBehaviour
{
    void OnEnable()
    {
        PlayerPrefs.DeleteAll();
    }
}
