using UnityEngine;

public class ControladorEnemigo : MonoBehaviour
{
    public float RadioVision = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RadioVision);
    }
}
