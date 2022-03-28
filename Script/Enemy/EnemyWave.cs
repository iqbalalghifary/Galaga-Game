using Assets.Script.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Enemy
{
    public class EnemyWave //Observer Pattern
    {
        private WaveType _waveType;
        private List<GameObject> _enemies;
        private Vector3 _wavePosition;
        public EnemyWave(WaveType waveType, float defaultEnemyYPosition)
        {
            _wavePosition = new Vector3(0f, defaultEnemyYPosition);
            _enemies = new List<GameObject>();
            _waveType = waveType;
        }
        public Vector3 Position
        {
            get
            {
                return _wavePosition;
            }
        }
        public void RegisterEnemy(GameObject enemy)
        {
            _enemies.Add(enemy);
        }
        public void Update()
        {
            if (_waveType == WaveType.Down)
            {
                GoDown();
            }
        }
        public void DestroyWave()
        {
            foreach (GameObject gameObject in _enemies)
            {                
                if(gameObject != null)
                    GameObject.Destroy(gameObject);
            }
        }

        private void GoDown()
        {
            _wavePosition.y -= -0.01f;
            foreach (GameObject gameObject in _enemies)
            {
                if(gameObject != null)
                    gameObject.transform.Translate(new Vector3(0f, -0.01f));
            }
        }
    }
}
