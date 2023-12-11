using UnityEngine;

public class Body : MonoBehaviour
{
    public float speed = 1;

    public void Process(int dirX, int dirZ)
    {
        float moveX = dirX * speed * Time.deltaTime;
        float moveZ = dirZ * speed * Time.deltaTime;

        transform.Translate(new Vector3(moveX, 0, moveZ));
    }

    public void SetColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }
}