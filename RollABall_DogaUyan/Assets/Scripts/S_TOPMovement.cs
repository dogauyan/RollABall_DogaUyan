using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TOPMovement : MonoBehaviour
{
    public Rigidbody rigtop;
    public float hiz;
    GameObject duzkamera;

    // Start is called before the first frame update
    void Start()
    {
        rigtop.maxAngularVelocity = hiz * 1.5f;
        duzkamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 yon = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            yon += duzkamera.transform.right; //new Vector3(1,0,0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            yon += duzkamera.transform.forward; //new Vector3(0, 0, 1));
        }

        if (Input.GetKey(KeyCode.S))
        {
            yon += -duzkamera.transform.right; //new Vector3(-1, 0, 0);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            yon += -duzkamera.transform.forward; //new Vector3(0, 0, -1);
        }

        yon = Vector3.Scale(yon, new Vector3(1, 0, 1)).normalized;
        yon *= hiz;

        rigtop.AddTorque(yon);

        if (yon == Vector3.zero && rigtop.angularVelocity != Vector3.zero)
        {
            rigtop.angularVelocity -= rigtop.angularVelocity / 10;
        }
    }
}
