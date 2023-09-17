using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthAnimation : MonoBehaviour
{
    private const int MaxValue = 1;
    private const int Multiplier = 2;
    
    [SerializeField] private Unit unit;
    [SerializeField] private MeshRenderer meshRenderer;

    private Coroutine _coroutine;

    private void Start() => 
        unit.HealthChanged += Damageable_OnHealthChanged;

    private void OnDestroy() => 
        unit.HealthChanged -= Damageable_OnHealthChanged;

    private void Damageable_OnHealthChanged(int lastHealth, int health)
    {
        if (health > 0 && lastHealth > health)
            PlayAnimation();
    }

    private void PlayAnimation()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        yield return ColorSwitch(Color.white, Color.red);
        yield return ColorSwitch(Color.red, Color.white);

        _coroutine = null;
    }

    private IEnumerator ColorSwitch(Color from, Color to)
    {
        for (float t = MaxValue; t > 0; t -= Time.deltaTime * Multiplier)
        {
            meshRenderer.material.color = Color.Lerp(to, from, t);
            yield return null;
        }
    }
}
