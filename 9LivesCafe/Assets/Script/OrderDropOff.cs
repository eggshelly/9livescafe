using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OrderDropOff : MonoBehaviour
{
    public UnityEvent onOrderDropOff;
    private bool playerInRange = false;

    private void Awake()
    {
        //gets the PlayerController script from player and adds a listener for when player interacts with things
        PlayerController playerComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerComponent.onInteraction.AddListener(() => onDropOff());
        //calls test function upon listening 
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

    public void onDropOff()
    {
        if (playerInRange)
        {
            onOrderDropOff.Invoke();
        }
    }
}
