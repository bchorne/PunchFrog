using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    MaterialPropertyBlock matBlock;
    MeshRenderer meshRenderer;
    Camera mainCamera;
    Enemy enemy;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        matBlock = new MaterialPropertyBlock();
        // get the damageable parent we're attached to
        enemy = GetComponentInParent<Enemy>();
    }

    private void Start()
    {
        // Cache since Camera.main is super slow
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Only display on partial health
        if (enemy.curHealth < enemy.maxHealth)
        {
            meshRenderer.enabled = true;
            AlignCamera();
            UpdateParams();
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }

    private void UpdateParams()
    {
        meshRenderer.GetPropertyBlock(matBlock);
        matBlock.SetFloat("_Fill", enemy.curHealth / (float)enemy.maxHealth);
        meshRenderer.SetPropertyBlock(matBlock);
    }

    private void AlignCamera()
    {
        if (mainCamera != null)
        {
            var camXform = mainCamera.transform;
            var forward = transform.position - camXform.position;
            forward.Normalize();
            var up = Vector3.Cross(forward, camXform.right);
            transform.rotation = Quaternion.LookRotation(forward, up);
        }
    }

}
