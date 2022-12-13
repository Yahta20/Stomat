namespace KHNMU.BodyAnatomy
{

    [System.Serializable]
    public struct Faucibus // throats глотка
    {
        public Mordere Bite;
        public ToothState[] superior;//щелепа 
        public ToothState[] maxilla; //щелепа 
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
    
    
}