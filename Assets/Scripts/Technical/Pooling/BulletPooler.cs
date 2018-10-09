using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
[System.Serializable]
public struct BulletCreationInfo
{
    public BulletsTypes type;
    [AssetsOnly]
    public GameObject bulletPrefab;
}
public class BulletPooler : MonoBehaviour
{
    public static BulletPooler instance;
    public List<BulletCreationInfo> bullets = new List<BulletCreationInfo>();
    List<SetPooler> poolers = new List<SetPooler>();
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }


        instance = this;
    }

    private void Start()
    {
        foreach (var item in bullets)
        {
            if (item.bulletPrefab != null)
            {
                var p = gameObject.AddComponent<SetPooler>();
                p.prepopulate = 500;
                p.prefab = item.bulletPrefab;
                p.key = item.type.ToString();
                p.Register();
                poolers.Add(p);

            }
        }

    }


    public static void Enqueue(GameObject bullet)
    {
        var key = bullet.GetComponent<Poolable>()?.key;
        if (key != null)
        {
            foreach (var item in instance.poolers)
            {
                if (item.key == key)
                {
                    item.EnqueueObject(bullet);
                    return;
                }
            }
        }

    }

    public static void Enqueue(List<GameObject> bullets)
    {
        if (bullets == null)
            return;
        for (int i = 0; i < bullets.Count; i++)
        {
            Enqueue(bullets[i]);
        }
    }

    public static GameObject Dequeue()
    {
        return Dequeue(BulletsTypes.Circle.ToString());
    }
    public static GameObject Dequeue(string key)
    {
        if (instance?.poolers == null)
            return null;
        foreach (var item in instance.poolers)
        {
            if (item.key == key)
                return item.DequeueScript<Bullet>().gameObject;
        }
        return null;
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }
}
