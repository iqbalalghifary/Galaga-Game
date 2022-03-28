using Assets.Script.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Enemy.Difficult
{
    public class HardFactory : MonoBehaviour, EnemyFactory
    {
        public int TimeGenerate => 50;

        public EnemyWave GenerateEnemy(float DefaultEnemyYPosition)
        {
            GameConfiguration gameConfiguration = GameConfiguration.Instance;
            var enemyWave = new EnemyWave(WaveType.Down, DefaultEnemyYPosition);

            for (int i = 0; i < 5; i++)
                AddEnemy(gameConfiguration, enemyWave, DefaultEnemyYPosition);

            return enemyWave;
        }
        private void AddEnemy(GameConfiguration gameConfiguration, EnemyWave enemyWave, float defaultEnemyYPosition)
        {
            var posX = UnityEngine.Random.Range(-1.6f, 1.6f);
            var gameObject = (GameObject)Instantiate(gameConfiguration.DefaultEnemyGameObject, new Vector3(posX, defaultEnemyYPosition), 
            Quaternion.identity);
            enemyWave.RegisterEnemy(gameObject);

        }
    }
}
