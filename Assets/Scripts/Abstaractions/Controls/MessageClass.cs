using UnityEngine;

public class MessageClass<FAdress,TAdress,Mail>
    where FAdress : class
    where TAdress : class
    where Mail : struct { }






    //public static Singltone<T> Instance{ get=> { if (instance == null) 
    //                                                new Singltone<T> ();
    //                                                else instance; } 
    //                            set=>}
    
    //static      List<MonoBehaviour> wer ;
    //
    //