using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeNPC : NPC
{
    public ProcessState state = ProcessState.WaitingForGreet;
    public Order order = null;
}

