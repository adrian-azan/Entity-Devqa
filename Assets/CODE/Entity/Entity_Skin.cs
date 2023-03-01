using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Entity_Skin : Attribute
{
    private List<Renderer> _Render;

    private void Awake()
    {
        _Render = GetComponentsInChildren<MeshRenderer>().ToList<Renderer>();           
    }

    public void SetUp()
    {
        _Render = GetComponentsInChildren<MeshRenderer>().ToList<Renderer>();
    }    

    private void OnDisable()
    {            
        if (_Render == null)
            return;
       _Render.ForEach(x => x.enabled = false);
    }

    private void OnEnable()
    {
        if (_Render == null)
            return;
        _Render.ForEach(x => x.enabled = true);
    }

    public void SetColor(Color color)
    {
        if (_Render == null)
            SetUp();

        _Render.ForEach(r => r.material.color = color);
    }   

    public Color GetColor()
    {
        if (_Render == null)
            SetUp();

        return _Render.First().material.color;
    }
        private void OnApplicationPause(bool pause)
    {
        
    }
}
