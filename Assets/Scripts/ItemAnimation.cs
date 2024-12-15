using DG.Tweening;
using UnityEngine;

public class ItemAnimation : MonoBehaviour
{
    [SerializeField] private Transform item;
    [SerializeField] private ParticleSystem particles;

    public void Spawn()
    {
        gameObject.SetActive(true);

        transform.DOScale(transform.localScale, 1).From(0).SetEase(Ease.OutBounce);
    }

    public void Correctly()
    {
        particles.gameObject.SetActive(true);

        item.DOShakeScale(1, 0.5f, 5).SetEase(Ease.InBounce);
    }

    public void Wrong()
    {
        item.DOShakePosition(0.5f, Vector3.right * 0.1f, 10, 0).SetEase(Ease.InBounce);
    }
}
