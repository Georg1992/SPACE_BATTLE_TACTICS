using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo: MonoBehaviour
{
public static string PlayerName {get;set;}
public static int PlayerLevel{get;set;}
public static BaseSpaceshipClass PlayerClass{get;set;}
public static int PlayerBaseAttack
{get;set;}

public static int PlayerBaseDef
{get;set;}

public static int PlayerHealth
{get;set;}



public static int EnemyLevel{get;set;}
public static BaseSpaceshipClass EnemyClass{get;set;}
public static int EnemyBaseAttack
{get;set;}

public static int EnemyBaseDef
{get;set;}

public static int EnemyHealth
{get;set;}


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }

   
}
