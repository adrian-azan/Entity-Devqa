using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    int [] _Quantity;
    [SerializeField]
    Entity[] _Entities;

    [SerializeField]
    Color_and_Text onDisplayText;
    List<Color_and_Text> allText;

    List<Entity> _ActiveEntities;

    TMP_Text score;
    Dictionary<Color,int> scoreBoard;


    void Start()
    {
        scoreBoard = new Dictionary<Color, int>();
        _ActiveEntities = new List<Entity>();
        allText = new List<Color_and_Text>();

        score = GetComponentInChildren<TMP_Text>();
        

        if (_Quantity.Length != _Entities.Length)
        {    
            Debug.LogWarning("ENTITY SPAWNER: MISMATCH ARRAY LENGHT");
        }
            for (int i = 0; i < _Quantity.Length;i++)
            {
                for (int j = 0; j < _Quantity[i];j++)
                { 
                    _ActiveEntities.Add(Instantiate(_Entities[i],new Vector3(Random.Range(-15,15),1.2f,Random.Range(-15,15)),new Quaternion()));                
                   
                }
            }     
    }

    public void Update()
    {
        scoreBoard.Clear();
        string scoreOutput = "";



        foreach (var entity in _ActiveEntities)
        {
            try
            {
                scoreBoard[entity._Skin.GetColor()] += 1;
            }
            
            catch{
                scoreBoard[entity._Skin.GetColor()] = 1;
            }

           
        }

        allText.ForEach(x => Destroy(x.gameObject));
        allText.Clear();

            int i = 0;
        foreach (var score1 in scoreBoard)
        {
            var temp = Instantiate<Color_and_Text>(onDisplayText);
            temp.transform.SetParent(GetComponentInChildren<Canvas>().transform);

            
            temp.SetColor(score1.Key);
            temp.SetText(score1.Value.ToString());

            temp.transform.position = new Vector3(200,i++*40+20);


            allText.Add(temp);
        }

    }
}
