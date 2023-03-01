using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;

using UnityEditor;
public class Entity : MonoBehaviour
{
    public Entity_Collider _Collider;
    public Entity_Skin _Skin;
    public Entity_Controller _Controller;
    public Entity_Animator _Animator;

    public void Disable()
    {     
        _Collider.enabled = false;  
        _Skin.enabled = false;     
        _Controller.enabled = false;      
        _Animator.enabled = false;    
    }

    public void Enable()
    {       
        _Collider.enabled = true;  
        _Skin.enabled = true;     
        _Controller.enabled = true;      
        _Animator.enabled = true;  
    }


    public void Awake()
    {
        _Collider = GetComponentInChildren<Entity_Collider>();
        _Skin = GetComponentInChildren<Entity_Skin>();
        _Controller = GetComponentInChildren<Entity_Controller>();
        _Animator = GetComponent<Entity_Animator>();
    }
          
    public void SnapTo(Vector3 newPosition)
    {
        _Controller?.Disable();
        transform.position = newPosition;
        _Controller?.Enable();
    }

    public void RotateAround(Vector3 point, Vector3 axis, float angle)
    {
        _Controller?.Disable();
        transform.RotateAround(point, axis, angle);
        _Controller?.Enable();       
    }

    private void OnDrawGizmos()
    {
        if (transform != null && _Controller != null)
            Handles.Label(transform.position+Vector3.up, _Controller.ToString());
    }
}
