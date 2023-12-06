using MixedReality.Toolkit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MRTKExtensions.SpeechRecognition
{
    public class SpeechInputHandler : MonoBehaviour
    {
        [SerializeField]
        private List<PhraseAction> phraseActions;

        private void Start()
        {
            var phraseRecognitionSubsystem = XRSubsystemHelpers.KeywordRecognitionSubsystem;
            foreach (var phraseAction in phraseActions)
            {
                if (!string.IsNullOrEmpty(phraseAction.Phrase) && phraseAction.Action.GetPersistentEventCount() > 0)
                {
                    phraseRecognitionSubsystem.CreateOrGetEventForKeyword(phraseAction.Phrase).AddListener(() => phraseAction.Action.Invoke());
                }
            }
        }

        private void OnValidate()
        {
            var multipleEntries = phraseActions.GroupBy(p => p.Phrase).Where(p => p.Count() > 1).ToList();
            if (multipleEntries.Any())
            {
                var errorMessage = new StringBuilder();
                errorMessage.AppendLine("Some phrases defined are more than once , this is not allowed");
                foreach (var phraseGroup in multipleEntries)
                {
                    errorMessage.AppendLine($"- {phraseGroup.Key}");
                }
                Debug.LogError(errorMessage);
            }
        }
    }
}
