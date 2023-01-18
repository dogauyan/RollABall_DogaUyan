using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_EndLevel : MonoBehaviour
{
    public GameObject Fin = null;
    public TMPro.TMP_Text FinPoint = null;
    public TMPro.TMP_Text FinTime = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "top") nextlevel();
    }

    void nextlevel()
    {
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1) 
        {
            S_UI st = FindObjectOfType<S_UI>();
            Stats.StatSave(st.collectible, st.time);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        else
        {
            //Game over
            S_UI su = FindObjectOfType<S_UI>();
            su.stop = true;
            FinPoint.text = ((PlayerPrefs.HasKey("Points")? PlayerPrefs.GetInt("Points") : 0) + su.collectible).ToString();
            int mint = (int)(((PlayerPrefs.HasKey("Time")? PlayerPrefs.GetFloat("Time") : 0) + su.time) / 60);
            int sect = (int)(((PlayerPrefs.HasKey("Time")? PlayerPrefs.GetFloat("Time") : 0) + su.time) % 60);
            FinTime.text = (mint < 10 ? "0" + mint.ToString() : mint.ToString()) + " : " + (sect < 10 ? "0" + sect.ToString() : sect.ToString());
            Fin.SetActive(true);

            GameObject.Find("top").GetComponent<Rigidbody>().velocity = Vector3.zero;
            GameObject.Find("top").GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            Destroy(GameObject.Find("top").GetComponent<Rigidbody>());

            FindObjectOfType<S_TOPMovement>().stop = true;
        }
    }

    public void fail()
    {
        S_UI su = FindObjectOfType<S_UI>();

        //float thi = PlayerPrefs.HasKey("TempTime") ? PlayerPrefs.GetFloat("TempTime") : 0;
        PlayerPrefs.SetFloat("TempTime", su.time);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void restart()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
