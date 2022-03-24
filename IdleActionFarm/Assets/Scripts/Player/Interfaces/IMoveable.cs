using System;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    public Action<GameObject> OnMovedPack { get; set; }
    public Action OnMovedPacks { get; set; }

    public void Setup(Transform distanse, Vector3 positionOffsetStep, float speed);
    public void MovePack(GameObject pack);
    public void MovePacks(List<GameObject> packs);
    public void ClearOffset();

}
