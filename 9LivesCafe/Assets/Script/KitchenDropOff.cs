using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenDropOff : MonoBehaviour
{
    
    private GameObject kitchenQueue;    //TODO: CHANGE THIS TO QUEUE LATER
    private OrderPickUp orderPickUp;

    private void Awake()
    {
        orderPickUp = GetComponent<OrderPickUp>();
        PlayerItemController playerItemController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItemController>();
        playerItemController.onKitchenDropOff.AddListener(placeOrder);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void placeOrder(GameObject item)
    {
        kitchenQueue = item;
    }

    public GameObject getItem()
    {
        //kitchen queue.deque();
        return kitchenQueue;

    }
}
