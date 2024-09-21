using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject robot;
    public GameObject uis;
    bool bot=true;
    Vector3 r_position;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bot==true) transform.position = new Vector3(robot.transform.position.x, robot.transform.position.y, -10);
    }

    public void full_screen()
    {
        bot = false;
        robot.GetComponent<character_move>().not_death(true,-1);
        r_position = new Vector3(robot.transform.position.x, robot.transform.position.y+1, robot.transform.position.z);
        robot.transform.position=new Vector3(100, 100, 0);
        int heigth = PlayerPrefs.GetInt("height"), width = PlayerPrefs.GetInt("width");
        if (heigth > width)
        {
            transform.position = new Vector3((width+1.25f) / 2, ((heigth+1.25f) / 2), (-1*Mathf.Tan(60f * (Mathf.PI / 180)) * (heigth)));
        }
        else
        {
            transform.position = new Vector3((width + 1.25f) / 2, ((heigth + 1.25f) / 2), (-1 * Mathf.Tan(60 * (Mathf.PI / 180)) * width));
        }
        uis.SetActive(false);
        Invoke("end", 2f);
    }
    void end() { robot.transform.position = r_position; bot = true;  uis.SetActive(bot); Invoke("true_end", 1.8f); }
    void true_end() { robot.GetComponent<character_move>().not_death(false,-1); }
   
    
}
