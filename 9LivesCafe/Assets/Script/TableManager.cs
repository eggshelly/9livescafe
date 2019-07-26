using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    private bool playerInRange = false;
    [SerializeField] private int numSeats = 2;
    [SerializeField] private GameObject[] seats;

    private void Awake()
    {
        seats = new GameObject[numSeats];
        PlayerController playerComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerComponent.onInteraction.AddListener(() => placeCustomer());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }

    void placeCustomer()
    {
        if (playerInRange)
        {
            //if player is in range and presses E then the attached customers will be seated at this table
        }
    }
}
