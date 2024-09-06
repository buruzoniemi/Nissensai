using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinctionJudgment : MonoBehaviour
{
    private bool contact = false;       //プレイヤーに触れているか触れていないか

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player")   //プレイヤーが重なっている時
        {
            contact = true;                     //プレイヤーに触れている

        }
    }


    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (contact == true)                    //プレイヤーが触れているとき
        {
            if (Input.GetKey(KeyCode.Space))    //スペースを押すとカブが消える
            {
                Destroy(this.gameObject);
            }
        }
    }
}
