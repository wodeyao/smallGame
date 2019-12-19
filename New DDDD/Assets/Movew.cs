using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Movew: MonoBehaviour
{

    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    string state;
    public Vector3 ver = new Vector3(-12f, 10, 0);
    private Transform m_Transform;
    private Animator animation;
    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        animation = gameObject.GetComponent<Animator>();
        m_Transform.transform.position = ver;
    }
    void FixedUpdate()
    {
        MoveControl();
        Resert();
    }

    void MoveControl()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_Transform.Translate(Vector3.up * 0.1f, Space.Self);
            animation.Play("jump");
        }
        //if (Input.GetKey(KeyCode.S))
        //{
        //    m_Transform.Translate(Vector3.down * 0.1f, Space.Self);
        //}
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_Transform.Translate(Vector3.left * 0.1f, Space.Self);
            animation.Play("Run");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            m_Transform.Translate(Vector3.left * 0.1f, Space.Self);
            animation.Play("idle");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            m_Transform.Translate(Vector3.right * 0.1f, Space.Self);
            animation.Play("Run");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            m_Transform.Translate(Vector3.right * 0.1f, Space.Self);
            animation.Play("Run");
        }
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
        if (m_Transform.position.y <= -7)
        {
            m_Transform.transform.localPosition = ver;
            m_Transform.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

}
