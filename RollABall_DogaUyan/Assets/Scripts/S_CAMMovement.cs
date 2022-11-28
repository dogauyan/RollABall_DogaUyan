using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CAMMovement : MonoBehaviour
{
    Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        origin = gameObject.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.position = origin + GameObject.Find("top").transform.position;
    }
}
