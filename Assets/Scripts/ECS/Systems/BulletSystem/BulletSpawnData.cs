using UnityEngine;

[System.Serializable]
public struct BulletSpawnData
{
    public BulletsTypes type;
    public Vector2 position;
    public Vector2 direction;
    public Faction.Type faction;
    public float speed;
    public int damage;

    public BulletSpawnData(Vector2 position, Vector2 direction, float speed, int damage, BulletsTypes type, Faction.Type faction)
    {
        this.type = type;
        this.position = position;
        this.direction = direction;
        this.speed = speed;
        this.damage = damage;
        this.faction = faction;
    }

    public BulletSpawnData(BulletSpawnData other) : this(other.position, other.direction, other.speed, other.damage, other.type, other.faction)
    {

    }


}
