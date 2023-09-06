using UnityEngine;

public class AutomaticDestroy : MonoBehaviour
{
    [SerializeField] private float destroyTime;

    private void Awake()
    {
        Destroy(gameObject, destroyTime);
    }
}
