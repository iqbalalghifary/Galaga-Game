using Assets.Script.Enemy.Difficult;
using Assets.Script.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DifficultFactory : DifficultAbstractFactory
{
    public override EnemyFactory getEnemy(string difficult){
			if (difficult == "Easy")
				return new EasyFactory();
			else if (difficult == "Medium")
				return new MediumFactory();
			else 
				return new HardFactory();
		}
}



