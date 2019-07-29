using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemController : MonoBehaviour
{
    private const string holdingHand = "Hip/Spine/Spine1/transform2/R_Shoulder/R_arm/R_fore_arm/R_hand";
    private GameObject hand;
    private GameObject currHolding;
    private MenuItemController itemController;
    private PlayerController playerController;

    public GameobjectUnityEvent onKitchenDropOff = new GameobjectUnityEvent();
        //invoked when the player is in the kitchen trigger and drops off an item, listener in KitchenScript

    private void Awake()
    {
        playerController = this.gameObject.GetComponent<PlayerController>();

        //cache's hand object to use later
        hand = this.transform.Find(holdingHand).gameObject;

        //lister, for when item is picked up
        OrderPickUp orderPickUp = GameObject.FindGameObjectWithTag("orderPickUp").GetComponent<OrderPickUp>();
        orderPickUp.onOrderPickUp.AddListener(getItem);

        //listener, for when item is dropped off
        OrderDropOff orderDropOff = GameObject.FindGameObjectWithTag("orderDropOff").GetComponent<OrderDropOff>();
        orderDropOff.onOrderDropOff.AddListener(() => dropOff());
    }
  
    public void getItem(GameObject item)
    {
        if (!currHolding) //can only hold something if not holding anything
        {
            setHolding(item);
            if (itemController.getRequest())
            {
                Debug.Log("currently holding a request");
                //holding request to drop off to kitchen
            }
            else
            {
                GameObject newitem = Instantiate(item, hand.transform.position, hand.transform.rotation);
                //makes the item a child of the hand
                newitem.transform.SetParent(hand.transform);
                //sets the local position to the saved center piviot point
                newitem.transform.localPosition = itemController.getAttachPosition();
                newitem.transform.localEulerAngles = itemController.getAttachRotaion();
                //switch mc animation to holding
                playerController.switchHoldingItem();
            }
        }
        else
        {
            Debug.Log("TODO UPLOAD ERROR IN CANVAS THAT YOU ARE ALREADY HOLDING AN ITEM");
        }
        
    }


    //TODO: make a verson which places the item on the tabel, and a version that dumps the item (e.g just gets rid of it)

    public void dropOff()
    {
        //if currently holding item, can throw it away.
        if (currHolding)
        {
            if(itemController.getRequest())
            {
                //drop off to kitchen
                onKitchenDropOff.Invoke(currHolding);
                dropRequest();
                return;
            }
            GameObject holding = hand.transform.GetChild(0).gameObject;
            if (itemController.getName().Equals("plate"))//player is holding a plate
            {
                dropHoldingItem(holding);
            }
            else
            {
                placeItem(holding); //if the item is what the customer ordered

            }
        }
    }


    private void placeItem(GameObject holding)
    {
        if(true)//compare to what customer wants.
        {
            //place it on table & take away customer needed order..
            dropHoldingItem(holding);   //drop it from player's hand and spawn one on the tabel?
                //TODO: OR MOVE THIS ONE FROM PLAYER TO TABLE, NO NEED TO DESTORY.
        }
        else
        {
            Debug.Log("this is not what the customer wanted!");
        }
    }

    private void dropHoldingItem(GameObject holding)
    {
        Destroy(holding);
        playerController.switchHoldingItem();
        setHolding(null);
    }
    private void dropRequest()
    {
        //TODO: interact with kitchen
        setHolding(null);
    }

    private void setHolding(GameObject item = null)
    {
        currHolding = item;
        if(!currHolding)
            itemController = item.GetComponent<MenuItemController>();
    }
}
