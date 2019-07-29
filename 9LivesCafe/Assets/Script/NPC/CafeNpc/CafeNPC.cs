using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeNPC : NPC
{
    public Order order;
    public CafeNPC(GameObject cNpc, GameObject cOrder) : base(cNpc)
    {
        order = new Order(cOrder);
    }
    public ProcessState state = ProcessState.WaitingForGreet;
}

