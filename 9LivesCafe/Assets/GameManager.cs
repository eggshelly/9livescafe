using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] customers;
    [SerializeField] private GameObject[] orders;
    [SerializeField] private int custLimit = 5;
    
    private int custCount = 0;
    private NPC[] activeNPC;

    void Awake()
    {
        InvokeRepeating("AddCustomer", 3.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void AddCustomer()
    {
        if (custCount < custLimit)
        {
            //Chooses NPC customer at random and adds to activeNPC array customers[Random.Range(0, customers.Length)]
            activeNPC[activeNPC.Length - 1] = new NPC(customers[0]);
            NPC currentNPC = activeNPC[activeNPC.Length - 1];
            
            //Places NPC game object into the scene at current place and inc cust count
            Instantiate(currentNPC.npc, new Vector3(-5.5f, 0, custCount), transform.rotation * Quaternion.Euler(0f, 180f, 0f));
            custCount++;
        }
    }
}
