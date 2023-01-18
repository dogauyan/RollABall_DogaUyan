using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CAMMovement : MonoBehaviour
{
    public Vector3 top;
    Vector3 origin;

    private void OnEnable()
    {
        top = GameObject.Find("top").transform.position;
        origin = transform.position - top;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = origin + GameObject.Find("top").transform.position;
    }
}
