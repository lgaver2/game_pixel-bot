using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class return1 : MonoBehaviour
{
    public GameObject bot;
    public void r()
    {
        Vector3 pos = bot.transform.position;
        PlayerPrefs.SetFloat("position" + 0, pos.x); PlayerPrefs.SetFloat("position" + 1, pos.y); 
        PlayerPrefs.Save();
        SceneManager.LoadScene("title_scene");
    }
}
