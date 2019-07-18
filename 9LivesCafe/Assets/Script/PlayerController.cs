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
        move();

        if (Input.GetKeyDown(KeyCode.F) && anim.GetBool("inCombat"))
            hit1();
        if (Input.GetKeyDown(KeyCode.G) && anim.GetBool("inCombat"))
            hit2();
        if (Input.GetKeyDown(KeyCode.E))    //TODO: delete/replace code with nontesting code
            testSwitchHoldingItem();
        if (Input.GetKeyDown(KeyCode.LeftShift))
            switchCombatMode();
        if (Input.GetKeyDown(KeyCode.Space) && anim.GetBool("inCombat"))
            slide();

    }

    void move()
    {

        if (Input.GetAxis("Vertical") != 0)
        {
            anim.SetInteger("walk", 1);
            moveDir = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);
        }
        else
        {
            anim.SetInteger("walk", 0);
            moveDir = new Vector3(0, 0, 0);
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        controller.Move(moveDir * Time.deltaTime);
    }

    void hit1()
    {
        anim.Play("Combat_punch1");//play it once
    }
    void hit2()
    {
        anim.Play("Combat_punch2");//play it once
    }
    
    void slide()
    {
        anim.Play("Combat_slide");
    }

    void switchCombatMode()
    {
        bool combat = anim.GetBool("inCombat");
        anim.SetBool("inCombat", !combat);
    }

    void testSwitchHoldingItem()
    {       //TODO: delete
        //testing code for animation transition
        bool holding = anim.GetBool("holdingCafeItem");
        anim.SetBool("holdingCafeItem", !holding);
    }

}
