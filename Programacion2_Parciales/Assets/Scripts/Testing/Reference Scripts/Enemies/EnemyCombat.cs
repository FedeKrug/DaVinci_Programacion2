using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public AnimEventsManager events;
    public MeleeSensor mysensormelee;




    void Start()
    {
        events.ADD_EVENT("melee_attack_begin", RealBegin_Melee);
        events.ADD_EVENT("melee_attack_end", RealEnd_Melee);
       
    }

    #region Real Events

    void RealBegin_Melee()
    {
        Debug.Log("RealBegin_Melee");
        mysensormelee.TurnOn();
    }

    void RealEnd_Melee()
    {
        Debug.Log("RealEnd_Melee");
        mysensormelee.TurnOff();
    }

   

  
    #endregion


 
}
