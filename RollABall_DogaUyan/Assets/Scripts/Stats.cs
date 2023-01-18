using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Stats
{
    static public void StatSave(int point, float time)
    {
        int points = 0;
        float Wholetime = 0;
        if (PlayerPrefs.HasKey("Points")) 
        {
            points = PlayerPrefs.GetInt("Points");
        }

        if (PlayerPrefs.HasKey("Time"))
        {
            Wholetime = PlayerPrefs.GetFloat("Time");
        }

        PlayerPrefs.SetInt("Points", points + point);
        PlayerPrefs.SetFloat("Time", Wholetime + time);

        PlayerPrefs.DeleteKey("TempTime");
    }
}
