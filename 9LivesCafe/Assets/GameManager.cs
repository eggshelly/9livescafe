using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] customers;
    [SerializeField] private GameObject[] orders;
    [SerializeField] private int custLimit = 5;
    
    private int custCount = 0;
    private Queue activeNPC = new Queue();

    void Awake()
    {
        InvokeRepeating("AddCustomer", 1.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void AddCustomer()
    {
        if (custCount < custLimit)
        {
            //Chooses NPC customer at random and enqueue to activeNPC
            NPC newNPC = new NPC(customers[Random.Range(0, customers.Length)]);
            activeNPC.Enqueue(newNPC);

            //Places NPC game object into the scene at current place and inc cust count
            Instantiate(newNPC.npc, new Vector3(-5.5f, 0, custCount), transform.rotation * Quaternion.Euler(0f, 180f, 0f));
            custCount++;
        }
    }
}
