using UnityEngine;


public class ForceApplier : MonoBehaviour
{
    [SerializeField] Vector3 forceV3;

    public void ApplyForce() 
    {
        Rigidbody targetObject = GetComponent<Rigidbody>();
        targetObject.AddForce(forceV3, ForceMode.Impulse);
    }
}
