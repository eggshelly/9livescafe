using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemController : MonoBehaviour
{
    private const string holdingHand = "Hip/Spine/Spine1/transform2/R_Shoulder/R_arm/R_fore_arm/R_hand";
    private GameObject hand;
    private void Awake()
    {
        //cache's hand object to use later
        hand = this.transform.Find(holdingHand).gameObject;

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
        GameObject newitem = Instantiate(item, hand.transform.position, hand.transform.rotation);
        MenuItemController itemController = newitem.GetComponent<MenuItemController>();
        //makes the item a child of the hand
        newitem.transform.SetParent(hand.transform);
        //sets the local position to the saved center piviot point
        newitem.transform.localPosition = itemController.getAttachPosition();
        newitem.transform.localEulerAngles = itemController.getAttachRotaion();
    }

    public void placeItem()
    {

    }
}
