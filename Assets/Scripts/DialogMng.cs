using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogMng : MonoBehaviour
{
    private int dialog;

    public Camera c;
    public string perso1N;
    public string perso2N;
    public SpriteRenderer sprite1;
    public SpriteRenderer sprite2;
    //private SpriteRenderer backup;
    public Sprite Jack;
    public Sprite Pango;
    public Sprite Amanda;
    public Sprite Anna;
    public Sprite Brutus;
    public Sprite Zegrat;
    public Sprite garage;
    public Sprite Veronica;
    public Sprite Doc_S;
    public Sprite Rat;

    public Text name1;
    public Text name2;
    public Text leTexte;

    private string nom;
    private string text;
    private bool gauche;
    private Sprite s;
    private Vector2 size2;
    private Vector3 size3;

    public Image bg;
    public Image vaisseau;
    public Image jazz;
    public Image garagebg;


    //private ArrayList<int, string> dialog;
    //public TextMeshPro textmp;
    //private int timertimer;

    // Start is called before the first frame update
    void Start()
    {
        bg = vaisseau;
        dialog= gameManager.Singleton.dialog;
        //timer = 0;
        c = Camera.main;
        //backup = new SpriteRenderer();
        //backup.sprite = sprite2.sprite;
        sprite2.flipX = true;
        Vector2 size2 = sprite1.size;
        Vector3 size3 = size2;
        
        sprite1.transform.position = c.ViewportToWorldPoint(new Vector3(0, 0, 25));//new Vector3(0, 0, 0);//newpos + newpos2;
        sprite1.transform.position= sprite1.transform.position+size3;// c.ViewportToWorldPoint(new Vector3(0, 0, 0));//new Vector3(0, 0, 0);//newpos + newpos2;
        //Debug.Log(sprite1.transform.position);
        sprite2.transform.position = c.ViewportToWorldPoint(new Vector3(1, 0, 25));
        size2 = sprite2.size;
        size3 = new Vector3(-(size2.x),size2.y,0);
        sprite2.transform.position = sprite2.transform.position + size3;

        name1.text = perso1N;
        name2.text = perso2N;
        dialog--;
        callNext();
        sprite2.sprite = null;
        //timerText.text = gameManager.Singleton.timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        ++timer;
        if (timer > 100 && timer < 200)
        {
            sprite2.sprite = sprite1.sprite;
            name2.text = name1.text;
        }
        if (timer > 200 && timer < 300)
        {
            sprite2.sprite = null;
            name2.text = "???";
        }
        if (timer > 300)
        {
            sprite2.sprite = Pango;
            name2.text = perso2N;
        }
        */
    }
    public void callNext()
    {
        dialog++;
        phrase(dialog);
        next(nom, text, gauche, s);
        gameManager.Singleton.dialog++;
    }
    public void next(string nom, string text, bool gauche/*Gauche->true*/,Sprite s)
    {
        if (gauche)
        {
            sprite1.sprite = s;
            name1.text = nom;
            name1.gameObject.SetActive(true);
            name2.gameObject.SetActive(false);
            leTexte.text = text;

            size2 = sprite1.size;
            size3 = size2;
            sprite1.transform.position = c.ViewportToWorldPoint(new Vector3(0, 0, 25));
            sprite1.transform.position = sprite1.transform.position + size3;
        }
        else
        {
            sprite2.sprite = s;
            name2.text = nom;
            name1.gameObject.SetActive(false);
            name2.gameObject.SetActive(true);
            leTexte.text = text;
            sprite2.transform.position = c.ViewportToWorldPoint(new Vector3(1, 0, 25));
            size2 = sprite2.size;
            size3 = new Vector3(-(size2.x), size2.y, 0);
            sprite2.transform.position = sprite2.transform.position + size3;
        }/*
        switch (nom)
        {
            case "Jack Fletcher":
                leTexte.color = Color.red;
                break;
            case "Anna Flemington":
                leTexte.color = Color.blue;
                break;
            case "Amanda":
                leTexte.color = Color.green;
                break;
            case "Scarvftrv":
                leTexte.color = Color.yellow;
                break;
            case "Robierto":
                leTexte.color = Color.grey;
                break;
            case "Docteur S":
                leTexte.color = Color.magenta;
                break;
            default:
                leTexte.color = Color.white;
                break;
        }*/

    }

    public void phrase(int dialog)
    {
        switch (dialog)
        {
            case 1:
                nom = "Jack Fletcher";
                text = "Anna ca vient ces canons lasers? Je vais pas pouvoir tout éviter moi?";
                gauche = true;
                s = Jack;
                break;
            case 2:
                nom = "Anna Flemington";
                text = "Je fais ce que je peux ici mais en même temps qui a eu l'idée de génie de prendre un raccourci par un champ d'astéroïdes avec un vaisseau aussi vétusté?";
                gauche = false;
                s = Anna;
                break;
            case 3:
                nom = "Jack Fletcher";
                text = "Anna je vous interdit de critiquer le travail de maitre José le plus grand concepteur de vaisseaux de ce dernier millénaire !";
                gauche = true;
                s = Jack;
                break;
            case 4:
                nom = "Anna Flemington";
                text = "Justement si ce bâtiment ne datait pas du dernier millénaire on aurait sûrement une meilleure chance de sortir vivant de ce 'raccourci'.";
                gauche = false;
                s = Anna;
                break;
            case 5:
                nom = "Jack Fletcher";
                text = "Amanda comment tu t en sort avec les systèmes du vaisseau? On pourrait vraiment faire avec le pilotage assisté.";
                gauche = true;
                s = Jack;
                break;
            case 6:
                nom = "Amanda";
                text = "Je peux relancer les systèmes, pilotage automatique inclu, mais pour ça il va falloir tout éteindre et ça, ça veut dire tableau de bord éteint pour au moins 5 minutes.";
                gauche = false;
                s = Amanda;
                break;
            case 7:
                nom = "Amanda";
                text = "De toute façon avec les circuits endommagés j'aurais beau créer un système de pilotage qu'il ne pourrait pas s'exécuter avec notre tas de ferraille dans cet état.";
                gauche = false;
                s = Amanda;
                break;
            case 8:
                nom = "Jack Fletcher";
                text = "D'accord merci Amanda.";
                gauche = true;
                s = Jack;
                break;
            case 9:
                nom = "Jack Fletcher";
                text = "Scarvftrv dans quel état sont les moteurs ? On est plus sur de la petite réparation ou sur une tentative désespérée de contenir un feu de foret?";
                gauche = true;
                s = Jack;
                break;
            case 10:
                nom = "Scarvftrv";
                text = "Aaaaaaaaaaaaa *Clonk* *Tink* Jvarrrrgv !";
                gauche = false;
                s = Pango;
                break;
            case 11:
                nom = "Jack Fletcher";
                text = "Ok je vois ... la deuxième donc...";
                gauche = true;
                s = Jack;
                break;
            case 12:
                nom = "";
                text = "";
                gauche = true;
                s = null;
                //retour jeu
                SceneManager.LoadScene("Flight");
                break;
            case 13:
                nom = "Jack Fletcher";
                text = "Bon j'ai une idée mais ça risque de secouer.";
                gauche = true;
                s = Jack;
                break;
            case 14:
                nom = "Jack Fletcher";
                text = "Amanda tu peux nous calculer le meilleur moment pour déclencher la bombe pour détruire un maximum d'Asteroids?";
                gauche = true;
                s = Jack;
                break;
            case 15:
                nom = "Amanda";
                text = "ok je m'en occupe.";
                gauche = false;
                s = Amanda;
                break;
            case 16:
                nom = "Jack Fletcher";
                text = "Anna allez donner un coup de main à Scarvftrv il nous faut la bombe prête à détonner dés qu'Amanda aura trouvé le bon moment.";
                gauche = true;
                s = Jack;
                break;
            case 17:
                nom = "Anna Flemington";
                text = "Très bien tout devrait etre en ordre mais je vis effectuer les vérifications nécessaire.";
                gauche = false;
                s = Anna;
                break;
            case 18:
                nom = "Scarvftrv";
                text = "Svaaarv sfrav  sfa.";
                gauche = false;
                s = Pango;
                SceneManager.LoadScene("Flight");
                break;
            case 19:
                nom = "Amanda";
                text = "c'est bon ! si on la fait partir dans 24 secondes on devrait se débarasser de tous les asteroids qui nous bloquent le chemin.";
                gauche = true;
                s = Amanda;
                break;
            case 20:
                nom = "Amanda";
                text = "Tout est pret Mme Flemington?";
                gauche = true;
                s = Amanda;
                break;
            case 21:
                nom = "Anna Flemington";
                text = "Oui c'est bon !";
                gauche = false;
                s = Anna;
                break;
            case 22:
                nom = "Scarvftrv";
                text = "Jvaar !";
                gauche = false;
                s = Pango;
                break;
            case 23:
                nom = "Amanda";
                text = "Tout le monde est pret?";
                gauche = true;
                s = Amanda;
                break;
            case 24:
                nom = "Amanda";
                text = "3...2...1...";
                gauche = true;
                s = Amanda;
                break;
            case 25:
                nom = "Amanda";
                text = "BOOOOOM !";
                gauche = true;
                s = Amanda;
                SceneManager.LoadScene("Flight");
                break;
            //boom
            case 26:
                //explosion !
                break;
            case 27:
                nom = "Jack Fletcher";
                text = "Beau boulot tout le monde ! Maintenant direction la station de réparation la plus proche !";
                gauche = true;
                s = Jack;
                break;
            case 28:
                bg = garagebg;
                nom = "Robierto";
                text = "Bienvento en le meillor garage de cote du sector 56.";
                gauche = false;
                s = garage;
                //change bg
                break;
            case 29:
                nom = "Robierto";
                text = "Votre capsule etre besoin reparer? oui?";
                gauche = false;
                s = garage;
                break;
            case 30:
                nom = "Jack Fletcher";
                text = "Prenez-en bien soin.";
                gauche = true;
                s = garage;
                break;
            case 31:
                nom = "Jack Fletcher";
                text = "Scarvftrv tu veux assister dans les réparations ?";
                gauche = true;
                s = Jack;
                break;
            case 32:
                nom = "Scarvftrv";
                text = "Scaff.";
                gauche = false;
                s = Pango;
                break;
            case 33:
                nom = "Jack Fletcher";
                text = "Scarvftrv tu veux assister dans les réparations ?";
                gauche = true;
                s = Jack;
                break;
            case 34:
                nom = "Anna Flemington";
                text = "tuto rapide! click sur 'dodge' pour éviter, sur 'block' pour bloquer, après ça contre-attaque! (bloquer te fait quand même prendre quelques dégats.)";
                gauche = false;
                s = Anna;
                break;
            case 35:
                nom = "Jack Fletcher";
                text = "Amanda je suppose que tu vas rester dans ta chambre?";
                gauche = true;
                s = Jack;
                break;
                /* PAS LE TEMPS !!!
            case 29:
                nom = "Jack Fletcher";
                text = "Scarvftrv tu veux assister dans les réparations ?";
                gauche = true;
                s = garage;
                break;
            case 29:
                nom = "Jack Fletcher";
                text = "Scarvftrv tu veux assister dans les réparations ?";
                gauche = true;
                s = garage;
                break;
            case 29:
                nom = "Jack Fletcher";
                text = "Scarvftrv tu veux assister dans les réparations ?";
                gauche = true;
                s = garage;
                break;
            case 29:
                nom = "Jack Fletcher";
                text = "Scarvftrv tu veux assister dans les réparations ?";
                gauche = true;
                s = garage;
                break;
            case 29:
                nom = "Jack Fletcher";
                text = "Scarvftrv tu veux assister dans les réparations ?";
                gauche = true;
                s = garage;
                break;
            case 29:
                nom = "Jack Fletcher";
                text = "Scarvftrv tu veux assister dans les réparations ?";
                gauche = true;
                s = garage;
                break;
                break;*/
            case 36:
                nom = "Docteur S";
                text = "L'auteur n'a pas le temps de tout mettre s'il veut rendre le projet à temps !";
                gauche = true;
                s = Doc_S;
                break;
            case 37:
                nom = "Zegrat";
                text = "Vous devrez donc aller chercher un mcGuffin et pour cela batter un gars vraiment moche!";
                gauche = true;
                s = Zegrat;
                break;
            case 38:
                nom = "Jack Fletcher";
                text = "Hein quoi ? Attendez c'est quoi ce ...";
                gauche = true;
                s = Jack;
                SceneManager.LoadScene("Fight");
                break;
            case 39:
                nom = "Veronica Passion";
                text = "Bravo tu as gagné. il y a un scénar plus développé (pas fini tout de même) dans le fichier 'Draft' mais là y'avait vraiment pas le temps";
                gauche = true;
                s = Veronica;
                break;
            case 40:
                nom = "Veronica Passion";
                text = "Merci d'avoir joué !";
                gauche = true;
                s = Veronica;
                SceneManager.LoadScene("Credits");
                break;
            /* 
        case 13:
            nom = "Jack Fletcher";
            text = "Bon j'ai une idée mais ça risque de secouer.";
            gauche = true;
            s = Jack;
            break;
        case 13:
            nom = "Jack Fletcher";
            text = "Bon j'ai une idée mais ça risque de secouer.";
            gauche = true;
            s = Jack;
            break;*/
            default:
                Debug.Log("default case");
                break;
        }
    }
}
