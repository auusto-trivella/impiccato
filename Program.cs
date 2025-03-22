Console.WriteLine("BENVENUTI GIOCATORI (oggi sono particolarmente simpatico)");
Console.WriteLine("questo magnifico giochino ha una particolare scelta per assegnare i punti ovvero:");
Console.WriteLine("");
Console.WriteLine("SCELTA DELLA MODALITA'");
Console.WriteLine("facile----> X4");
Console.WriteLine("media----> X5");
Console.WriteLine("difficile----> X6");
Console.WriteLine("");
Console.WriteLine("e ovviamente se indovini tutta la parola ( SCARSO NESSUNO CREDE IN TE ) ti sarà assegnato un bel X10");
Console.WriteLine("( ma tanto 10X0 fa sempre 0 )");
Console.WriteLine("");
Console.WriteLine("AH QUASI DIMENTICAVO SE SCEGLI LA DIFFICOLTA': DIFFICILE DICIAMO CHE CI SARA' UN AIUTINO ;)");
Console.WriteLine("");


bool again = true;

while (again == true)
{
    Console.WriteLine("SCELTA DELLA DIFFICOLTA':");
    Console.WriteLine("1<---facile (4 parole)");
    Console.WriteLine("2<---medio (5 parole)");
    Console.WriteLine("3<---difficile (6 parole)");

    int dif = Int32.Parse(Console.ReadLine());
    Console.WriteLine("avrai a disposizione 10 tentativi");
    Console.WriteLine("quando sbaglierai (molto spesso) si ridurranno i tentativi ");
    Console.WriteLine("");
    Console.WriteLine("BUONA FORTUNA");
    Console.WriteLine("");

    int tent = 10, punti = 0;
    char[] pINd = { };
    string parolaDaIndovinare = "", lUs = "", indovinate = "", errate = "";
    bool parolaComp = false;

    if (dif == 1)
    {
        Console.WriteLine("la difficoltà scelta è: FACILE");
        Console.WriteLine("MI ASPETTAVO UN PO' DI PIU' DA TE");
        string filePath = "IMPICCATO_PAROLE2.txt";
        string[] lines2 = File.ReadAllLines(filePath);
        Random random = new Random();
        int pS2 = random.Next(lines2.Length);
        parolaDaIndovinare = lines2[pS2];
        pINd = new string('_', parolaDaIndovinare.Length).ToCharArray();
    }
    else if (dif == 2)
    {
        Console.WriteLine("la difficoltà scelta è: MEDIA");
        Console.WriteLine("ONESTO");
        string filePath = "IMPICCATO_PAROLE1.txt";
        string[] lines1 = File.ReadAllLines(filePath);
        Random random = new Random();
        int pS1 = random.Next(lines1.Length);
        parolaDaIndovinare = lines1[pS1];
        pINd = new string('_', parolaDaIndovinare.Length).ToCharArray();
    }
    else if (dif == 3)
    {
        Console.WriteLine("la difficoltà scelta è: DIFFICILE");
        Console.WriteLine("ABBASSA LE ALI NON SEI FIGO");
        string filePath = "IMPICCATO_PAROLE3.txt";
        string[] lines3 = File.ReadAllLines(filePath);
        Random random = new Random();
        int pS3 = random.Next(lines3.Length);
        parolaDaIndovinare = lines3[pS3];
        pINd = new string('_', parolaDaIndovinare.Length).ToCharArray();

        Random rand = new Random();
        int nCas = rand.Next(parolaDaIndovinare.Length);

        // Aiuto con un jolly per la modalità difficile
        char jolly = parolaDaIndovinare[nCas];
        Console.WriteLine("DAI OGGI VOGLIO AIUTARTI (perchè so già che non c'è la farai) TI DO UN PICCOLO INDIZIETTO PROVA A SCRIVERE QUESTA LETTERINA ---->" + jolly);
    }
    else
    {
        Console.WriteLine("per caso vuoi INVENTARTI una nuova difficoltà, la prossima volta fa l'informatico allora");
        Console.WriteLine("");
    }

    tent = 10;
    //lettere usate
    lUs = "";

    while (tent > 0 && parolaComp == false)
    {
        Console.WriteLine("dimmi una lettera da indovinare:");
        string l = Console.ReadLine();

        if (l.Length != 1 && l.Length != parolaDaIndovinare.Length)
        {
            Console.WriteLine("è inutile che fai il furbo, inserisci solo una lettera");
            Console.WriteLine("");
        }
        else
        {
            lUs += l + ",";
        }

        char lettera = l[0];
        bool letteraIndovinata = false;

        for (int i = 0; i < parolaDaIndovinare.Length; i++)
        {
            if (parolaDaIndovinare[i] == lettera && pINd[i] == '_')
            {
                pINd[i] = lettera;
                letteraIndovinata = true;
            }
        }

        Console.WriteLine("LETTERE USATE---->" + lUs);

        if (letteraIndovinata == true)
        {
            Console.WriteLine("chi ci avrebbe mai creduto, sei riuscito ad indovinare una lettera");
            punti++;
            indovinate = indovinate + lettera;
        }
        else
        {
            Console.WriteLine("mi dispiace, quella lettera non è corretta peccato eh");
            tent--;
            errate = errate + lettera;
        }

        Console.WriteLine("PAROLA ATTUALE----> " + new string(pINd));
        Console.WriteLine("TENTATIVI RIMASTI---->: " + tent);

        if (new string(pINd) == parolaDaIndovinare)
        {
            parolaComp = true;
            Console.WriteLine("hai indovinato la parola non avrei messo 1 centesimo su di te ( ricci l'avrebbe fatto )");
            punti = punti * 10;
        }
    }

    if (parolaComp == false)
    {
        Console.WriteLine("hai esaurito i tentativi (peccato stavi iniziando a piacermi) La parola era: " + parolaDaIndovinare);
    }


    if (parolaDaIndovinare.Length == 4)
    {
        punti = punti * 4;
        Console.WriteLine("");
        Console.WriteLine("congratulazioni hai effettuato §" + punti + "§ punti");
    }
    else if (parolaDaIndovinare.Length == 5)
    {
        punti = punti * 5;
        Console.WriteLine("");
        Console.WriteLine("congratulazioni hai effettuato §" + punti + "§ punti");
    }
    else
    {
        punti = punti * 6;
        Console.WriteLine("");
        Console.WriteLine("congratulazioni hai effettuato §" + punti + "§ punti");
    }

    Console.WriteLine("SE VUOI ANCORA GIOCARE PREMI 'SI' SE INVECE VUOI USCIRE DIGITA 'NO'");
    string risposta = Console.ReadLine();

    if (risposta == "NO")
    {
        again = false;
        Console.WriteLine("le parole che hai indovinato nel corso del tuo tempo videogiochistisco sono state " + indovinate);
        Console.WriteLine();
        Console.WriteLine("le parole che NON hai indovinato nel corso del tuo tempo videogiochistisco sono state " + errate);
    }

}