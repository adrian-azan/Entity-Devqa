using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pukmun.Common.Tools;

public class Slime : Mob
{
    Queue<Vector3> _Targets; 

    private const int _SIZE = 3;
    private const float TIME_TO_THINK = 5;
    private Color _COLOR;

    private float startThinking;

    
    
    public new void Awake()
    {
        base.Awake();
        
        _COLOR = Tools.RandomColor();
        _Skin.SetColor(_COLOR);

        _Targets = new Queue<Vector3>();
        
        _Controller.SetSpeed(1);
   //     _Collider.IgnoreCollision(31,31);
        
       // StartCoroutine(FindTarget());
        StartCoroutine(Think());
    }

    public void FixedUpdate()
    {
        foreach (var totem in _Targets)
        {
            Debug.DrawRay(totem, Vector3.up*10,_COLOR);
        }    
        Debug.DrawLine(transform.position,_Targets.Peek());
    }

    public void Update()
    {
        switch (_State)
        {
            case MobState.IDLE:

                break;
            case MobState.FOCUSED:

                break;
            case MobState.FIGHTING:
                break;
            default:
                break;
        }

    }



    private void FillBrain()
    {
        for (int i = 0; i < _SIZE; i ++)
        {
            var test = new Vector3(Random.Range(-18,18),0,Random.Range(-18,18));
            _Targets.Enqueue(test);
        }
    }

    private void FindTarget()
    {
        try
        { 
            _Controller.SetTarget(_Targets.Peek());
        }
        catch (System.InvalidOperationException e)
        {
            FillBrain();
        }
    }

    private IEnumerator Think()
    {
        if (_Targets.Count == 0)
            FillBrain();
         
        
        startThinking = Time.realtimeSinceStartup;

        yield return new WaitUntil(() => Tools.DistanceToXZ(transform.position,_Targets.Peek()) < .1 || Time.realtimeSinceStartup - startThinking >= TIME_TO_THINK);

        _Controller.SetVelocity(Vector3.zero);
       _Targets.Dequeue();
        FindTarget();
        StartCoroutine(Think());
    }

    public void React(Entity source)
    {
        _Skin.SetColor(source._Skin.GetColor());       
    }

 

    private void OnDrawGizmos()
    {
        if (transform != null && _Controller != null)
            UnityEditor.Handles.Label(transform.position+Vector3.up*1.5f, _Strength.ToString());//transform.position+Vector3.up*1.5f, (Time.realtimeSinceStartup - startThinking).ToString());
    }
}
