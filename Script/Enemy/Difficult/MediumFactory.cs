using Assets.Script.Enum; 
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
using UnityEngine; 
namespace Assets.Script.Enemy.Difficult 
{ 
    public class MediumFactory : MonoBehaviour, EnemyFactory 
    {         public int TimeGenerate => 100; 
        public EnemyWave GenerateEnemy(float DefaultEnemyYPosition)         
        { 
            GameConfiguration gameConfiguration = GameConfiguration.Ins tance;             
            var enemyWave = new EnemyWave(WaveType.Down, DefaultEnemyYP osition);  
            for(int i = 0; i < 5; i++) 
                AddEnemy(gameConfiguration, enemyWave, DefaultEnemyYPos ition);              
                return enemyWave; 
        }         
        private void AddEnemy(GameConfiguration gameConfiguration, Enem yWave enemyWave, float defaultEnemyYPosition) 
        {             
            var posX = UnityEngine.Random.Range(-1.6f, 1.6f);             
            var gameObject = (GameObject)Instantiate(gameConfiguration. DefaultEnemyGameObject, new Vector3(posX, defaultEnemyYPosition), Quate rnion.identity);             
            enemyWave.RegisterEnemy(gameObject); 
        } 
    }
} 

