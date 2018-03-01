******************************************************LÄGGA TILL PROJEKT FÖR GIT****************************************
Se till att ni har ett konto på hemsidan bitbucket.
Se till att ni är tillagda i projektet mdhelpvs som bör finnas på högersida när ni befinner er i dashboard på hemsidan.

********Ni bör redan gjort ovanstående***********

Starta Visual studio!
Tryck File->New->Repository

Ni kommer till Team Explorer och där ska ni lägga till eran Git.
Tryck på Clone under Local Git......
I den översta ska ni lägga in eran länk till projekter som ni hittar överst på sidan på bitbucket i erat mdhelpvs projekt.
Dit kommer ni genom att klicka på projektet genom dashboard på bitbuckets hemsida.
Kopiera adressen och lägg till där det står Enter the URL or a Git repo to clone.///Gul texbox///

Under den gör ni en plats för erat projekt typ C:/Test/MDHelp
Låt bocken vara kvar på clone submodules

Tryck Clone och så laddar den hem senaste git versionen till din angivna path.
När den blir klar så lämnas en lite n röd ikon brevid namnet så då är det klart.

Nu skapa din solution genom att trycka File->New->Web Site
Välj ASP.NET Empty Web Site och välj din angivna plats som tidigare typ C:/Test/MDHelp
Tryck vidare och du får upp en ruta med tre val för att webplats redan finns. Välj då Open the xisting Web Site och tryck OK

GRATTIS DU HAR NU FIXAT ALLT OCH KAN NU BÖRJA JOBBA...


******************************************************ANVÄNDA GIT MED VS****************************************

Jobba som vanligt med projektet...
När ni är klara ska ni göra följande
Gå till Team explorer där ni ser eran git med röd ikon. Dubbelklicka på den.

Ni får fyra alternativ och vi behöver bara använda 2st "Changes" och "Sync"

1. Gå in i "Changes" och skriv en kommentar om vad ni gjort. Under ser ni alla förändringar du eller programmet själv har gjort.
*******Är det något som ni vill ångra så högerklicka på filen och välj undo changes********
Du trycker bara på Commit All.

2. Sedan trycker du bakåt och går in på "Sync" och där rycker ni på "Fetch". Den kommer visa om det finns något nytt från någon annan som inte du har tagit hem ännu.
Finns något nytt så visas det och då väljer du att trycka på "Pull".

3. Sedan nu kan du trycka på Push för att lägga till din commit till Servern så att alla andra kan få tag på det.

KLART. Och så gör du om det varje gång du jobbat klart på projektet.

*******PS GÖR TILL VANA ATT ALLTID TRYCKA FETCH OCH PULL INNAN DU BÖRJAR ARBETA FÖR ATT SLIPPA MERGA FÖR MYCKET********