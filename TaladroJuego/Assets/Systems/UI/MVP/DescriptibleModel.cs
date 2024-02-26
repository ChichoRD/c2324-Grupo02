﻿using MVPFramework.Model;
using UnityEngine;

namespace UISystem.MVP
{
    [CreateAssetMenu(fileName = "Descriptible Model", menuName = "UI/MVP/DescriptibleModel")]
    internal class DescriptibleModel : ScriptableObject,
        IModel<DescriptibleModel.Data>,
        IModel<(string name, string description)>
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        [TextArea]
        private string _description;

        public Data Capture() => new Data(_name, _description);

        (string name, string description) IModel<(string name, string description)>.Capture() =>
            (_name, _description);

        public readonly struct Data
        {
            public readonly string name;
            public readonly string description;

            public Data(string name, string description)
            {
                this.name = name;
                this.description = description;
            }
        }
    }
}