using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Entity_Collider : MonoBehaviour
{   
    public List<Collider> _Colliders;

    
   
    public void Awake()
    {        
        _Colliders = GetComponentsInChildren<Collider>().ToList<Collider>();       
    }

    public void OnDisable()
    {
        if (_Colliders == null)
            return;
        _Colliders.ForEach(x => x.enabled = false);
    }

    public void OnEnable()
    {
        if (_Colliders == null)
            return;
        _Colliders.ForEach(x => x.enabled = true);
    }

    public void IgnoreCollision(Entity_Collider collider, bool ignore = true)
    {

        Debug.Log("Ignoring");
        foreach (var box in _Colliders)
        {
            foreach (var otherBox in collider._Colliders)
            {
                Physics.IgnoreCollision(box,otherBox, ignore);
            }
        }
       // _Colliders.ForEach(box => collider._Colliders.ForEach( otherBox => Physics.IgnoreCollision(box,otherBox,ignore)));
    }

    public void IgnoreCollision(int layer1, int layer2, bool ignore=true)
    {
        Physics.IgnoreLayerCollision(layer1,layer2,ignore);
    }


    public void Trigger(bool isTrigger)
    {
        _Colliders.ForEach(x => x.isTrigger = isTrigger);
    }

     
}
