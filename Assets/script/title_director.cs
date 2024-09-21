using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class title_director : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject load;
    public GameObject go;
    public List<GameObject> Panels;
    //public List<InputField> size;
    public List<TMP_InputField> size;
    bool[] open = { false, false };
    [SerializeField] int[] aire = new int[1];
    void Start()
    {
        Panels[0].SetActive(false);
        Panels[1].SetActive(false);
        if (PlayerPrefs.GetInt("new_game") == 0) load.SetActive(false);
    }

    public void open_panel(int num)
    {
        if (open[num] == true)
        {
            Panels[num].SetActive(false);
            open[num] = true;
        }
        else
        {
            Panels[num].SetActive(true);
            open[num] = false;
        }
    }

    public void new_game()
    {
        if(aire[0]>0 && aire[0] <= 50 && aire[1] > 0 && aire[1] <= 50)
        {
            PlayerPrefs.SetInt("height", aire[0]);
            PlayerPrefs.SetInt("width", aire[1]);
            PlayerPrefs.SetInt("mode", 1);
            go.GetComponent<ads>().ShowInterstitialAd();
        }
        else
        {
            Debug.Log("error");
        }
    }

    public void load_scene()
    {
        PlayerPrefs.SetInt("mode", 0);
        go.GetComponent<ads>().ShowInterstitialAd();
    }

    public void input_size(int num)
    {
        aire[num] = int.Parse(size[num].text);
    }
}
