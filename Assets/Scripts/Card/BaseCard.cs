using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BaseCard : MonoBehaviour
{

    public int CID;
    public string cardName;
    public int damage;
    public float effect;
    public float radius;
    public float time;

    public Card cardInfo;



    void Awake() {
        SetStats();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStats()
    {
        CID = cardInfo.CID;
        cardName = cardInfo.cardName;
        damage = cardInfo.damage;
        effect = cardInfo.effect;
        radius = cardInfo.radius;
        time = cardInfo.time;
    }
}
