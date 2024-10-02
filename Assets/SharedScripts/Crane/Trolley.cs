using UnityEngine;
using UnityEngine.UI;

public class Trolley : MonoBehaviour
{
    [SerializeField] private Transform tower;
    [SerializeField] private Transform limit1;
    [SerializeField] private Transform limit2;
    
    [SerializeField] private Slider slider;
    
    private void Update()
    {
        var targetPosition = Vector3.Lerp(limit1.position, limit2.position, slider.value);

        var directionFromCrane = targetPosition - tower.position;
        directionFromCrane = tower.rotation * directionFromCrane;

        transform.position = tower.position + directionFromCrane;
        transform.rotation = Quaternion.Euler(0, tower.rotation.eulerAngles.y, 0);
    }
}
