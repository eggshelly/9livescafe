using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject[] customers;
    [SerializeField] private GameObject[] orders;
    [SerializeField] private int custLimit = 5;
    
    private int custCount = 0;
    public Queue activeNPC = new Queue();

    void Awake()
    {
        if (instance == null)
            instance = this;
            
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
            //Chooses NPC customer obj at random and Places NPC game object into the scene at current place.
            GameObject newNPCobj = Instantiate(customers[Random.Range(0, customers.Length)], new Vector3(-5.5f, 0, custCount), transform.rotation * Quaternion.Euler(0f, 180f, 0f));

            //Creates new CafeNPC object and enqueues it to activeNPC.
            CafeNPC newNPC = new CafeNPC(newNPCobj, orders[Random.Range(0, orders.Length)]);
            activeNPC.Enqueue(newNPC);

            custCount++;
        }

        else
        {
            Debug.Log("Customer limit hit!");
        }
    }

    //returns first CafeNPC from activeNPC queue that fits state description. Returns null if there are no CafeNPC objects in that state.
    public CafeNPC firstCustomer(ProcessState state)
    {
        foreach (CafeNPC npc in GameManager.instance.activeNPC)
        {
            if (npc.state == state)
                return npc;
        }

        return null;
        
    }
}
