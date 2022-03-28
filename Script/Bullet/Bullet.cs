using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Bullet
{
    public class Bullet : MonoBehaviour
    {
        private float _speed;
        public Bullet(float speed)
        {
            _speed = speed;
        }

        void Update()
        {            
            this.gameObject.transform.Translate(new Vector3(0f, _speed));
            if (gameObject.transform.position.y > 0.025f)
            {
                GameConfiguration.Instance.SetBulletCount(0);
                Destroy(this.gameObject);
            }
        }
        void OnDestroy()
        {
            GameConfiguration.Instance.SetBulletCount(0);
        }
    }
}
