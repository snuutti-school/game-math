using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private Transform cable;
    
    private void Update()
    {
        transform.position = new Vector3(
            cable.position.x,
            cable.position.y - cable.GetComponent<Renderer>().bounds.extents.y * 2,
            cable.position.z
        );
        
        transform.rotation = Quaternion.Euler(0, cable.rotation.eulerAngles.y, 0);
    }
}
