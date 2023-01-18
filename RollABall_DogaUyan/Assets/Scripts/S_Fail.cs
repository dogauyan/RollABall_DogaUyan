using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Fail : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "top") FindObjectOfType<S_EndLevel>().fail();
    }
}
