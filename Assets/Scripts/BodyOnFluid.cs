using UnityEngine;

public class BodyOnFluid : MonoBehaviour
{
    [Range(1, 2)]
    public float velocityExponent;
    public float dragConstant;

    private PhysicsBody physicsBody;

    private void Awake()
    {
        physicsBody = GetComponent<PhysicsBody>();
    }

    private void FixedUpdate()
    {
        physicsBody.AddForce(SetDragVector());
    }

    private float SetDragMagnitude(float _speed)
    {
        return dragConstant * Mathf.Pow(_speed, velocityExponent);
    }

    private Vector3 SetDragVector()
    {
        //Necessary parameters for drag
        Vector3 velocityVector = physicsBody.velocity;
        float speed = velocityVector.magnitude;

        float dragMagnitude = SetDragMagnitude(speed);

        return -dragMagnitude * velocityVector.normalized;
    }
}
