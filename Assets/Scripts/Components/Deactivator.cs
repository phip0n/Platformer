using UnityEngine;

public class Deactivator : MonoBehaviour
{
    [SerializeField] private GameObject _object;

    public void Deactivate()
    {
        _object.SetActive(false);
    }
}