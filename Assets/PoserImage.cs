using UnityEngine;

public class Pizza : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Quand on clique sur le GameObject devant nous avec la main et qu'on dit la phrase "NOM_OBJET, assiette !", alors le gameObject apparait là où on a pointé
        // Exemple : "PizzaFamille, assiette !"  

        
    }

    public GameObject gameObjectToPlace;
    public string targetPhrase = "assiette !";
    public string[] acceptedDishes = new string[] { "PizzaFamille", "PizzaStylé", "PizzaGastronimique", "RamenFamille", "RamenStylé", "RamenGastronomique"};
    private bool isObjectSelected = false;

    // Update is called once per frame
    void Update()
    {
        // Détecter le clic sur le GameObject
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == gameObjectToPlace)
                {
                    isObjectSelected = true;
                }
            }
        }

        // Reconnaître la phrase (simplifié pour l'exemple)
        if (isObjectSelected && Input.GetKeyDown(KeyCode.Return))
        {
            string spokenPhrase = GetSpokenPhrase(); // Implémentez cette fonction pour obtenir la phrase prononcée
            if (spokenPhrase.Contains(targetPhrase) && ContainsAcceptedDish(spokenPhrase))
            {
                // Faire apparaître le GameObject à l'endroit pointé
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    gameObjectToPlace.transform.position = hit.point;
                    isObjectSelected = false;
                }
            }
        }
    }

    // Fonction fictive pour obtenir la phrase prononcée
    private string GetSpokenPhrase()
    {
        // CFR THIBAUT
        return "PizzaFamille, assiette !"; // Exemple de phrase reconnue
    }

    // Vérifie si la phrase contient un élément de la liste acceptedDishes
    private bool ContainsAcceptedDish(string phrase)
    {
        foreach (string dish in acceptedDishes)
        {
            if (phrase.Contains(dish))
            {
                return true;
            }
        }
        return false;
    }
}
