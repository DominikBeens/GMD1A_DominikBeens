using UnityEngine;
using System.Collections;

public class AchtergrondSwitch : MonoBehaviour {

    public Material[] materials;      //dit maakt een material array aan genaamd materials
    public int arrayPos;              //de positie waar de array op staat is een int

    public Material[] baseMaterials;  //nog een array
    public int baseArrayPos;          //en hier ook een 'positie voor de array'

    public GameObject baseMatButton;  //de button waarmee je de standardmaterial kleur kunt veranderen

    void Update()
    {
        if (arrayPos == 0)                      //als de positie van de array op 0 staat, staat hij in dit geval op de standard material
        {
            baseMatButton.SetActive(true);      //dan wordt er een button actief gezet
        }
        else
        {
            baseMatButton.SetActive(false);     //anders (als de array positie niet op 0 staat) dan wordt de button inactief
        }
    }

    public void UpdateMaterials()
    {
        arrayPos++;                                                               //de positie waar hij in de array op staat wordt één plek opgeschoven
        arrayPos %= materials.Length;                                             //hij kijkt hoeveel plekken er nog in de array zijn en zorgt ervoor dat hij in de array blijft, 
                                                                                  //als deze regel er niet zou staan dan zou de int arrayPos gewoon door blijven tellen en zou hij op de laatste material blijven zitten
        GetComponent<MeshRenderer>().sharedMaterial = materials[arrayPos];        //hier wordt de material van de achtergrond vervangen door de material waar de array op dat moment op staat     
    }

    public void UpdateBaseMaterials()                                             //hier geldt hetzelfde als bij de functie UpdateMaterials, dit is gekoppeld aan de button die actief en inactief wordt gezet
    {                                                                             //door als de array positie van de eerste functie op 0 staat, want als hij daarop staat is de achtergrond de standard achtergrond (één kleur)
        baseArrayPos++;                                                           //en met die button kun je die kleur dan weer veranderen naar andere kleuren, als de array positie van de eerste functie wordt verzet dan is de     
        baseArrayPos %= baseMaterials.Length;                                     //achtergrond een afbeelding, dus daar kun je de kleur niet van veranderen, dan is de button dus inactief        
        GetComponent<MeshRenderer>().sharedMaterial = baseMaterials[baseArrayPos];          
    }
}