using System;
using TMPro;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private int _appleCount = 0;
    
    public TextMeshProUGUI appleCountText;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Apple"))
        {
            GameManager.instance.apples++;
            _appleCount++;
            appleCountText.text = _appleCount.ToString();
            Destroy(other.gameObject);
        }
    }
}
