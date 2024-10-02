using System;
using UnityEngine;

public class Concrete : MonoBehaviour
{
    [SerializeField] private Collider hook;

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
}
