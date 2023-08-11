using UnityEngine;
using Dreamteck.Splines;

public class CardThrow : MonoBehaviour
{
    [SerializeField] private GameObject[] _cards;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private SplineComputer _splineComputer;

    private Card _card;
    public bool CanThrow;

    private void Start()
    {
        CreateCard();
    }

    private void CreateCard()
    {
        GameObject card = Instantiate(_cards[Random.Range(0, _cards.Length)], _spawnPoint);
        _card = card.GetComponent<Card>();
        _card.SetPath(_splineComputer);

        //Some delay needed, because card appear With animation
        Invoke("AllowThrow", 0.3f);
    }
    
    public void Throw()
    {
        _card.Throw();
        CanThrow = false;
        Invoke("CreateCard", 1f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && _card && Level.IsPlaying)
        {
            Throw();
        }
    }

    private void AllowThrow()
    {
        if (Level.IsPlaying)
            CanThrow = true;
    }
}
