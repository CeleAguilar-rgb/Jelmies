using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private InformacionDePersonaje data;

    public void Initialize(InformacionDePersonaje informacionDePersonaje)
    {
        data = informacionDePersonaje;
    }

    private float speedMultiplier = 1f;
    public void SetSpeedMultiplier(float multiplier)
    {
        speedMultiplier = multiplier;
    }

    public void Move(Vector2 input, Camera cam)
    {
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 direction =
            forward * input.y +
            right * input.x;

        transform.position +=
            direction.normalized *
            data.moveSpeed *
            speedMultiplier *
            Time.deltaTime;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                data.rotationSpeed * Time.deltaTime
            );
        }
    }
}