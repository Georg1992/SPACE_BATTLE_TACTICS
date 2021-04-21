using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarperSpaceship : BaseSpaceshipClass
{

    
    public WarperSpaceship(){
    SpaceshipClassName = "Warper";
    SpaceshipClassDescription = "BALLANCED";
    Base_attack = 15;
    Base_def = 4;
    MaxHealth = 1000;
    CurrentHealth = MaxHealth;
    QSkill = new BasicAttack();
    WSkill = new SteeringMissile();
    ESkill = new BlasterOrb();
    ASkill = new OrionMove();
    SSkill = new Teleporter();
    DSkill = new CircleMove();
    ZSkill = new Invisible();
    XSkill = new ElectricCharge();
    CSkill = new BlackHole();

}
}

