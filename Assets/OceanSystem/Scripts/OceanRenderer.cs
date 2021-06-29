using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace OceanSystem
{
    public class OceanRenderer : ScriptableRendererFeature
    {
        [SerializeField] private OceanRenderingSettings settings;

        OceanGeometryPass geometryPass;
        OceanUnderwaterEffectPass underwaterPass;
        OceanSkyMapPass skyMapPass;

        public override void Create()
        {
            underwaterPass = new OceanUnderwaterEffectPass(settings);
            skyMapPass = new OceanSkyMapPass(settings);
            geometryPass = new OceanGeometryPass(settings);
            name = "Ocean";
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            skyMapPass.renderPassEvent = RenderPassEvent.BeforeRenderingTransparents;
            renderer.EnqueuePass(skyMapPass);
            underwaterPass.renderPassEvent = RenderPassEvent.BeforeRenderingTransparents;
            renderer.EnqueuePass(underwaterPass);
            geometryPass.renderPassEvent = RenderPassEvent.BeforeRenderingTransparents;
            renderer.EnqueuePass(geometryPass);
        }

        private void OnValidate()
        {
            settings.skyMapResolution = Mathf.Clamp(settings.skyMapResolution, 16, 2048);
        }

        [System.Serializable]
        public class OceanRenderingSettings
        {
            public int skyMapResolution = 256;
            public bool updateSkyMap;
            public bool transparency;
            public bool underwaterEffect;
        }
    }
}