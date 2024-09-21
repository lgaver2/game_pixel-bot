using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_color : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject robot;
    public GameObject pane;
    bool open = false;
    private void Start()
    {
        pane.SetActive(false);
    }
    byte[] color = { 255, 255, 255 };
    public void colos(string color_name)
    {
        color_nametovalue(color_name);
        robot.GetComponent<character_move>().color_set(color[0], color[1], color[2]);
    }
    public void openclose()
    {
        if (open == true)
        {
            pane.SetActive(false);
            open = false;
        }
        else
        {
            pane.SetActive(true);
            open = true;
        }
    }
    void color_nametovalue(string name)
    {
        if (name == "White")
        {
            color[0] = 255;
            color[1] = 255;
            color[2] = 255;
        }
        else if(name=="Silver")
        {
            color[0] = 192;
            color[1] = 192;
            color[2] = 192;
        }
        else if (name == "Gray")
        {
            color[0] = 128;
            color[1] = 128;
            color[2] = 128;
        }
        else if (name == "Black")
        {
            color[0] = 0;
            color[1] = 0;
            color[2] = 0;
        }
        else if (name == "Red")
        {
            color[0] = 255;
            color[1] = 0;
            color[2] = 0;
        }
        else if (name == "Maroon")
        {
            color[0] = 128;
            color[1] = 0;
            color[2] = 0;
        }
        else if (name == "Yellow")
        {
            color[0] = 255;
            color[1] = 255;
            color[2] = 0;
        }
        else if (name == "Olive")
        {
            color[0] = 128;
            color[1] = 128;
            color[2] = 0;
        }
        else if (name == "Lime")
        {
            color[0] = 0;
            color[1] = 255;
            color[2] = 0;
        }
        else if (name == "Green")
        {
            color[0] = 0;
            color[1] = 128;
            color[2] = 0;
        }
        else if (name == "Aqua")
        {
            color[0] = 0;
            color[1] = 255;
            color[2] = 255;
        }
        else if (name == "Teal")
        {
            color[0] = 0;
            color[1] = 128;
            color[2] = 128;
        }
        else if (name == "Blue")
        {
            color[0] = 0;
            color[1] = 0;
            color[2] = 255;
        }
        else if (name == "Navy")
        {
            color[0] = 0;
            color[1] = 0;
            color[2] = 128;
        }
        else if (name == "Fuchsia")
        {
            color[0] = 255;
            color[1] = 0;
            color[2] = 255;
        }
        else if (name == "Purple")
        {
            color[0] = 128;
            color[1] = 0;
            color[2] = 128;
        }
        else if (name == "Beige")
        {
            color[0] = 255;
            color[1] = 234;
            color[2] = 167;
        }
        else if (name == "Orange")
        {
            color[0] = 255;
            color[1] = 153;
            color[2] = 0;
        }
        else if (name == "Brown")
        {
            color[0] = 138;
            color[1] = 89;
            color[2] = 54;
        }
        else if (name == "Bige")
        {
            color[0] = 255;
            color[1] = 232;
            color[2] = 143;
        }
    }
}
