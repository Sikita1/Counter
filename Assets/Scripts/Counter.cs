using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Tumbler _tumbler;
    [SerializeField] private Text _text;

    private float _delay = 0.5f;
    private Coroutine _coroutine;
    private int _currentValue = 0;

    private WaitForSeconds _wait;
    private int _maxCountTimer = 9999;

    private void Start()
    {
        DisplayCountUp(_currentValue);
    }

    private void OnEnable()
    {
        _tumbler.Switching += StartTimer;
    }

    private void OnDisable()
    {
        _tumbler.Switching -= StartTimer;
    }

    private void StartTimer()
    {
        if (_tumbler.Condition)
            _coroutine = StartCoroutine(CountUp());
        else
            StopCoroutine(_coroutine);
    }

    private IEnumerator CountUp()
    {
        _wait = new WaitForSeconds(_delay);

        if (_tumbler.Condition)
        {
            for (int i = _currentValue; i < _maxCountTimer; i++)
            {
                _currentValue = i;
                DisplayCountUp(_currentValue);
                yield return _wait;
            }
        }
        else
        {
            DisplayCountUp(_currentValue);
        }
    }

    private void DisplayCountUp(int count)
    {
        _text.text = count.ToString();
    }
}
