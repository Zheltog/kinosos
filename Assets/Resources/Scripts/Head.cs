using UnityEngine;

public class Head : MonoBehaviour
{
    public float senHor = 1;
    public float senVer = 1;
    public float minHor = -20;
    public float maxHor = 20;
    public float minVer = -10;
    public float maxVer = 10;

    private float _rotY;
    private float _rotX;

    public void Process(float deltaX, float deltaY)
    {
        _rotY += deltaX * senHor;
        _rotY = Mathf.Clamp(_rotY, minHor, maxHor);
        _rotX -= deltaY * senVer;
        _rotX = Mathf.Clamp(_rotX, minVer, maxVer);
        transform.localEulerAngles = new Vector3(_rotX, _rotY, 0);
    }
}
