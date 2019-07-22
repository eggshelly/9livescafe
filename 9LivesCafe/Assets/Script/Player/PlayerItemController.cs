using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemController : MonoBehaviour
{
    private const string holdingHand = "Hip/Spine/Spine1/transform2/R_Shoulder/R_arm/R_fore_arm/R_hand";
    private GameObject hand;
    private GameObject currHolding;
    private PlayerController playerController;

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
        orderDropOff.onOrderDropOff.AddListener(() => placeItem());
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
        if (!currHolding) //can only hold something if not holding anything
        {
            GameObject newitem = Instantiate(item, hand.transform.position, hand.transform.rotation);       //TODO: if the item is a order don't spawn anything (or maybe add seprate animation)
            MenuItemController itemController = newitem.GetComponent<MenuItemController>();
            //makes the item a child of the hand
            newitem.transform.SetParent(hand.transform);
            //sets the local position to the saved center piviot point
            newitem.transform.localPosition = itemController.getAttachPosition();
            newitem.transform.localEulerAngles = itemController.getAttachRotaion();
            //switch mc animation to holding
            playerController.switchHoldingItem();

            currHolding = item;
        }
        else
        {
            Debug.Log("TODO UPLOAD ERROR IN CANVAS THAT YOU CANNOT CARRY MORE THAN ONE ITEM");
        }
        
    }

    //TODO: make a verson which places the item on the tabel, and a version that dumps the item (e.g just gets rid of it)

    public GameObject dropItem()
    {
        GameObject rtn = hand.transform.GetChild(0).gameObject;
        Destroy(rtn);
        return rtn;
    }

    public void placeItem()
    {
        if (currHolding)    //if currently holding item, can throw it away.
        {
            //switch mc animation to holding
            //Instantiate(dropItem(), Vector3.zero, Quaternion.identity);   //the dropped item can still be spawned
            playerController.switchHoldingItem();

            currHolding = null;
        }
       
    }
}
