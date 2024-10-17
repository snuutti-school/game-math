using System.Collections;
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
    
    public IEnumerator RotateToFaceConcrete(Transform concrete)
    {
        var concreteDirection = (concrete.position - foundation.position).normalized;
        concreteDirection.y = 0;
        
        while (true)
        {
            var craneForward = Quaternion.Euler(0, -90, 0) * transform.forward;
            craneForward.y = 0;

            var angleToConcrete = Vector3.SignedAngle(craneForward, concreteDirection, Vector3.up);

            if (Mathf.Abs(angleToConcrete) < 0.1f)
            {
                yield break;
            }

            var rotationStep = Mathf.Sign(angleToConcrete) * _rotationSpeed * Time.deltaTime;
            RotateAroundFoundation(rotationStep);
            
            yield return null;
        }
    }
}
