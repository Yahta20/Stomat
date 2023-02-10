using UnityEngine;
using UnityEngine.Rendering;

// The CreateAssetMenu attribute lets you create instances of this class in the Unity Editor.
[CreateAssetMenu(menuName = "Rendering/ExampleRenderPipelineAsset")]
public class PipelineAsset : RenderPipelineAsset
{
    // Unity calls this method before rendering the first frame.
    // If a setting on the Render Pipeline Asset changes, Unity destroys the current Render Pipeline Instance and calls this method again before rendering the next frame.

    public Color exampleColor;
    public string exampleString;
    protected override RenderPipeline CreatePipeline()
    {
        // Instantiate the Render Pipeline that this custom SRP uses for rendering.
        return new PipelineInstance(this);
    }
}

public class PipelineInstance : RenderPipeline
{
    private PipelineAsset renderPipelineAsset;

    //public PipelineInstance()
    //{
    //}
    public PipelineInstance(PipelineAsset asset)
    {
        renderPipelineAsset = asset;
    }


    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {
        Debug.Log(renderPipelineAsset.exampleString);
        // This is where you can write custom rendering code. Customize this method to customize your SRP.
    }
}