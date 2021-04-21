using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class Astro : MonoBehaviour
{
    
  
    private float t;
    public float speed;
    private Stopwatch timer;
    public bool PlayerShot = true;
    // Start is called before the first frame update
    private float diagonalOffsetx;
    private float diagonalOffsety;
    private bool lighningOnce = false;
  
    void Start()
    {
        state = State.fly;
        
        
    }

    // Update is called once per frame
    void Update()
    {
       if(!lighningOnce){
           StartCoroutine(LightningDestroy());
       }
       
        
        
    }
    public enum State{
        fly,
        follow
    }
    private State state;
    
    public IEnumerator Astro1(GameObject target){
        if(PlayerShot==true){
            diagonalOffsetx = 180;
            diagonalOffsety = 40;
        }
        else{
            diagonalOffsetx=-180;
            diagonalOffsety=-40;
        }
        Vector2 diagonalmove = new Vector2(transform.position.x+diagonalOffsetx, transform.position.y+diagonalOffsety); 
        timer = new Stopwatch();

        timer.Start();

        while(state == State.fly && timer.Elapsed.TotalSeconds < 3 && this != null){
            
            t=Time.deltaTime/3;
            transform.position = Vector2.Lerp(transform.position, diagonalmove, t);
            yield return null;
        }
        if(this != null){
        timer.Stop();
        timer.Reset();
        StartCoroutine(Follow(target));
        }
            
    }
    public IEnumerator Astro2(GameObject target){
        if(PlayerShot==true){
            diagonalOffsetx = 180;
            diagonalOffsety = 40;
        }
        else{
            diagonalOffsetx=-180;
            diagonalOffsety=-40;
        }
        Vector2 diagonalmove = new Vector2(transform.position.x+diagonalOffsetx, transform.position.y); 
        timer = new Stopwatch();

        timer.Start();
            while(state == State.fly && timer.Elapsed.TotalSeconds < 3 && this!= null){
                t=Time.deltaTime/3;
                gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, diagonalmove, t);
                yield return null;
            }
        if(this != null){
        timer.Stop();
        timer.Reset();
        StartCoroutine(Follow(target));
        }
        
        

    }
    public IEnumerator Astro3(GameObject target){
        if(PlayerShot==true){
            diagonalOffsetx = 180;
            diagonalOffsety = 40;
        }
        else{
            diagonalOffsetx=-180;
            diagonalOffsety=-40;
        }
        Vector2 diagonalmove = new Vector2(transform.position.x+diagonalOffsetx, transform.position.y-diagonalOffsety); 
        timer = new Stopwatch();

        timer.Start();
        while(state == State.fly && timer.Elapsed.TotalSeconds < 3 && this != null){
                //Debug.Log(gameObject);
            t=Time.deltaTime/3;
            
            gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, diagonalmove, t);
            
            
                
            yield return null;
            
        }
            if(this != null){
        timer.Stop();
        timer.Reset();
        StartCoroutine(Follow(target));
        }
        
        

    }


    public IEnumerator Follow(GameObject target){
        
        state = State.follow;
        Vector2 initPos = gameObject.transform.position;
        while(state == State.follow && this !=null){
            
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime*speed);
            yield return null;
        }
   

    }

    public void OnTriggerEnter2D(Collider2D target){
        string enemy = target.name;
        if(enemy=="Enemy" && PlayerShot ==true){
            
            Enemy_AI AI = target.gameObject.GetComponent<Enemy_AI>();
            if(!AI.isBroken){
                StartCoroutine( AI.BrokenAI(8));
            }
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject,10);
            
        }
        if(enemy=="Player"&&PlayerShot==false){
            Skill_Handler allSlots = target.gameObject.GetComponent<Skill_Handler>();
            if(!Skill_Handler.isBroken){
                allSlots.Broken(10);
            }
            gameObject.GetComponent<Renderer>().enabled = false; 
            Destroy(gameObject,10);
        }
        
        
    } 

    private IEnumerator LightningDestroy(){
        if(Electric_Charge_Behaviour.ElectricChargeOn){
            
            
            
            
            for(int atempt = 0; atempt<=3;atempt++){   
                int rand = Random.Range(0,6);
                
                switch(rand){
                case 3:
                Destroy(this.gameObject);
                break;
                }
                
                lighningOnce = true;
                yield return new WaitForSecondsRealtime(1);
                
            }
           
            
        }
    }
}  



