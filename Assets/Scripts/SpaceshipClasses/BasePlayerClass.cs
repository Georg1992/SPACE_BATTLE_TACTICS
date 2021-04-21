using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerClass
{
    
    
    private string playerName;
    private int playerLevel;
    private BaseSpaceshipClass spaceshipClass;
    private string spaceshipClassName;
    private string spaceshipClassDescription;
    public Sprite SCALPEL, WARPER, ORION;
    private SpriteRenderer SelectedCharacterSprite;
    private readonly string SelectedCharacter;

//stats
    private int base_attack;
    private int base_def;
    private float maxHealth;
    private float currentHealth;
//setters
    
    
    public string PlayerName
    {get;set;}
    public int PlayerLevel
    {get;set;}
    public BaseSpaceshipClass SpaceshipClass{get; set;}
    public string SpaceshipClassName{
    get{return spaceshipClassName;}
    set{spaceshipClassName = value;}
}   
    public string SpaceshipClassDescription{
    get{return spaceshipClassDescription;}
    set{spaceshipClassDescription = value;}
    }
    public int Base_attack{
    get{return base_attack;}
    set{base_attack = value;}
    }
    public int Base_def{
    get{return base_def;}
    set{base_def = value;}
    }
    public float MaxHealth{
    get{return maxHealth;}
    set{maxHealth=value;}
    }

    public float CurrentHealth{
    get{return currentHealth;}
    set{currentHealth=value;}
    }
    public BasePlayerClass(BaseSpaceshipClass chosenShip)
{
   chosenShip= SpaceshipClass;
}

    public BasePlayerClass()
    {

    }





}
