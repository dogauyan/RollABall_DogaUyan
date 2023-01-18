using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class S_UI : MonoBehaviour
{
    public TMP_Text yazi;
    public TMP_Text Ttimer;
    public int collectible = 0;
    public float time = 0;

    public bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        //if (PlayerPrefs.HasKey("Points")) collectible = PlayerPrefs.GetInt("Points");
        //if (PlayerPrefs.HasKey("Time")) time = PlayerPrefs.GetFloat("Time");
        if (PlayerPrefs.HasKey("TempTime")) time = PlayerPrefs.GetFloat("TempTime");

        Score();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            time += Time.deltaTime;
            int mint = (int)(time / 60);
            int sect = (int)(time % 60);
            Ttimer.text = (mint < 10 ? "0" + mint.ToString(): mint.ToString()) + " : " + (sect < 10 ? "0" + sect.ToString(): sect.ToString());

        }

    }
    public void Score()
    {
        yazi.text = collectible.ToString();
    }
}
