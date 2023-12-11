using UnityEngine;

public class Shoulder : MonoBehaviour
{
    public float speedHor = 1;
    public float speedVer = 1;
    public float minHor = -20;
    public float maxHor = 20;
    public float minVer = -10;
    public float maxVer = 10;

    private float _rotY;
    private float _rotX;

    public void Process(int dirX, int dirY)
    {
        _rotY += dirX * speedHor * Time.deltaTime;
        _rotY = Mathf.Clamp(_rotY, minHor, maxHor);
        _rotX -= dirY * speedVer * Time.deltaTime;
        _rotX = Mathf.Clamp(_rotX, minVer, maxVer);
        transform.localEulerAngles = new Vector3(_rotX, _rotY, 0);
    }
}
