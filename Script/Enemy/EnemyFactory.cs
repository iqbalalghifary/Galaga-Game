using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
using UnityEngine; 

namespace Assets.Script.Enemy 
{     public interface EnemyFactory 
    {         
        int TimeGenerate { get; } 
        EnemyWave GenerateEnemy(float DefaultEnemyYPosition); 
    } 
}
