using UnityEngine;
using UnityEngine.UI;

public class Cable : MonoBehaviour
{
    [SerializeField] private Transform trolley;
    
    [SerializeField] private Slider slider;
    
    private float _minLength = 0.0f;
    private float _maxLength = 20.0f;
    
    private Vector3 _initialPositionOffset;
    
    private void Start()
    {
        _initialPositionOffset = transform.position - trolley.position;
    }
    
    private void Update()
    {
        FollowTrolley();
        AdjustCableLength(slider.value);
    }
    
    private void FollowTrolley()
    {
        transform.position = trolley.position + _initialPositionOffset;
        transform.rotation = Quaternion.Euler(0, trolley.rotation.eulerAngles.y, 0);
    }

    private void AdjustCableLength(float length)
    {
        var scaleFactor = Mathf.Lerp(_minLength, _maxLength, length) / 10f;

        var newScale = transform.localScale;
        newScale.y = scaleFactor;

        transform.localScale = newScale;

        _initialPositionOffset = new Vector3(0, -scaleFactor / 2.0f, 0);
    }
}
