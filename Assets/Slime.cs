using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pukmun.Common.Tools;
public class Slime : Mob
{
    Queue<Vector3> _Totems;
    private const int _SIZE = 3;
    private const float TIME_TO_THINK = 30;
    private Color _COLOR;

    private float startThinking;

    

    public new void Awake()
    {
        base.Awake();

        _COLOR = Tools.RandomColor();
        _Skin.SetColor(_COLOR);

        _Totems = new Queue<Vector3>();
        
        _Controller.SetSpeed(1);
   //     _Collider.IgnoreCollision(31,31);
        
        StartCoroutine(FindTarget());
        StartCoroutine(Think());
    }

    public void FixedUpdate()
    {
        foreach (var totem in _Totems)
        {
            Debug.DrawRay(totem, Vector3.up*10,_COLOR);
        }    
        Debug.DrawLine(transform.position,_Totems.Peek());
    }

    

    private void FillBrain()
    {
        for (int i = 0; i < _SIZE; i ++)
        {
            var test = new Vector3(Random.Range(-18,18),0,Random.Range(-18,18));
            _Totems.Enqueue(test);
        }
    }

    private IEnumerator FindTarget()
    {
        yield return new WaitForSeconds(5);

        _Controller.SetTarget(_Totems.Peek());
        StartCoroutine(FindTarget());
    }

    private IEnumerator Think()
    {
        if (_Totems.Count == 0)
            FillBrain();
         
        
        startThinking = Time.realtimeSinceStartup;

        yield return new WaitUntil(() => Tools.DistanceToXZ(transform.position,_Totems.Peek()) < .1 || Time.realtimeSinceStartup - startThinking >= TIME_TO_THINK);

        _Controller.SetVelocity(Vector3.zero);
       _Totems.Dequeue();
        _Controller.
        StartCoroutine(Think());
    }

    public void React(Entity source)
    {
        _Skin.SetColor(source._Skin.GetColor());

       
    }

 

    private void OnDrawGizmos()
    {
        if (transform != null && _Controller != null)
            UnityEditor.Handles.Label(transform.position+Vector3.up*1.5f, (Time.realtimeSinceStartup - startThinking).ToString());
    }
}
