using Prime31.MessageKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets._FieldTripper.scripts
{
    public class sequenceManager : MonoBehaviour
    {
        private List<string> sequence = new List<string>();

        [SerializeField]
        private List<string> answer;

        private void Start()
        {
            MessageKit<string>.addObserver((int)messages.tapped, ImageTapped);
        }

        private void ImageTapped(String id)
        {
            sequence.Add(id);

            if (sequence.Count > answer.Count)
            {
                sequence = sequence.GetRange(1, sequence.Count - 1);
            }

            if (sequence.Equals(answer) == true)
            {
                MessageKit<string>.post((int)messages.correctSequence, id);
            }
        }
    }
}
