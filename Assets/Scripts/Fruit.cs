using UnityEngine;
using DG.Tweening;

public class Fruit : MonoBehaviour
{
    [SerializeField] private Transform _mesh, _parts;
    [SerializeField] private Vector3 _rotationVector;

    [Space]
    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private float _force;
    [SerializeField] private GameObject _particle;
    private float _appearTime = 0.2f;

    private void Start()
    {
        Level.AssignBanana();
        AnimateAppear();
    }

    private void AnimateAppear()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(1f, _appearTime).SetDelay(Random.Range(0.1f, 0.3f));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Card>())
        {
            CutBanana();
        }
    }

    private void CutBanana()
    {
        _parts.gameObject.SetActive(true);
        _parts.SetParent(null);
        foreach (Rigidbody rigidbody in _rigidbodies)
        {

            rigidbody.AddForceAtPosition(Vector3.up * _force, _mesh.position);
        }

        _particle.transform.SetParent(null);
        _particle.SetActive(true);

        Level.AddBananaToScore();
        Destroy(gameObject);
    }
    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        _mesh.Rotate(_rotationVector * Time.deltaTime);
    }
}
