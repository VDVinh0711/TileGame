
using UnityEngine;

public class GameRule : MonoBehaviour
{
    const int amountDupRequire = 3;

    public bool Check(Tile[] tiles , out string value )
    {
        value = string.Empty;
        //list arrray less than 
        if (tiles.Length < amountDupRequire)
        {
            value = string.Empty;
            return false;
        }
        for (int i = 0; i < tiles.Length -2; i++)
        {
            if (tiles[i].id == tiles[i + 1].id && tiles[i].id == tiles[i + 2].id)
            {
                value = tiles[i].id;
                return true;
            }
        }
        return false;
    }
}
