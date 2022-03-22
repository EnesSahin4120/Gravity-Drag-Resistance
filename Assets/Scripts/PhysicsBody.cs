using UnityEngine;

public class PhysicsBody : MonoBehaviour
{
    public float mass;
    public Vector3 velocity;

    private PhysicsBody[] physicsBodies;
    private const float G = 6.673e-11f;

    private void Awake()
    {
        physicsBodies = FindObjectsOfType<PhysicsBody>();
    }

    private void FixedUpdate()
    {
        SetVelocity();
        SetGravityForce();
    }

    private void SetGravityForce()
    {
        foreach(PhysicsBody physicsBody_A in physicsBodies)
        {
            foreach(PhysicsBody physicsBody_B in physicsBodies)
            {
                if (physicsBody_A != physicsBody_B)
                {
                    Vector3 distanceVector = physicsBody_A.transform.position - physicsBody_B.transform.position;
                    float distanceMagnitude = distanceVector.magnitude;
                    float gravityMagnitude = G * physicsBody_A.mass * physicsBody_B.mass / (Mathf.Pow(distanceMagnitude, 2));

                    Vector3 gravityVector = gravityMagnitude * distanceVector.normalized;
                    physicsBody_A.AddForce(-gravityVector);
                }
            }
        }
    }

    public void AddForce(Vector3 forceVector)
    {
        Vector3 accelerationVector = forceVector / mass;
        velocity += accelerationVector * Time.deltaTime;
    }

    private void SetVelocity()
    {
        transform.position += velocity * Time.deltaTime;
    }
}
