using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPanel;
    public Text message;
    
    // Start is called before the first frame update
    void Start()
    {
        popupPanel.SetActive(false);
    }
    
    public void ShowPopup(string msg)
    {
        message.text = msg;
        popupPanel.SetActive(true);
    }

    public void HidePopup()
    {
        popupPanel.SetActive(false);
    }
}
