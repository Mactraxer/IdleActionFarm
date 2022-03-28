using UnityEngine;

[RequireComponent(typeof(ResourcePackAnimator))]
[RequireComponent(typeof(ResourcePackData))]
public class ResourcePackPresenter : MonoBehaviour, IResourceable, IMoveable
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

    /// 
    /// IResourceable
    /// 
    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public ResourcePackData GetResourceData()
    {
        return _data;
    }

    ///
    /// IMoveable
    /// 
    public Vector3 GetPosition => transform.position;

    public Quaternion GetRotate => transform.rotation;

    public Vector3 GetScale => transform.localScale;

    public void SetPosition(Vector3 newVector)
    {
        transform.position = newVector;
    }

    public void ChangeParent(Transform parent)
    {
        transform.parent = parent;
    }

    public void SetRotate(Quaternion quaternion)
    {
        transform.rotation = quaternion;
    }

    public void SetScale(Vector3 scale)
    {
        transform.localScale = scale;
    }
}
