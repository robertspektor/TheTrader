﻿using ScriptableObjects;
using UnityEngine;

namespace Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Item : MonoBehaviour
    {
        public ItemData data;
        
        [HideInInspector] public Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }
}