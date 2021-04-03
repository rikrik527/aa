using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonYushanBasic<InventoryManager>
{
    private Dictionary<int, ItemDetails> itemDetailsDictionary;
}
