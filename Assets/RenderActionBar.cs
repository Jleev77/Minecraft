using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using UnityEngine.UI;

public class RenderActionBar : MonoBehaviour
{
    Image[] _itemSlots;
    Color _white = new Color(255, 255, 255);
    // Start is called before the first frame update
    void Start()
    {
        _itemSlots = GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        var inventory = Contexts.sharedInstance.game.playerEntity.container.GameEntities;
        if(inventory == null) return;
        for(int i = 0; i < _itemSlots.Length; i++){
            _itemSlots[i].color = inventory[i]?.resource.Material.color ?? _white;
        }
    }
}
