using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Damageable))]
public class DamageAnimation : MonoBehaviour
{
    [SerializeField] private Transform _sprites;
    [SerializeField] private Material _onDamage;
    [SerializeField] private Material _default;
    [SerializeField] private float _dealy;
    private HashSet<SpriteRenderer> spriteRenderers;

    private void Start()
    {
        spriteRenderers = new HashSet<SpriteRenderer>();
        GetComponent<Damageable>().OnDamage += DamageAnimation_OnDamage;
        var c = ChildEnumerator.EnumerateChildrenRecursive(_sprites);
        foreach (Transform sprite in c)
        {
            if (sprite.TryGetComponent<SpriteRenderer>(out var sr))
            {
                if (!spriteRenderers.Contains(sr))
                    spriteRenderers.Add(sr);
            }
        }
    }

    private void DamageAnimation_OnDamage(float dmg)
    {
        if (dmg <= 0)
            return;
        StartCoroutine(AnimateDamage());
    }

    private IEnumerator AnimateDamage()
    {
        SetMaterial(_onDamage);
        yield return new WaitForSeconds(_dealy);
        SetMaterial(_default);
    }

    private void SetMaterial(Material material)
    {
        foreach (var renderer in spriteRenderers)
        {
            renderer.material = material;
        }
    }
}
