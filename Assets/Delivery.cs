using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;

    [SerializeField]
    Color32 hasPackageColor = new Color32(0, 0, 255, 255);

    [SerializeField]
    Color32 hasNoPackageColor = new Color32(0, 0, 255, 255);

    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Debug.Log("Something was reached.");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(!hasPackage && other.tag == "Package") {
            hasPackage = true;
            Destroy(other.gameObject, .3f);
            spriteRenderer.color = hasPackageColor;
            Debug.Log("Package taked.");
        } else if (hasPackage && other.tag == "Customer") {
            hasPackage = false;
            spriteRenderer.color = hasNoPackageColor;
            Debug.Log("Delivered.");
        }
    }
}
