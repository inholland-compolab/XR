using UnityEngine;

public class MultiMaterialColorChangeScript : MonoBehaviour
{
    [Header("Material Settings")]
    public Material startMaterial;
    public Material switchMaterial;

    private bool isSwitched = false;
    private Renderer[] myRenderers;

    private bool colorChanged = false; // Added flag to track if color change has occurred

    void OnEnable()
    {
        // Get the renderers only from this object (not children)
        myRenderers = GetComponents<Renderer>();

        // Set the initial materials
        ResetMaterials();
    }

    public void TriggerMaterialChange()
    {
        // Check if color has already changed, and exit if it has
        if (colorChanged)
        {
            return;
        }

        // Set the flag to true to indicate color change has occurred
        colorChanged = true;

        // Apply the materials
        SetMaterials();
    }

    public void ResetMaterials()
    {
        colorChanged = false;
        SetMaterials();
    }

    private void SetMaterials()
    {
        foreach (Renderer renderer in myRenderers)
        {
            Material[] materials = renderer.materials;

            for (int i = 0; i < materials.Length; i++)
            {
                if (colorChanged)
                {
                    materials[i] = switchMaterial;
                }
                else
                {
                    materials[i] = startMaterial;
                }
            }

            renderer.materials = materials;
        }
    }

    public void SetSwitchMaterial()
    {
        foreach (Renderer renderer in myRenderers)
        {
            renderer.sharedMaterial = switchMaterial;
        }
        colorChanged = false;
    }

    public void SetStartMaterial()
    {
        foreach (Renderer renderer in myRenderers)
        {
            renderer.sharedMaterial = startMaterial;
        }
    }

    public void ForceSwitchMaterial()
    {
        foreach (Renderer renderer in myRenderers)
            if (renderer.sharedMaterial == startMaterial)
            {
                renderer.sharedMaterial = switchMaterial;
                colorChanged = true;
            } else {
                renderer.sharedMaterial = startMaterial;
                colorChanged = false;
            }
    }
}
