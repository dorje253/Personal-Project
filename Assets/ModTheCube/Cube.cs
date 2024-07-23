using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    private Material material;
    private Color startColor;
    private Color endColor;
    private float colorChangeDuration = 5.0f;
    private float colorChangeTimer;

    void Start()
    {
        // Randomize position
        float randomX = Random.Range(-10.0f, 10.0f);
        float randomY = Random.Range(0.0f, 10.0f);
        float randomZ = Random.Range(-10.0f, 10.0f);
        transform.position = new Vector3(randomX, randomY, randomZ);

        // Randomize scale
        float randomScale = Random.Range(0.5f, 2.0f);
        transform.localScale = Vector3.one * randomScale;

        // Get the material
        material = Renderer.material;

        // Randomize initial color
        startColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        material.color = startColor;

        // Set the end color for color change over time
        endColor = new Color(Random.value, Random.value, Random.value, 1.0f);

        // Initialize the timer
        colorChangeTimer = 0.0f;
    }

    void Update()
    {
        // Rotate the cube
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);

        // Update the timer
        colorChangeTimer += Time.deltaTime;

        // Change the color over time
        if (colorChangeTimer <= colorChangeDuration)
        {
            float t = colorChangeTimer / colorChangeDuration;
            material.color = Color.Lerp(startColor, endColor, t);
        }
        else
        {
            // Reset the timer and colors for a new color change cycle
            colorChangeTimer = 0.0f;
            startColor = material.color;
            endColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        }
    }
}