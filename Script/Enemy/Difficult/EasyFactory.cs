using Assets.Script.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Enemy.Difficult
{
    public class EasyFactory : MonoBehaviour, EnemyFactory
    {
        public int TimeGenerate => 200;

        public EnemyWave GenerateEnemy(float DefaultEnemyYPosition)
        {
            GameConfiguration gameConfiguration = GameConfiguration.Instance;
            var enemyWave = new EnemyWave(WaveType.Down, DefaultEnemyYPosition);
            var posX = UnityEngine.Random.Range(-1.6f, 1.6f);
            var gameObject = (GameObject)Instantiate(gameConfiguration.DefaultEnemyGameObject, new Vector3(posX, DefaultEnemyYPosition), Quaternion.identity);
            enemyWave.RegisterEnemy(gameObject);

            return enemyWave;
        }        
    }
}
