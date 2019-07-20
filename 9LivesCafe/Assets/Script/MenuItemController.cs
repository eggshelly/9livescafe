using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItemController : MonoBehaviour
{

    [SerializeField] private Vector3 attachPosition;
    [SerializeField] private Vector3 attachRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getAttachPosition() { return attachPosition; }
    public Vector3 getAttachRotaion() { return attachRotation; }
}
