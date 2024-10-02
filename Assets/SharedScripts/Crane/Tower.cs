using GameMath.UI;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform foundation;

    [SerializeField] private HoldableButton leftButton;
    [SerializeField] private HoldableButton rightButton;

    private float _rotationSpeed = 90f;
    
    private void Update()
    {
        if (leftButton.IsHeldDown)
        {
            RotateAroundFoundation(-_rotationSpeed * Time.deltaTime);
        }
        else if (rightButton.IsHeldDown)
        {
            RotateAroundFoundation(_rotationSpeed * Time.deltaTime);
        }
    }
    
    private void RotateAroundFoundation(float angle)
    {
        transform.RotateAround(foundation.position, Vector3.up, angle);
    }
}
