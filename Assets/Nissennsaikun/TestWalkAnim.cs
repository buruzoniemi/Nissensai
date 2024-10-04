using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWalkAnim : MonoBehaviour
{
	private Vector3 pos;
	private Animator anim = null;
	void Start()
	{
		pos = transform.position;
		anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.W))
		{
			pos.z = transform.position.z + 0.01f;
			anim.SetBool("Run", true);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			pos.z = transform.position.z - 0.01f;
			anim.SetBool("Run", true);
		}
		else if (Input.GetKey(KeyCode.A))
		{
			pos.x = transform.position.x + 0.01f;
			anim.SetBool("Run", true);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			pos.x = transform.position.x - 0.01f;
			anim.SetBool("Run", true);
		}
		else
		{
			anim.SetBool("Run", false);
		}

		transform.position = pos;
	}
}
