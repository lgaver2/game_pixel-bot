using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_creator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int height;
    [SerializeField] int width;
    int[] box_color = new int[2*3];
    public List<GameObject> box;
    void Start()
    {
        int[] color;
        get_value();
        if (PlayerPrefs.GetInt("mode") == 0) color = load_color();
        else color = new_color();
        int sum=0;
        for (int i = 0; i < height + 2; i++)
        {
            for (int n = 0; n < width+2; n++)
            {
                if (n == 0 | n == width+1 | i == 0 | i == height+1)
                {
                    GameObject B = Instantiate(box[1]) as GameObject;
                    B.transform.position = new Vector2((n), i);
                }
                else
                {
                    GameObject B = Instantiate(box[0]) as GameObject;
                    B.GetComponent<change_color>().default_color(color[sum],sum);
                    B.transform.position = new Vector2((n), i);
                    sum += 1;
                }
            }
        }
    }

    int[] load_color()
    {
        int[] box_color = new int[height * width];
        for(int i=0; i< height * width; i++)
        {
            box_color[i] = PlayerPrefs.GetInt("color" + i);
        }
        return box_color;
    }
    int[] new_color()
    {
        int[] box_color = new int[height * width];
        for (int i = 0; i < height * width; i++)
        {
            box_color[i] = 0;
            PlayerPrefs.SetInt("color" + i,0);
        }
        PlayerPrefs.Save();
        return box_color;
    }

    public void save_color(int num, int pos)
    {
        PlayerPrefs.SetInt("color" + pos, num);
        PlayerPrefs.Save();
    }

    void get_value()
    {
        height = PlayerPrefs.GetInt("height");
        width = PlayerPrefs.GetInt("width");
    }
}
