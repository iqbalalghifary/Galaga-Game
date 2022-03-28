using Assets.Script.Bullet.Type;
using Assets.Script.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Bullet
{
    public class BulletFactory : MonoBehaviour
    {
        public GameObject DefaultBullet;
       
        public void BuildBullet(BulletType bulletType, Vector3 position)
        {         
            GameObject gameObject = (gameObject) Instantiate(DefaultBullet, position, Quaternion.identity);
            CreateBullet(gameObject, bulletType);            
        }
        private IBullet CreateBullet(GameObject gameObject, BulletType bulletType)
        {
            switch (bulletType)
            {
                case BulletType.Normal:
                    {
                        return gameObject.AddComponent<NormalBullet>();
                    }
                case BulletType.Fast:
                    {
                        return gameObject.AddComponent<fastBullet>();
                    }      
            }
            return null;
        }
    }    
}
