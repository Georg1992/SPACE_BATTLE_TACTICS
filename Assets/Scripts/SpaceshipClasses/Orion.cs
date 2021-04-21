using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrionSpaceship : BaseSpaceshipClass
{
   

public OrionSpaceship(){
    
    SpaceshipClassName = "Orion";
    SpaceshipClassDescription = "GOOD DEF, WEAK ATTACK";
    Base_attack = 10;
    Base_def = 8;
    MaxHealth = 1200;
    CurrentHealth = MaxHealth;
    QSkill = new BasicAttack();
    WSkill = new SteeringMissile();
    ESkill = new BlasterOrb();
    ASkill = new OrionMove();
    SSkill = new Teleporter();
    DSkill = new CircleMove();
    ZSkill = new Shield();
    XSkill = new AirForceCall();
    CSkill = new Revind();
   
   
   
    
}
}
