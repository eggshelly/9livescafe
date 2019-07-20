using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemController : MonoBehaviour
{
    private const string holdingHand = "R_hand";
    private GameObject hand;
    private void Awake()
    {
        //cache's hand object to use later
        hand = transform.FindChild(holdingHand).gameObject;

        //lister, for when item is picked up
        OrderPickUp orderPickUp = GameObject.FindGameObjectWithTag("orderPickUp").GetComponent<OrderPickUp>();
        orderPickUp.onOrderPickUp.AddListener(getItem);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getItem(GameObject item)
    {
        MenuItemController itemController = item.GetComponent<MenuItemController>();
        item.SetActive(true);
        //makes the item a child of the hand
        item.transform.parent = hand.transform;
        //sets the local position to the saved center piviot point
        item.transform.localPosition = itemController.getAttachPosition();
        item.transform.localEulerAngles = itemController.getAttachRotaion();
    }

    public void placeItem()
    {

    }
}
