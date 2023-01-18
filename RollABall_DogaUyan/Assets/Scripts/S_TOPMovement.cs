using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TOPMovement : MonoBehaviour
{
    public Rigidbody rigtop;
    public float hiz;
    public float maxMultiplier = 1.5f;

    public float angl_damp = 10;
    public float accMultiplier = 5;
    public float accTime = 1;
    float Atimer = 0;

    GameObject duzkamera;
    public bool OnGround = true;

    public float Jumping = 25;
    public float jumpPower = 1;

    public bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        rigtop.maxAngularVelocity = hiz * maxMultiplier;
        duzkamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (stop) return;

        bool acced = false;
        if (Atimer > 0)
        {
            Atimer -= Time.deltaTime / accTime;
            if (Atimer < 0) Atimer = 0;
            if (Atimer > 1) Atimer = 1;
        }
        rigtop.maxAngularVelocity = Mathf.Lerp(1, accMultiplier, Atimer) * hiz * maxMultiplier;

        Vector3 yon = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            yon += duzkamera.transform.right; //new Vector3(1,0,0));
            if (!acced)
            {
                Atimer += Time.deltaTime * 2 / accTime;
                acced = true;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            yon += duzkamera.transform.forward; //new Vector3(0, 0, 1));
            if (!acced)
            {
                Atimer += Time.deltaTime * 2 / accTime;
                acced = true;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            yon += -duzkamera.transform.right; //new Vector3(-1, 0, 0);
            if (!acced)
            {
                Atimer += Time.deltaTime * 2 / accTime;
                acced = true;
            }
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            yon += -duzkamera.transform.forward; //new Vector3(0, 0, -1);
            if (!acced)
            {
                Atimer += Time.deltaTime * 2 / accTime;
                acced = true;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (OnGround)
            {
                Jump();
            }
        }

            yon = Vector3.Scale(yon, new Vector3(1, 0, 1)).normalized;
        yon *= hiz;

        rigtop.AddTorque(yon);

        if (yon == Vector3.zero && rigtop.angularVelocity != Vector3.zero)
        {
            rigtop.angularVelocity -= rigtop.angularVelocity / angl_damp;
        }
    }

    void Jump()
    {
        rigtop.AddExplosionForce(Mathf.Pow(Jumping, jumpPower), transform.position + new Vector3(0, -2, 0), 10);
    }


}
