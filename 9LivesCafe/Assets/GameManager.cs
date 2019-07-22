using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] customers;
    public string[] orderNames;
    public int custLimit = 5;
    
    int custCount = 0;

    void Awake()
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
