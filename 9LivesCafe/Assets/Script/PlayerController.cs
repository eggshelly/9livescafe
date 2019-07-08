using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //RigidBody m_RigidBody;
    CharacterController controller;
    Animator anim;

    Vector3 moveDir = Vector3.zero;

    public float speed    = 4f;
    public float rotSpeed = 80f;
    float rot = 0f;

    void Start()
    {
        //m_RigidBody = GetComponent<Rigidbody>;
        controller = GetComponent<CharacterController>();
        anim       = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {

        if (Input.GetAxis("Vertical") != 0)
        {
            anim.SetInteger("moveCondition", 1);
            moveDir = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);
        }
        else
        {
            anim.SetInteger("moveCondition", 0);
            moveDir = new Vector3(0, 0, 0);
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        controller.Move(moveDir * Time.deltaTime);
    }

}
