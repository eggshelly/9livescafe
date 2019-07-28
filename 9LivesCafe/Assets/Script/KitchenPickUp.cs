using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenPickUp : MonoBehaviour
{

    private KitchenDropOff dropOff;

    private void Awake()
    {
        dropOff = GetComponentInParent<KitchenDropOff>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getOrder()
    {
        return dropOff.getItem();
    }
}
