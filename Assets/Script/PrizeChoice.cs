using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizeChoice : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;
    void Start()
    {
        if (button != null) button.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnButtonClick()
    {
        string name = button.gameObject.name;
        Gacha mc = GameObject.Find("Main Camera").GetComponent<Gacha>();
        if (name == "first") mc.rate = 1;
        if (name == "second") mc.rate = 2;
        if (name == "third") mc.rate = 3;
    }
}
