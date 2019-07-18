using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] customers;
    public int custLimit = 5;

    int custCount = 0;

    void Start()
    {
        InvokeRepeating("AddCustomer", 3.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void AddCustomer()
    {
        if (custCount < custLimit)
        {
            Instantiate(customers[0], new Vector3(-5.5f, 0, custCount), transform.rotation * Quaternion.Euler(0f, 180f, 0f));
            custCount++;
        }
    }
}
