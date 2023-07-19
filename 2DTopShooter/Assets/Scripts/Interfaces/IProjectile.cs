using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectile
{
    public GameObject SelfRef { get; set;  }
    public void Project(Vector2 direction, float damage);
}
