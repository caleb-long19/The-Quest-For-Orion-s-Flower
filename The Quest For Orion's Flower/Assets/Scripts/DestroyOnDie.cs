using UnityEngine;

public class DestroyOnDie : MonoBehaviour
{
    public void Die()
    {
        Destroy(gameObject);
    }
}
