using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Puan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "TagKapsul")
        {
            FindObjectOfType<S_UI>().collectible++;
            FindObjectOfType<S_UI>().Score();
            Destroy(other.gameObject);
        }
    }
}
