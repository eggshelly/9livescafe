using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGreet : MonoBehaviour
{
    public GameObject player;
    private PlayerController pInstance;

    public float speed;
    public float maxDist = 10f;

    private CafeNPC npc = null;
    private RaycastHit hit;
    private float targetDist;
    

    void Awake()
    {
        pInstance = player.GetComponent<PlayerController>();
    }
    public void Update()
    {
        if (npc != null)
            Greet();            
    }

    void Greet()
    {
        //If there is a customer waiting near player
        //npc = pInstance.closestCustomer();

        Debug.Log("FOLLOW ME!");
        GameObject npcObj = npc.npcObj;

        var dist = (npcObj.transform.position - player.transform.position).magnitude;
        Debug.Log(dist);
        if (dist >= maxDist)
        {
            speed = 0.05f;
            npc.npcObj.transform.LookAt(player.transform);
            npcObj.GetComponent<Animator>().SetInteger("walk", 1);
            npcObj.transform.position = Vector3.MoveTowards(npcObj.transform.position, player.transform.position, speed);
        }
        else
        {
            speed = 0f;
            npc.npcObj.GetComponent<Animator>().SetInteger("walk", 0);
        }
        
    }

    public void checkGreet()
    {
        CafeNPC tNPC = pInstance.closestCustomer();
        if (tNPC != null && tNPC.state == ProcessState.WaitingForGreet);
        {
            npc = (CafeNPC)GameManager.instance.firstCustomer(ProcessState.WaitingForGreet);
            npc.npcObj.transform.LookAt(player.transform);
        }
    }

    void endGreet()
    {
        npc = null;
        npc.state = ProcessState.LookingAtMenu;
    }

}