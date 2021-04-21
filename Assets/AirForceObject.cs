using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirForceObject : MonoBehaviour
{
    private Vector2 initPos;
    private float initPosX;
    private float travelDistance = 100;
    private GameObject Enemy;
    private GameObject Player;
    private bool playerShot = true;
    public Missile thisMissile;
    public BulletDirection thisBullet;
    
    private float t = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        initPosX = this.transform.position.x;
        Enemy = GameObject.Find("Enemy");
        Player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToThePoint();
        Shoot();
        MovingBackAndDestroy();
    }

    private enum State{
        moving,
        shooting,
        wait,
        movingBack,
        timeToDestroy

    }
    private State state;
    private void MoveToThePoint(){
        
        if(!playerShot){
            travelDistance = travelDistance * (-1);
        }
        if(state == State.moving){
            t += Time.deltaTime;
            Vector2 checkpoint = new Vector2(initPosX+travelDistance, this.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, checkpoint, t);
            if(transform.position.x == checkpoint.x){
                state = State.shooting;

            }
        }
    }
    private void Shoot(){
        if(state == State.shooting){
            if(!playerShot){
                BulletDirection Bullet1 = Instantiate(thisBullet, transform.position, Quaternion.Euler(0,180,0));
                Missile newMissile = Instantiate(thisMissile, this.transform.position, Quaternion.Euler(0,180,0));
                Bullet1.EnemyShot();
                StartCoroutine(ShootSecond(1, Enemy));
                newMissile.EnemyShot();
                StartCoroutine(newMissile.GetOutState(Player));
                


            }
            else{
                BulletDirection newBullet = Instantiate(thisBullet, transform.position, Quaternion.identity);
                Missile newMissile = Instantiate(thisMissile, this.transform.position, Quaternion.identity);
                StartCoroutine(ShootSecond(1, Player));
                StartCoroutine(newMissile.GetOutState(Enemy));
                
            }
            state = State.wait;
           
        }

    }

    private void MovingBackAndDestroy(){
        if(state == State.wait){
            StartCoroutine(Wait(2));

        }
        if(state == State.movingBack){
            t += Time.deltaTime;
            
            transform.position = Vector2.MoveTowards(transform.position, initPos, t);
            if(transform.position.x == initPosX){
                state = State.timeToDestroy;
                Destroy(this.gameObject);

            }
        }

    }
    private IEnumerator Wait(float t){
        yield return new WaitForSecondsRealtime (t);
        state = State.movingBack;
        
    }
    private IEnumerator ShootSecond(float t, GameObject user){
        yield return new WaitForSecondsRealtime(t);
        BulletDirection Bullet2 = Instantiate(thisBullet, transform.position, Quaternion.identity);
        if(user == Enemy)
        Bullet2.EnemyShot();
    }

    public void EnemyShot(){
        playerShot = false;
    }
}
