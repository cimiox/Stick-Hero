using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStickState
{
    void Handle(Stick stick);
    IEnumerator DoStateAction(Stick stick);
}
