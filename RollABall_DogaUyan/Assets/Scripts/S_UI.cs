using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class S_UI : MonoBehaviour
{
    public TMP_Text yazi;
    public int collectible = 0;


    // Start is called before the first frame update
    void Start()
    {
        Score();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Score()
    {
        yazi.text = collectible.ToString();
    }
}
