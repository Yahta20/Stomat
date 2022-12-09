namespace KHNMU.BodyAnatomy { 
    
    [System.Serializable]
    public struct Faucibus // throats глотка
    {
        public Mordere Bite;
        public ToothState[] superior;
        public ToothState[] maxilla;
        public Vita colorVita;

    }
    [System.Serializable]
    public enum Mordere //Bite прикус
    {
        unknow=0,
        neutral,
        mezial,
        destal,
    }

    [System.Serializable]//Vita color
    public enum Vita //цвет вита
    {
        A1= 0,
        A2,
        A3,
        A35,
        A4,
        B1,
        B2,
        B3,
        B4,
        C1,
        C2,
        C3,
        C4,
        D1,
        D2,
        D3
    }
    
    
}