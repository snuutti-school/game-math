using UnityEngine;

public class Concrete : MonoBehaviour
{
    [SerializeField] private Collider hook;
    [SerializeField] private Trolley trolley;

    [SerializeField] private ParticleSystem vfx;
    
    private bool _isAttached;
    
    private void Update()
    {
        if (!_isAttached)
        {
            return;
        }
        
        transform.position = hook.bounds.center;
        transform.rotation = Quaternion.Euler(0, hook.transform.rotation.eulerAngles.y, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_isAttached)
        {
            return;
        }

        _isAttached = true;
        vfx.Play();
        GetComponent<Collider>().enabled = false;
    }

    public void DetachAndMove()
    {
        var newConcretePosition = trolley.GetNewConcretePosition();
        transform.position = new Vector3(newConcretePosition.x, 10f, newConcretePosition.y);

        _isAttached = false;
        GetComponent<Collider>().enabled = false;
    }
}
