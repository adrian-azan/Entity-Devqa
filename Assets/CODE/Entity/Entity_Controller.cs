using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Entity_Controller : MonoBehaviour
{
    private Rigidbody _RB;
    private Vector3 _Velocity;
    protected float _Direction;

    [SerializeField]
    private float _Speed;
    
    [SerializeField]
    private float _GravityScale; 
    
    [SerializeField]
    private bool _Fly;
    
    protected void Start()
    {
       _RB = GetComponentInParent<Rigidbody>();
    }
  
    protected void FixedUpdate()
    {
      _RB.AddForce(Vector3.down*Time.fixedDeltaTime,ForceMode.Acceleration);
        _RB.maxAngularVelocity = 0;

            Debug.DrawRay(transform.position, _RB.velocity);


    }

    public void AddVelocity(Vector3 velocity)
    {
        _RB.AddForce(velocity, ForceMode.VelocityChange);
    }

    public void SetVelocity(Vector3 velocity)
    {
        _RB.velocity = velocity;
    }

    public void SetVelocity(Entity target)
    {
        var vel = _RB.position - target.transform.position;
        vel.Normalize();
        _RB.velocity = vel;
    }

    public void SetTarget(Vector3 target)
    {
        try
        {
            var vel = target - _RB.position;
            vel.y = 0;
            vel.Normalize();
            _RB.velocity = vel * _Speed;
        }
        catch(NullReferenceException ex)
        {
            _RB = GetComponentInParent<Rigidbody>();
            SetTarget(target);
            Debug.LogWarning("RigidBody Not Assigned - SetTarget");
        }
    }


    public void SetSpeed(float speed)
    {
        if (speed < 0)
            return;
        _Speed = speed;
    }       
    







///*
// * Turn will physically rotate the entity 
// * in the world space. 
// */
// public void Turn(Vector3 dir, float step = 45)
// {   
//    if (dir == Vector3.zero)
//        return;

//    var angle = Quaternion.RotateTowards(_Controller.transform.rotation,Quaternion.LookRotation(dir,Vector3.up),step);        
//    _Controller.MoveRotation(angle);
// }      

///*
// * Entities do not use the automatic Unity physics gravity. We 
// * apply gravity in our own function to give us better
// * control over each entity.
// */
// public void Gravity()
// {        
//    if (_Fly || _Velocity.y < Physics.gravity.y)
//        return;   

//    _Velocity.y += Physics.gravity.y * Time.fixedDeltaTime;        
// }   




public void Disable()
{
    if (_RB == null)
        return;
    _RB.isKinematic = true;
}

public void Enable()
{
    if (_RB == null)
        return;
    _RB.isKinematic = false;
}

public void IsTrigger(bool isTrigger)
{
    _RB.detectCollisions = isTrigger;
}

public new string ToString()
{
    return _Velocity.ToString();
    
}
}
