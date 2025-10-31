using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffectable
{
    public void Add(BuffDataSO buffData);
    public void ApplyEffect(BuffDataSO buff);  
    public void RemoveEffect(BuffDataSO buffData);    

}
