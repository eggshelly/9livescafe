using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempNPCScript : MonoBehaviour
{

    [SerializeField] private GameObject order;

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
        return order;        
    }
}
