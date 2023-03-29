using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Collider : Entity_Collider
{
  
    public void OnTriggerEnter(Collider other)
    {
        Slime otherRoot = other.GetComponentInParent<Slime>();

        if (otherRoot == null)
            return;
        
        int otherMove = Random.Range(0,(int)(20*otherRoot._Strength));
        int move = Random.Range(0,(int)(20* GetComponentInParent<Slime>()._Strength));

        if (move < otherMove)
        {
            otherRoot._Strength *= 1.1f;
            GetComponentInParent<Slime>().React(other.GetComponentInParent<Entity>());

        }
        else
            other.GetComponentInParent<Slime>().React(GetComponentInParent<Entity>());
    } 


}
