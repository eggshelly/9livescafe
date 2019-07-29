using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
   
    private CharacterController controller;
    private Animator anim;
    private Vector3 moveDir = Vector3.zero;

    public UnityEvent onInteraction;

    [Header("Player Movement Controls")]
    public float speed = 4f;
    public float rotSpeed = 80f;
    float rot = 0f;
    public float radarDistance = 1.5f;

    [Header("Player Keybinds, temp for testing)")]
    public KeyCode interaction = KeyCode.Space;
    public KeyCode toggleCombat = KeyCode.LeftShift;
    public KeyCode combatSlide = KeyCode.E;
    public KeyCode combatHit1 = KeyCode.F;
    public KeyCode combatHit2 = KeyCode.G;



    void Start()
    {
        //m_RigidBody = GetComponent<Rigidbody>;
        controller = GetComponent<CharacterController>();
        anim       = GetComponent<Animator>();
    }

    void Update()
    {
        move();
        interact();

        if (Input.GetKeyDown(combatHit1) && anim.GetBool("inCombat"))
            hit1();
        if (Input.GetKeyDown(combatHit2) && anim.GetBool("inCombat"))
            hit2();
        
        if (Input.GetKeyDown(toggleCombat))
            switchCombatMode();
        if (Input.GetKeyDown(combatSlide) && anim.GetBool("inCombat"))
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

    public void hit1()
    {
        anim.Play("Combat_punch1");//play it once
    }
    public void hit2()
    {
        anim.Play("Combat_punch2");//play it once
    }
    
    public void slide()
    {
        anim.Play("Combat_slide");
    }

    public void switchCombatMode()
    {
        bool combat = anim.GetBool("inCombat");
        anim.SetBool("inCombat", !combat);
        if (combat) //if incombat switch to idle
            anim.CrossFade("idle",0.1f);
        else
            anim.CrossFade("Combat_idle", 0.1f);
            
    }

    private void interact()
    {
        if (Input.GetKeyDown(interaction))    //TODO: delete/replace code with nontesting code
        {
            onInteraction.Invoke();
        }
    }
    public void switchHoldingItem()
    {
        //animation transition
        bool holding = anim.GetBool("holdingCafeItem");
        anim.SetBool("holdingCafeItem", !holding);
    }

    //Returns closest NPC if an NPC is near player.
    public CafeNPC closestCustomer()
    {
        CafeNPC closest = null;

        float tempDist = radarDistance;

        foreach ( CafeNPC npc in GameManager.instance.activeNPC)
        {
            Vector3 diff = (npc.npcObj.transform.position - GetComponent<Transform>().position);
            float curDistance = diff.sqrMagnitude;

            if (curDistance < tempDist)
            {
                closest = npc;
                tempDist = curDistance;
            }
        }

        return closest;
    }
}
