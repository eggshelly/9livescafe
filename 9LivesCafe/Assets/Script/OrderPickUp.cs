using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameobjectUnityEvent : UnityEvent<GameObject> { }

public class OrderPickUp : MonoBehaviour
{

    public GameobjectUnityEvent onOrderPickUp = new GameobjectUnityEvent();

    [SerializeField] private GameObject temp;
    private bool playerInRange = false;

    private void Awake()
    {
        //gets the PlayerController script from player and adds a listener for when player interacts with things
        PlayerController playerComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerComponent.onInteraction.AddListener(() => onPickUp());
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

    public void onPickUp()
    {
        if (playerInRange) {
            if (this.CompareTag("customer"))
            {
                //call customer.getOrder
            }
            else
            {
                onOrderPickUp.Invoke(temp);
            }
            
        }
    }
}
