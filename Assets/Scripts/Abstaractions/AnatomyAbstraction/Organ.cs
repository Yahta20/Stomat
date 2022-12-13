using System;
using UnityEngine;

namespace KHNMU.BodyAnatomy.AnatomyAbstraction
{
    struct Cell
    {

        /*
         * 
        //surface complex   поверхневий комплекс
            //літинної мембрани (плазмолеми)
            //глікокаліксу, 
            //кортикального шару цитоплазми
        //cytoplasm         цитоплазма
            //гіалоплазму (матрикс, цитозоль), 
            //органели  
            //включення
        //core 
            //каріолема (каріотека), 
            //каріоплазма 
            //хромосоми. 
        //
         *
         *
         *
         */
    }
    struct Textus// tkanyna //tissue
    {
        Cell _textusCell;


        /*
        
         */
    }
    struct Organum
    {
        public enum OrganumConditio
        {
            DEFAULT,
            DONORED,
            PREPARAT,
        }
        //-++++++++++++++++++++++++++++++++++
        //AnatomySystem _serveSystem;
        Textus _organTextus;
        Mesh _organMesh;
          
        
        
        OrganumConditio _organState;

        public OrganumConditio OrganState { get => _organState; set => _organState = value; }
    }


}