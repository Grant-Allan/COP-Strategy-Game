﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadRNG : MonoBehaviour
{

    // Referencing the 'PostRNG' object within the scene
    public GameObject PostRNG;

    // Function that determines which random-bad event will occur.
    public void whichEvent()
    {
        
        // Variables to hold the current values of wood, gold, and food after allocation.
        int wood = Resources.getWood();
        int gold = Resources.getGold();
        int food = Resources.getFood();

        // Variable to store the calculated current event and defense value.
        int curEvent = 0;
        int defense = wood + gold + food;

        // Sets the PostRNG object active to allow for a pop-up to appear.
        PostRNG.SetActive(true);

        // Calculates a value between 1-3 inclusive to serve as the random event.
        int which = UnityEngine.Random.Range(1, 4);

        switch (which)
        {
            case 1:
                curEvent = 1;
                break;
            case 2:
                curEvent = 2;
                break;
            case 3:
                curEvent = 3;
                break;
        }

        // These if statments check if the chosen event and its detrimental impact to
        // the total defense value can occur. If not, curEvent is '4' and the user has 
        // to pack up their settlement and leave since they allocated too many resources
        // towards expansion and did not leave enough for defense.

        // Tornado
        if (curEvent == 1 && defense - 15 >= 0)
            defense -= 15;
        
        // Plague
        else if (curEvent == 2 && defense - 10 >= 0)
            defense -= 10;

        // Bandits
        else if (curEvent == 3 && defense - 5 >= 0)
            defense -= 5;
        
        // Pack
        else
            curEvent = 4;

        // Sets the object / image associated with the current event to active.
        PostRNG.transform.GetChild(curEvent).gameObject.SetActive(true);

    }   
}
