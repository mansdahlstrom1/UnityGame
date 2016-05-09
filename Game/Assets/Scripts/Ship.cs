using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Ship : MonoBehaviour
    {
        public List<Vector2> missileSpawnPoints;
        public GameObject missile;
        public float fireRate;
        public int moveSpeed;

        protected Rigidbody2D r2d;
        protected Vector2 velocity;
        protected float nextFire;

        //Collision event
        public event CollisionEvent collisionEvent;
        //public EventArgs e = null;
        public delegate void CollisionEvent(MonoBehaviour me, GameObject obj);
        //public delegate void CollisionEvent(MonoBehaviour me, GameObject obj);

        public void Shoot()
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;

                foreach (Vector2 spawnPoint in missileSpawnPoints)
                {
                    Instantiate(missile, (transform.position + (Vector3)spawnPoint), Quaternion.identity);
                }
            }
        }

        protected void OnTriggerEnter2D(Collider2D col)
        {
            try {
                if (!this.tag.Equals(col.gameObject.tag))
                    collisionEvent(this, col.gameObject);
            }
            catch (Exception e)
            {

            }
        }
    }
}
