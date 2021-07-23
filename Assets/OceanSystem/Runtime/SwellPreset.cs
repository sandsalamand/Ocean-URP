using EditorExtras;
using UnityEngine;

namespace OceanSystem
{
    [CreateAssetMenu(fileName = "New Swell", menuName = "Ocean/Swell")]
    public class SwellPreset : ScriptableObject
    {
        [Box("Spectrum")]
        [ExtendedProperty(true)]
        [SerializeField] private SpectrumParams _spectrum = SpectrumParams.GetDefaultSwell();

        [Box("Others")]
        [SerializeField] private float _referenceWaveHeight;

        public float ReferenceWaveHeight => _referenceWaveHeight;
        public SpectrumParams Spectrum => _spectrum;
    }
}
