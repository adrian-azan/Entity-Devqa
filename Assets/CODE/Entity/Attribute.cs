using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute : MonoBehaviour
{
    List<Attribute> _Attributes;
    private void Awake()
    {
        _Attributes = new List<Attribute>();
    }

    private void OnDisable()
    {
        foreach(Attribute attribute in _Attributes)
        {
            attribute.OnDisable();
        }
    }

    private void OnEnable()
    {
        foreach(Attribute attribute in _Attributes)
        {
            attribute.OnEnable();
        }
    }

}
