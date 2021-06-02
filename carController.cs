using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class carController : MonoBehaviour
{
    float vert;
    float horiz;
    Transform cube_tr;
    Rigidbody cube_rb;
    int hp = 100;
    public Text hpText;
    int time = 25;
    public Text timerText;
    // Start is called before the first frame update
    void Timer()
    {
        time = time - 1;
        timerText.text = "Time:" + time;
    }
    void Start()
    {
        InvokeRepeating("Timer",1f,1f);
        cube_tr = GetComponent<Transform>();
        cube_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vert = Input.GetAxis("Vertical") * 1f;
        horiz = Input.GetAxis("Horizontal") * 0.5f;
        cube_rb.AddForce(cube_tr.forward * vert);
        cube_tr.Rotate(0,horiz,0);
        if(time == 0){
            SceneManager.LoadScene("scene2");
        }
        if(hp == 0){
            SceneManager.LoadScene("scene2");
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "enemy" )
        {
          hp = hp - 20;
          hpText.text = "HP:" + hp;
        }
        if(col.gameObject.tag == "end" )
        {
            SceneManager.LoadScene("scene3");
        }
    }
}
