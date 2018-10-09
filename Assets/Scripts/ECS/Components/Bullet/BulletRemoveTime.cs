using Sirenix.OdinInspector;
using UnityEngine;
public class BulletRemoveTime : MonoBehaviour
{
    public float removeTime = 10f;
    [ReadOnly]
    public float elapsedTime = 0f;

    private void OnEnable()
    {
        elapsedTime = 0f;
    }
    private void OnDisable()
    {
        elapsedTime = 0f;
    }
}
