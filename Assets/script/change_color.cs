using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_color : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject block;
    GameObject robot;
    GameObject B_director;
    byte[] color = { 255, 255, 255 };
    int position;
    void Start()
    {
        robot = GameObject.FindWithTag("bot");
        B_director = GameObject.Find("Box_generator");
    }

    // Update is called once per frame
    void Update()
    {
        //distance between equal to 1
        if(Mathf.Floor(Mathf.Sqrt(Mathf.Pow(gameObject.transform.position.x - robot.transform.position.x, 2) + Mathf.Pow(gameObject.transform.position.y - robot.transform.position.y, 2))) <= 2f)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(color[0], color[1], color[2], 100);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(color[0], color[1], color[2], 255);
        }
    }
    public void change(byte r, byte g, byte b)
    {
        if (Mathf.Floor(Mathf.Sqrt(Mathf.Pow(gameObject.transform.position.x - robot.transform.position.x, 2) + Mathf.Pow(gameObject.transform.position.y - robot.transform.position.y, 2))) <= 2f)
        {
            color[0] = r; color[1] = g; color[2] = b;
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(color[0], color[1], color[2], 255);
            B_director.GetComponent<box_creator>().save_color(color_to_number(color[0], color[1], color[2]), position);
            if (r==255 && g==255 && b==255) block.GetComponent<block>().trigger(true);
            else block.GetComponent<block>().trigger(false);
        }
    }

    public void default_color(int color, int pos)
    {
        number_to_color(color);
        position = pos;
    }

    void number_to_color(int num)
    {
        switch (num)
        {
            case 0:
                color[0] = 255;
                color[1] = 255;
                color[2] = 255;
                break;
            case 1:
                color[0] = 192;
                color[1] = 192;
                color[2] = 192;
                break;
            case 2:
                color[0] = 128;
                color[1] = 128;
                color[2] = 128;
                break;
            case 3:
                color[0] = 0;
                color[1] = 0;
                color[2] = 0;
                break;
            case 4:
                color[0] = 255;
                color[1] = 0;
                color[2] = 0;
                break;
            case 5:
                color[0] = 128;
                color[1] = 0;
                color[2] = 0;
                break;
            case 6:
                color[0] = 255;
                color[1] = 255;
                color[2] = 0;
                break;
            case 7:
                color[0] = 128;
                color[1] = 128;
                color[2] = 0;
                break;
            case 8:
                color[0] = 0;
                color[1] = 255;
                color[2] = 0;
                break;
            case 9:
                color[0] = 0;
                color[1] = 128;
                color[2] = 0;
                break;
            case 10:
                color[0] = 0;
                color[1] = 255;
                color[2] = 255;
                break;
            case 11:
                color[0] = 0;
                color[1] = 128;
                color[2] = 128;
                break;
            case 12:
                color[0] = 0;
                color[1] = 0;
                color[2] = 255;
                break;
            case 13:
                color[0] = 0;
                color[1] = 0;
                color[2] = 128;
                break;
            case 14:
                color[0] = 255;
                color[1] = 0;
                color[2] = 255;
                break;
            case 15:
                color[0] = 128;
                color[1] = 0;
                color[2] = 128;
                break;
            case 16:
                color[0] = 255;
                color[1] = 234;
                color[2] = 167;
                break;
            case 17:
                color[0] = 255;
                color[1] = 153;
                color[2] = 0;
                break;
            case 18:
                color[0] = 138;
                color[1] = 89;
                color[2] = 54;
                break;
            case 19:
                color[0] = 255;
                color[1] = 232;
                color[2] = 143;
                break;
            default:
                color[0] = 255;
                color[1] = 255;
                color[2] = 255;
                break;
        }
        if(color[0] != 255 || color[1] != 255 || color[2] != 255) Invoke("solid",0.5f);
    }

    int color_to_number(int r, int g, int b)
    {
        int num=0;
        if (r == 255 && g == 255 && b == 255)      num = 0;
        else if (r == 192 && g == 192 && b == 192) num = 1;
        else if (r == 128 && g == 128 && b == 128) num = 2;
        else if (r == 0 && g == 0 && b == 0)       num = 3;
        else if (r == 255 && g == 0 && b == 0)     num = 4;
        else if (r == 128 && g == 0 && b == 0)     num = 5;
        else if (r == 255 && g == 255 && b == 0)   num = 6;
        else if (r == 128 && g == 128 && b == 0)   num = 7;
        else if (r == 0 && g == 255 && b == 0)     num = 8;
        else if (r == 0 && g == 128 && b == 0)     num = 9;
        else if (r == 0 && g == 255 && b == 255)   num = 10;
        else if (r == 0 && g == 128 && b == 128)   num = 11;
        else if (r == 0 && g == 0 && b == 255)     num = 12;
        else if (r == 0 && g == 0 && b == 128)     num = 13;
        else if (r == 255 && g == 0 && b == 255)   num = 14;
        else if (r == 128 && g == 0 && b == 128)   num = 15;
        else if (r == 255 && g == 234 && b == 167) num = 16;
        else if (r == 255 && g == 153 && b == 0)   num = 17;
        else if (r == 138 && g == 89 && b == 54)   num = 18;
        else if (r == 255 && g == 232 && b == 143) num = 19;
        return num;
    }

    void solid()
    {
        block.GetComponent<block>().trigger(false);
    }
}
