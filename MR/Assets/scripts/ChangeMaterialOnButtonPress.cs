using UnityEngine;

public class MultiMaterialColorChangeScript : MonoBehaviour
{
    [Header("Material Settings")]
    public Material startMaterial;
    public Material switchMaterial;

    private bool isSwitched = false;
    private Renderer[] myRenderers;

    private bool colorChanged = false; // Added flag to track if color change has occurred

    void Start()
    {
        // Get the renderers only from this object (not children)
        myRenderers = GetComponents<Renderer>();

        // Set the initial materials
        SetMaterials();
    }

    public void TriggerMaterialChange()
    {
        // Check if color has already changed, and exit if it has
        if (colorChanged)
        {
            return;
        }

        // Toggle between startMaterial and switchMaterial
        isSwitched = !isSwitched;

        // Apply the materials
        SetMaterials();

        // Set the flag to true to indicate color change has occurred
        colorChanged = true;
    }

    private void SetMaterials()
    {
        foreach (Renderer renderer in myRenderers)
        {
            Material[] materials = renderer.materials;

            for (int i = 0; i < materials.Length; i++)
            {
                if (isSwitched)
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
}
