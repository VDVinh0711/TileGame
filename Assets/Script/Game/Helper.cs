using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : Singleton<Helper>
{

    
    public int CaculatorStar(int timelimit , int timeplay)
    {
        var partTimeSize = timelimit /3;
        int currrentpart = (int)Mathf.Floor(timeplay / partTimeSize);
        return 3 - currrentpart + 1;
    }
    
}
