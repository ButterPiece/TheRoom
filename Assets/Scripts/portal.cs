
using UnityEngine;

public class portal : MonoBehaviour
{
    [SerializeField] private Transform _outPort;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = _outPort.position;
        float rotY = _outPort.rotation.eulerAngles.y;
        other.transform.rotation = Quaternion.Euler(other.transform.rotation.x, rotY - 100, other.transform.rotation.z);
    }
}
