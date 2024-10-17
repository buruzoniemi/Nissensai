using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullUpKabu : MonoBehaviour
{
    private const string ColliderTag = "kabu";
    private PlayerAnimation playerAnimation;
    

    void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(ColliderTag))
        {
            PlayPullUpKabuTimeLine();
        }
    }

    private void PlayPullUpKabuTimeLine()
    {
        if (InputManager.GetKey(KeyBoard.SpaceKey) || InputManager.GetKeyPad(PadButton.East))
        {

        }
    }
}
