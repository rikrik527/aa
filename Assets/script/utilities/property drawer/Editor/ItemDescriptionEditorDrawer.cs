using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomPropertyDrawer(typeof(ItemCodeDescriptionAttrubute))]
public class ItemDescriptionEditorDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        Debug.Log("property" + property);
        return EditorGUI.GetPropertyHeight(property) * 2;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // using beginProperty Endproperty on the parent property means that prefab override logic works on the entire property
        Debug.Log("label" + label + "rect position" + position + "propertuy" + property);
        EditorGUI.BeginProperty(position, label, property);
        if (property.propertyType == SerializedPropertyType.Integer)
        {

            Debug.Log("property.propertyType" + property.propertyType);
            EditorGUI.BeginChangeCheck();// start of check for changed value

            //Draw item code
            var newValue = EditorGUI.IntField(new Rect(position.x, position.y, position.width, position.height / 2), label, property.intValue);

            //draw item Description
            EditorGUI.LabelField(new Rect(position.x, position.y + position.height / 2, position.width, position.height / 2), "Item Description", GetItemDescription(property.intValue));

            //if item code value has changed, then set value to new value
            if (EditorGUI.EndChangeCheck())
            {
                property.intValue = newValue;
            }
        }
        EditorGUI.EndProperty();
    }
    private string GetItemDescription(int itemCode)
    {
        SO_ItemList so_itemList;
        so_itemList = AssetDatabase.LoadAssetAtPath("Assets/scriptable item assets/item/so_ItemList.asset", typeof(SO_ItemList)) as SO_ItemList;
        List<ItemDetails> itemDetailsList = so_itemList.itemDetails;
        ItemDetails itemDetails = itemDetailsList.Find(x => x.itemCode == itemCode);
        if (itemDetails != null)
        {
            return itemDetails.itemDescription;
        }
        else
        {
            return "fuck";
        }
    }


}