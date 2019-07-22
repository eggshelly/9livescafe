using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{

    [SerializeField] private int numOrderPlaceable;
    [SerializeField] private Vector3[] placeableLocation;

    private void Awake()
    {
        placeableLocation = new Vector3[numOrderPlaceable];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
