using System;
using System.Collections.Generic;
using UnityEngine;

public interface IMoverable
{
    public Action<IMoveable> OnMovedPack { get; set; }
    public Action OnMovedPacks { get; set; }

    public void Setup(Transform distanse, Vector3 positionOffsetStep, float speed);
    public void Move(IMoveable item);
    public void Move(List<IMoveable> items);
    public void ClearOffset();

}
