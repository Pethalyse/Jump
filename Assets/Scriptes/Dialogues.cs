using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogues : MonoBehaviour
{
    [SerializeField]
    protected string nom;

    protected List<List<string>> codex = new List<List<string>>(); //tout les textes du pnj, [0][x] represente tout les deux la premiere fois qu'on lui parle, [1][x] la deuxieme fois etc;

    protected void init()
    {
        switch (nom)
        {
            case "Bellanus":
                {

                    codex = new List<List<string>>
                    {
                        new List<string> 
                        {
                        "Bonjour voyageur !",
                        "Je m'appelle " + nom + " et je vous guiderai dans votre début d'aventure."
                        },

                        new List<string> 
                        {
                        "Que faites-vous encore ici !",
                        "Partez, allez allez !"
                        }
                    };

                    break;
                }
        }
    }
}
