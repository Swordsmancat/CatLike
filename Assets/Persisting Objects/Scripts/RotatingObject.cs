using UnityEngine;

public class RotatingObject : PersistableObject
{
    [SerializeField]
    Vector3 angularVelocity;

    public  void GameUpdate()
    {
        transform.Rotate(angularVelocity * Time.deltaTime);
    }
}

