using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public interface IDamageable{
        public void Damage(float value);
        public void Death();
    }
}