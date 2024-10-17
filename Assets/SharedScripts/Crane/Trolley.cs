using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Trolley : MonoBehaviour
{
    [SerializeField] private Transform tower;
    [SerializeField] private Transform limit1;
    [SerializeField] private Transform limit2;
    
    [SerializeField] private Slider slider;
    
    private float _movementSpeed = 20f;
    
    private void Update()
    {
        var targetPosition = Vector3.Lerp(limit1.position, limit2.position, slider.value);

        var directionFromCrane = targetPosition - tower.position;
        directionFromCrane = tower.rotation * directionFromCrane;

        transform.position = tower.position + directionFromCrane;
        transform.rotation = Quaternion.Euler(0, tower.rotation.eulerAngles.y, 0);
    }

    public Vector2 GetNewConcretePosition()
    {
        var limit1Proj = new Vector2(limit1.position.x, limit1.position.z);
        var limit2Proj = new Vector2(limit2.position.x, limit2.position.z);

        var innerRadius = Vector2.Distance(limit1Proj, Vector2.zero);
        var outerRadius = Vector2.Distance(limit2Proj, Vector2.zero);

        Vector2 randomPosition;
        do
        {
            var randomAngle = Random.Range(0, 2 * Mathf.PI);
            var randomRadius = Random.Range(innerRadius, outerRadius);

            var x = Mathf.Cos(randomAngle) * randomRadius;
            var z = Mathf.Sin(randomAngle) * randomRadius;

            randomPosition = new Vector2(x, z);

        } while (!IsPositionValid(randomPosition));

        return randomPosition;
    }
    
    private bool IsPositionValid(Vector2 position)
    {
        var limit1Proj = new Vector2(limit1.position.x, limit1.position.z);
        var limit2Proj = new Vector2(limit2.position.x, limit2.position.z);

        var distanceFromOrigin = position.magnitude;
        var innerRadius = limit1Proj.magnitude;
        var outerRadius = limit2Proj.magnitude;

        return distanceFromOrigin >= innerRadius && distanceFromOrigin <= outerRadius;
    }
    
    public IEnumerator MoveTrolleyToConcrete(Transform concrete)
    {
        while (true)
        {
            var concreteProj = Vector3.ProjectOnPlane(concrete.position, Vector3.up);
            var trolleyProj = Vector3.ProjectOnPlane(transform.position, Vector3.up);
            
            var distanceToConcrete = Vector3.Distance(trolleyProj, concreteProj);
            if (distanceToConcrete < 0.1f)
            {
                // Close enough
                yield break;
            }

            var newTrolleyPosition = Vector3.MoveTowards(transform.position, concreteProj,
                _movementSpeed * Time.deltaTime);
            newTrolleyPosition = Vector3.ClampMagnitude(newTrolleyPosition - limit1.position,
                Vector3.Distance(limit1.position, limit2.position)) + limit1.position;

            // Kinda hacky but allows me to reuse the code from the Update method
            slider.value = Mathf.InverseLerp(limit1.position.x, limit2.position.x, newTrolleyPosition.x);

            yield return null;
        }
    }
}
