using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Mob : Mechanical_Entity
{
    public enum MobState
    {
        IDLE,
        FOCUSED,
        FIGHTING
    };

    public MobState _State; 
    public float _Health;
    public float _Defense;
    public float _Speed;
    public float _Strength;

    protected float _Experience;

    public new void Awake()
    {
        base.Awake();

        _State = MobState.IDLE; 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exp(float amount)
    {
        
    }


     private void OnDrawGizmos()
    {
      /*  if (_Controller == null)
        {
            Handles.DrawWireDisc(transform.position+Vector3.up,Vector3.forward,2f);
        }
        else
        {
            Handles.DrawSolidDisc(transform.position+Vector3.up,Vector3.up,.05f);
        }*/
    }
}
