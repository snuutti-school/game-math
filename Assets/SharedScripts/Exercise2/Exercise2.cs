using System.Collections;
using UnityEngine;

public class Exercise2 : MonoBehaviour
{
    [SerializeField] private Tower tower;
    [SerializeField] private Trolley trolley;
    [SerializeField] private Cable cable;
    [SerializeField] private Concrete concrete;
    
    private bool _isMoving;
    
    private void Update()
    {
        if (_isMoving)
        {
            return;
        }
        
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out var hit))
        {
            return;
        }

        if (hit.collider.gameObject.name != "Concrete")
        {
            return;
        }
        
        _isMoving = true;
        StartCoroutine(MoveEverything(hit.transform));
    }

    private IEnumerator MoveEverything(Transform concreteTransform)
    {
        Debug.Log("Moving...");
        
        yield return tower.RotateToFaceConcrete(concreteTransform);
        yield return trolley.MoveTrolleyToConcrete(concreteTransform);
        yield return cable.MoveToValue(0.91f);
        
        Debug.Log("Concrete attached.");
        yield return new WaitForSeconds(1);
        Debug.Log("Moving to top...");
        
        yield return cable.MoveToValue(0f);
        Debug.Log("Done.");
        
        yield return new WaitForSeconds(1);

        concrete.DetachAndMove();
        
        _isMoving = false;
    }
}
