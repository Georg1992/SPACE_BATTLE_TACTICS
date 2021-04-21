using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Black_Hole_Behaviour : MonoBehaviour
{

    public TheHole prefab;
    
    private GameObject Player;
    private GameObject Enemy;
    void Start()
    {
        Player = GameObject.Find("Player");
        Enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Use(GameObject user){
        
        if(user == GameObject.Find("Player")){
            Vector2 pos = new Vector2(0, -50);
            TheHole hole = Instantiate(prefab, pos, Quaternion.identity);
            hole.gameObject.name = "PlayerHole";
        }
        if(user == GameObject.Find("Enemy")){
            Vector2 pos = new Vector2(0,50);
            TheHole hole = Instantiate(prefab, pos, Quaternion.identity);
            hole.gameObject.name = "EnemyHole";
            hole.EnemyShot();
            

        }
        

        yield return null;
    }
}
