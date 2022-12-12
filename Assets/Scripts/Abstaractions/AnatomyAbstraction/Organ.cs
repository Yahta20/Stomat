using System;
using UnityEngine;

namespace KHNMU.BodyAnatomy.AnatomyAbstraction
{
    struct Organ
    {
        //-++++++++++++++++++++++++++++++++++
        AnatomySystem _serveSystem;
        Mesh _organMesh;
          
        
        
        OrganState _organState;

        public OrganState OrganState { get => _organState; set => _organState = value; }
    }
}