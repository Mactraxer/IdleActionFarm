using UnityEngine;
public interface IResourceable 
{
    public void ResourcePicked();

    public void DestroySelf();

    public ResourcePackData GetResourceData();
}

