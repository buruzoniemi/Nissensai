using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    private bool bShift;

    // Start is called before the first frame update
    void Start()
    {
        bShift = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            bShift = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            bShift = false;
        }

        if(Input.GetKeyDown("0") && bShift == true)
        {
            SceneManager.LoadScene(0);
            bShift = false;
        }
    }
}
