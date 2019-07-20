using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItemController : MonoBehaviour
{

    [SerializeField] private Vector3 CenterPosition;
    [SerializeField] private Vector3 CenterRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getCenterPosition() { return CenterPosition; }
    public Vector3 getCenterRotaion() { return CenterRotation; }
}
