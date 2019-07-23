using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItemController : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private float cooktime;
    [SerializeField] private Vector3 attachPosition;
    [SerializeField] private Vector3 attachRotation;
    private bool request = true;
    private bool cooked = false;
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
    public string getName() { return name; }
    public bool getRequest() { return request; }
    public void fillRequest() { request = true;  }
    public void cook()
    {
        //continue; 
    }
}
