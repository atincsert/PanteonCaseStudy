using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintable : MonoBehaviour
{
    public Material mat;
    public Vector3 size = new Vector3(100, 10, 100);

    [SerializeField] private Color paintColor;

    private void Update()
    {
        if (!Input.GetMouseButton(0))
            return;

        RaycastHit hit;
        if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            return;

        if (!hit.collider.gameObject.CompareTag("Paintable")) 
            return;

        Renderer rend = hit.transform.GetComponent<Renderer>();
        MeshCollider meshCollider = hit.collider as MeshCollider;

        if ((rend == null) || (rend.sharedMaterial == null) || (rend.sharedMaterial.mainTexture == null) || (meshCollider == null))
            return;

        Texture2D tex = rend.material.mainTexture as Texture2D;
        Vector2 pixelUV = hit.textureCoord;
        pixelUV.x *= tex.width;
        pixelUV.y *= tex.height;

        tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, paintColor);
        tex.SetPixel((int)pixelUV.x + 1, (int)pixelUV.y, paintColor);
        tex.SetPixel((int)pixelUV.x - 1, (int)pixelUV.y, paintColor);
        tex.SetPixel((int)pixelUV.x, (int)pixelUV.y + 1, paintColor);
        tex.SetPixel((int)pixelUV.x, (int)pixelUV.y - 1, paintColor);


        tex.Apply();


        ControlForAllPixels();
    }

    private void OnApplicationQuit()
    {
        Texture2D tex = GetComponent<Renderer>().material.mainTexture as Texture2D;
        for (int x = 0; x < tex.width; x++)
        {
            for (int y = 0; y < tex.height; y++)
            {
                tex.SetPixel(x, y, Color.white);
            }
        }
        tex.Apply();
    }

    private void ControlForAllPixels()
    {
        Texture2D tex = GetComponent<Renderer>().material.mainTexture as Texture2D;
        for (int x = 0; x < tex.width; x++)
        {
            for (int y = 0; y < tex.height; y++)
            {
                Color newColor = tex.GetPixel(x, y);
                if (newColor != Color.red)
                {
                    return;
                }
            }
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}

