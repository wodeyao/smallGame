using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Movew : MonoBehaviour
{
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    string state;
    public Vector3 ver = new Vector3(-12f, 10, 0);
    public Rigidbody rb;
    private Transform m_Transform;
    private Animator animation;
    public float jumpforce;

    void Start()
    {
        // rb.transform.position = ver;
        // m_Transform = gameObject.GetComponent<Transform>();
        // animation = gameObject.GetComponent<Animator>();
        rb.transform.localPosition = ver;
    }

    void FixedUpdate()
    {
        MoveControl();
        Resert();
    }

    void MoveControl()
    {
        float horizontalmove = Input.GetAxis("Horizontal");
        float facedircetion = Input.GetAxisRaw("Horizontal");
        // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
        Debug.LogError(horizontalmove);
        // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
        Debug.LogError(facedircetion);
        if (horizontalmove != 0)
        {
            rb.velocity = new Vector2(horizontalmove * speed * Time.deltaTime, rb.velocity.y);
        }

        if (facedircetion != 0)
        {
            rb.transform.localScale = new Vector3(facedircetion, 1, 1);
            // rb.transform.localPosition = new Vector3(horizontalmove * speed * rb.transform.localPosition.x, 1, 1);
        }

        //跳跃
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2( rb.velocity.x,jumpforce * Time.deltaTime);
        }

        // if (Input.GetKey(KeyCode.W))
        // {
        //     m_Transform.Translate(Vector3.up * 0.1f, Space.Self);
        //     animation.Play("jump");
        // }
        // //if (Input.GetKey(KeyCode.S))
        // //{
        // //    m_Transform.Translate(Vector3.down * 0.1f, Space.Self);
        // //}
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     m_Transform.Translate(Vector3.left * 0.1f, Space.Self);
        //     animation.Play("Run");
        // }
        // if (Input.GetKeyUp(KeyCode.A))
        // {
        //     m_Transform.Translate(Vector3.left * 0.1f, Space.Self);
        //     animation.Play("idle");
        // }
        // if (Input.GetKeyDown(KeyCode.D))
        // {
        //     m_Transform.Translate(Vector3.right * 0.1f, Space.Self);
        //     animation.Play("Run");
        // }
        // if (Input.GetKeyUp(KeyCode.D))
        // {
        //     m_Transform.Translate(Vector3.right * 0.1f, Space.Self);
        //     animation.Play("Run");
        // }
        //if (Input.GetKey(KeyCode.Q))
        //{
        //    m_Transform.Rotate(Vector3.up, 180.0f);
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    m_Transform.Rotate(Vector3.up, -180.0f);
        //}
        //m_Transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));
        //m_Transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y"));
    }

    void Resert()
    {
        if (rb.position.y <= -7)
        {
            rb.transform.localPosition = ver;
            // rb.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
}