using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    [SerializeField, Range(0, 1)] float m_moveSpeed = 0f;
    Animator m_animator;

    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        m_animator.SetFloat("Blend" , m_moveSpeed);
    }
}
