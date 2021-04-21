using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalpelSpaceship : BaseSpaceshipClass
{
   
  
    public ScalpelSpaceship(){
    SpaceshipClassName = "Scalpel";
    SpaceshipClassDescription = "STRONG ATTACK";
    Base_attack = 12;
    Base_def = 2;
    MaxHealth = 800;
    CurrentHealth = MaxHealth;
    QSkill = new BasicAttack();
    WSkill = new SteeringMissile();
    ESkill = new BlasterOrb();
    ASkill = new OrionMove();
    SSkill = new Teleporter();
    DSkill = new CircleMove();
    ZSkill = new MirrorShield();
    XSkill = new Desant();
    CSkill = new LaserBeam();
    
    
    
}
}
