using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject BulletSound;

    public Transform BulletSpawnPosition;

    public void Fire()
    {
        if (Bullet == null ||
            BulletSound == null ||
            BulletSpawnPosition == null)
            return;
        
        Instantiate(Bullet, BulletSpawnPosition.position, BulletSpawnPosition.rotation);
        Instantiate(BulletSound, BulletSpawnPosition.position, BulletSpawnPosition.rotation);

    }
}
