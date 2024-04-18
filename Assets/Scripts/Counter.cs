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

    private void Start()
    {
        DisplayCountUp(_currentValue);
    }

    private void OnEnable()
    {
        _tumbler.Switching += OnSwitchong;
    }

    private void OnDisable()
    {
        _tumbler.Switching -= OnSwitchong;
    }

    private void OnSwitchong()
    {
        if (_tumbler.IsOn)
        {
            _coroutine = StartCoroutine(CountUp());
        }
        else
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }
    }

    private IEnumerator CountUp()
    {
        _wait = new WaitForSeconds(_delay);

        while (_tumbler.IsOn)
        {
            _currentValue++;
            DisplayCountUp(_currentValue);
            yield return _wait;
        }
    }

    private void DisplayCountUp(int count)
    {
        _text.text = count.ToString();
    }
}
