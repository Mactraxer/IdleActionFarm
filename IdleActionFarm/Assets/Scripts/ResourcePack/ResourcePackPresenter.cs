using UnityEngine;

[RequireComponent(typeof(ResourcePackAnimator))]
[RequireComponent(typeof(ResourcePackData))]
public class ResourcePackPresenter : MonoBehaviour
{
    private ResourcePackAnimator _animator;
    private ResourcePackData _data;
    private Collider _collider;

    private void Start()
    {
        _animator = GetComponent<ResourcePackAnimator>();
        _data = GetComponent<ResourcePackData>();
        _collider = GetComponent<Collider>();

        _animator.StartAnimate();
    }

    public void ResourcePicked()
    {
        _animator.StopAnimate();
        _collider.enabled = false;
    }

}
