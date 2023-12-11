using UnityEngine;

public class Actor : MonoBehaviour
{
    public Color color = Color.black;

    private Head _head;
    private Shoulder _leftShoulder;
    private Shoulder _rightShoulder;
    private Body _body;

    private KeysMode _currentMode = KeysMode.Body;

    private enum KeysMode
    {
        Body, LeftShoulder, RightShoulder
    }

    private void Start()
    {
        _head = GetComponentInChildren<Head>();
        _leftShoulder = transform.GetChild(0).Find("ShoulderLeft").gameObject.GetComponent<Shoulder>();
        _rightShoulder = transform.GetChild(0).Find("ShoulderRight").gameObject.GetComponent<Shoulder>();
        _body = GetComponentInChildren<Body>();

        _body.SetColor(color);
    }

    private void Update()
    {
        ProcessMouse();
        ProcessKeys();
    }

    private void ProcessMouse()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        _head.Process(mouseX, mouseY);
    }

    private void ProcessKeys()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _currentMode = KeysMode.Body;
            Debug.Log("KeysMode: Body");
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            _currentMode = KeysMode.LeftShoulder;
            Debug.Log("KeysMode: LeftShoulder");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            _currentMode = KeysMode.RightShoulder;
            Debug.Log("KeysMode: RightShoulder");
        }

        int dirWS = Input.GetKey(KeyCode.W) ? 1 : (Input.GetKey(KeyCode.S) ? -1 : 0);
        int dirAD = Input.GetKey(KeyCode.A) ? 1 : (Input.GetKey(KeyCode.D) ? -1 : 0);

        if (dirWS == 0 && dirAD == 0)
        {
            return;
        }

        switch (_currentMode)
        {
            case KeysMode.Body:
                _body.Process(-1 * dirAD, dirWS);
                break;
            case KeysMode.LeftShoulder:
                _leftShoulder.Process(dirAD, dirWS);
                break;
            case KeysMode.RightShoulder:
                _rightShoulder.Process(dirAD, dirWS);
                break;
        }
    }
}
