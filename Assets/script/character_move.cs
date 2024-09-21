using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_move : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip se;
    public GameObject panel;
    public List<GameObject> heart;
    public AudioClip voice;
    Rigidbody2D rigid;
    Animator animator;
    AudioSource aud;
    float jumpforce = 800.0f;
    float walkforce = 30f;
    float maxwalkforce = 2f;
    float threshold=0.2f;
    int key = 0;
    int life = 3;
    byte[] color = { 0, 0, 0 };
    float[] position = { 0, 0 };
    bool ground;
    bool cam;
    float life_time;
    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.aud = GetComponent<AudioSource>();
        panel.SetActive(false);
        if (PlayerPrefs.GetFloat("position" + 0) != 0)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("position" + 0), PlayerPrefs.GetFloat("position" + 1)+1.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumps();
        }

        //key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        float speedx = Mathf.Abs(this.rigid.velocity.x);

        if (speedx < this.maxwalkforce)
        {
            this.rigid.AddForce(transform.right * walkforce * key);
        }

        if (key != 0)
        {
            animator.SetTrigger("walk");
            transform.localScale = new Vector3(key* 0.08579002f, 0.08579002f, 1);
        }
        life_time += Time.deltaTime;
        pose_block();
    }

    void pose_block()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("block");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, Mathf.Infinity))
            {
                hit.transform.gameObject.GetComponent<change_color>().change(color[0], color[1], color[2]);
                aud.PlayOneShot(se);
            }
        }
    }

    public void color_set(byte r,byte g,byte b)
    {
        color[0] = r;
        color[1] = g;
        color[2] = b;
    }

    

    public void Move(int direction)
    {
        key = direction;
    }

    public void jumps()
    {
        if (rigid.velocity.y == 0)
        {
            animator.SetTrigger("jump");
            this.rigid.AddForce(transform.up * this.jumpforce);
            life_time = 0;
        }
    }
    public void up()
    {
        key = 0;
    }
    public void restart()
    {
        life = 3;
        for (int i = 0; i < 3; i++) heart[i].SetActive(true);
        panel.SetActive(false);
        life_time = 0;
    }
    void death()
    {
        if (position[0] - position[1] >3f&& life_time > 1.3f&&!cam)
        {
            life -= 1;
            heart[life].SetActive(false);
            life_time = 0;
            aud.PlayOneShot(voice);
            if (life == 0)
            {
                panel.SetActive(true);
            }
        }
    }
    public void not_death(bool d,float pos) { cam = d; position[0] = pos; }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        position[1] = transform.position.y;
        death();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        position[0] = transform.position.y;
    }
}
