//Galaga
// Written By Abdurrahman Rizal
// 2016/5/11
//Updated 2019/7/21

using Assets.Script.Bullet;
using Assets.Script.Enemy;
using Assets.Script.Enemy.Difficult;
using Assets.Script.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class GameConfiguration : MonoBehaviour
    {
        public bool GamePlay = false;

        public KeyCode KeyCodeRight = KeyCode.D;
        public KeyCode KeyCodeLeft = KeyCode.A;
        public KeyCode KeyCodeFire = KeyCode.Space;
        
        public float SpeedShip = 0.02f;

        public BulletFactory BulletFactory;

        public GameObject DefaultEnemyGameObject;

        public float DefaultEnemyYPosition = 0.035f;

        public BulletType BulletType = BulletType.Normal;

        public Canvas CanvasMainMenu;
        public Canvas CanvasGamePlay;

        public static GameConfiguration Instance { get { return _instance; } }

        private int _counterGenerateEnemy = 0;
        private int _bulletCount = 0;

        private EnemyFactory _enemyFactory;

        private DifficultAbstractFactory _difficultAbstractFactory = new DifficultFactory();
        private static GameConfiguration _instance;
        private List<EnemyWave> _enemyWaves;
        void Start()
        {
            _enemyFactory = new EasyFactory();
            _enemyWaves = new List<EnemyWave>();
        }
        void Awake() //Singleton
        {
            if (_instance != null && _instance != this)
            {                
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        void Update()
        {
            if (GamePlay == true)
            {
                _counterGenerateEnemy++;
                if (_counterGenerateEnemy > _enemyFactory.TimeGenerate)
                {
                    _counterGenerateEnemy = 0;
                    Debug.Log("Generate Enemy");
                    _enemyWaves.Add(_enemyFactory.GenerateEnemy(DefaultEnemyYPosition));
                }

                List<EnemyWave> waveToDelete = new List<EnemyWave>();
                foreach (EnemyWave enemyWave in _enemyWaves)
                {
                    enemyWave.Update();                    
                    if (enemyWave.Position.y > 3.75f)
                    {
                        Debug.Log("Destroy");
                        waveToDelete.Add(enemyWave);
                    }
                }

                foreach (EnemyWave enemyWave in waveToDelete)
                {
                    enemyWave.DestroyWave();
                    _enemyWaves.Remove(enemyWave);
                }
            }
        }
        public int GetBulletCount()
        {
            return _bulletCount;
        }

        public void SetBulletCount(int count)
        {
            _bulletCount = count;
        }
        public void ChangeBullet(Dropdown dropdownBulletType)
        {
            switch (dropdownBulletType.captionText.text)
            {
                case "Normal Bullet":
                    {
                        this.BulletType = BulletType.Normal;
                        break;
                    }
                case "Fast Bullet":
                    {
                        this.BulletType = BulletType.Fast;
                        break;
                    }
            }
        }
        public void ChangeDifficult(Dropdown dropdownDifficult) //Abstract Factory
        {
            CanvasMainMenu.gameObject.SetActive(false);
            CanvasGamePlay.gameObject.SetActive(true);
            GamePlay = true;
            Debug.Log("Change into : " + dropdownDifficult.captionText.text);
            
            switch (dropdownDifficult.captionText.text)
            {
                case "Easy":
                    {
                        _enemyFactory = _difficultAbstractFactory.getEnemy("Easy");
                        break;
                    }
                case "Medium":
                    {
                        _enemyFactory = _difficultAbstractFactory.getEnemy("Medium");
                        break;
                    }
                case "Hard":
                    {
                        _enemyFactory = _difficultAbstractFactory.getEnemy("Hard");
                        break;
                    }
            }


        }
        public void RestartGame()
        {
            GamePlay = false;
            CanvasMainMenu.gameObject.SetActive(true);
            CanvasGamePlay.gameObject.SetActive(false);
        }
    }
}
